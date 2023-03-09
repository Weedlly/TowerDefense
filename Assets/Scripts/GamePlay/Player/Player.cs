using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [Header("Player atribute")]
    [SerializeField] public float _rangeAttack;
    [SerializeField] public float _rangeDetecting;
    [SerializeField] public float _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _dame;

    [SerializeField] protected Animator _animator;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected AudioSource _killedSound;
    

    [SerializeField] protected PlayerWeapon _weapon;
    [SerializeField] protected GameObject _hurtBlood;
    [SerializeField] protected bool _initRotate;
    [SerializeField] protected List<Player> _players;
    

    [Header("Control atribute")]
    public int _unitType;
    public bool _isDie = false;
    public Player _target;

    [Header("Runtime Debug atribute")]
    [SerializeField] protected bool _isMoving;
    [SerializeField] protected int _movingType;
    [SerializeField] protected bool _isAttack;
    [SerializeField] protected bool _attackAnimatorDelay;

    protected float _waitTime;
    protected float _waitShotAnimation;
    protected float _delayPerShot;
    protected float _timeToAttack;

    protected Vector2 _targetPositon;
    protected Vector2 _currentPosition;

    protected const float TIME_ATTACK = 0.4f / 1;
    protected const float WAIT_SHOT_ANIMATION = TIME_ATTACK   / (2f * 1);

    public int _meleeCompetitorCounter = 0;
    protected int _playerSide;

    protected void Start()
    {
        _isMoving = true;
        _movingType = (int)MovingType.MoveDefault;

        SetAudioVolume();

        SetRange();

        SetUpPlayerSide();

        SetUpUnitType();

        SetTimeAttack();

        _healthBar = GetComponent<HealthBar>();
        // _animator.speed = 1.2f;
    }
    void SetAudioVolume(){
        _killedSound.volume = 0.25f;
    }
    void SetRange(){
        CircleCollider2D rangeDetect = GetComponent<CircleCollider2D>();
        rangeDetect.radius = _rangeDetecting;
        
    }
    void SetUpUnitType(){
        if(_weapon != null){
            _unitType = (int)UnitType.Range;
        }
        else{
            _unitType = (int)UnitType.Melee;
        }
    }

    void SetUpPlayerSide(){
        if(gameObject.tag == "Enemy"){
            _playerSide = (int)PlayerSide.Enemy;
        }
        else if(gameObject.tag == "Ally"){
            _playerSide = (int)PlayerSide.Ally;
        }
    }
    #region Set up on start
    protected void SetTimeAttack(){
        _delayPerShot = _attackSpeed /  1;

        _timeToAttack = TIME_ATTACK;

        _waitShotAnimation = _timeToAttack / 2f;

        _waitTime = 0f;
    }


    #endregion Set up for start

    #region Flow control
    protected void Update() {
        if(_isDie == false){
            Rotate();
            NextTarget();
            if(_healthBar.CurrentHealth > _health){
                Destroy(Instantiate(_hurtBlood,_currentPosition,Quaternion.identity),0.25f);
            }
            _healthBar.CurrentHealth = _health;
            if(_health <= 0){
                SelfDestroy();
            }
            else if(_isAttack == true){
                AttackTargetProcess();
            }
            else if(_isMoving == true){
                switch (_movingType)
                {
                    case (int)MovingType.MoveDefault: {
                        MoveDefault();
                        break;
                    }
                    case (int)MovingType.MoveToTarget: {
                        MoveToTarget();
                        break;
                    }
                    // case (int)MovingType.WaitTargetArrived: {
                    //     WaitTargetArrived();
                    //     break;
                    // }

                }
            }
            _currentPosition = transform.position;
        }
    }

    #endregion Flow control
    virtual protected void NextTarget(){

    }

    #region Moving control
    protected void MoveToTarget(){
        if(Vector2.Distance(_targetPositon,transform.position) > _rangeAttack){
            
            //Set attack animator
            _animator.SetBool("isAttack",false);
            _animator.SetFloat("movingSpeed",0.5f);
            // _isAttack = false;
            // MoveTowards
            transform.position = Vector2.MoveTowards(transform.position,_targetPositon,Time.deltaTime * _speed);
        }
        else{
            // Arrived range to attack
            _isMoving = false;

            _target._isAttack = true;
            _isAttack = true;
        }
    }
 
    virtual protected void MoveDefault(){

    }
    #endregion Moving control

    #region Acttack control 

    protected void AttackTargetProcess(){
        if(_attackAnimatorDelay == true){
            _timeToAttack-=Time.deltaTime;
        }

        // Delay attack  animator 
        if(_timeToAttack <= 0){
            _attackAnimatorDelay = false;
            _animator.SetBool("isAttack",_isAttack);
            _timeToAttack = TIME_ATTACK;
        }

        _waitTime -= Time.deltaTime;

         // Delay attack 
        if (_waitTime <= 0f)
        {
            if(_attackAnimatorDelay == false){
                _attackAnimatorDelay = true;
                _animator.SetFloat("movingSpeed",-0.5f);
                _animator.SetBool("isAttack",_attackAnimatorDelay);
            }
            _waitShotAnimation -= Time.deltaTime;
            if(_waitShotAnimation <= 0 ){
                Attack();
                _waitShotAnimation = WAIT_SHOT_ANIMATION;
                _waitTime = _delayPerShot - WAIT_SHOT_ANIMATION;
            }
        }
    
    }
  
    void Attack(){
        switch (_unitType)
        {
            case (int)UnitType.Melee:{
                if(_target._health <= _dame){
                    _target._meleeCompetitorCounter = 0;
                    _meleeCompetitorCounter = 0;
                }
                _target.HealthReduce(_dame);
                break;
            }
            case (int)UnitType.Range:{
                PlayerWeapon instance = Instantiate(_weapon,_currentPosition,Quaternion.identity);
                instance.SetTarget(_target);
                instance.SetDamage(_dame);
                break;
            }
        }
    }
    
    
    #endregion Attack control

    public void HealthReduce(float healthReduce){
        _health -= healthReduce;
    }

   
    virtual public void SelfDestroy(){
        // do something
    }       

    protected void Rotate(){
        
        if(transform.position.x < _targetPositon.x){
            _spriteRenderer.flipX = !_initRotate;
        }
        else{
            _spriteRenderer.flipX = !_initRotate;
        }
    }

    #region Trigger control
    protected void OnTriggerStay2D(Collider2D other) {
        
        if(Vector2.Distance(_currentPosition,other.transform.position) <= _rangeDetecting){
            if(_playerSide == (int)PlayerSide.Ally){
                if(other.CompareTag("Enemy")){
                    Player instance = other.GetComponent<Player>();
                    if(!_players.Contains(instance) && !instance._isDie){
                        _players.Add(instance);
                    }
                }
            }      
            else if(_playerSide == (int)PlayerSide.Enemy){
                if(other.CompareTag("Ally")){
                    Player instance = other.GetComponent<Player>();
                    if(!_players.Contains(instance) && !instance._isDie){
                        _players.Add(instance);
                    }
                }   
            }
        }
    }
    protected void OnTriggerExit2D(Collider2D other) {
        if(_playerSide == (int)PlayerSide.Ally){
            if(other.CompareTag("Enemy")){
                Player instance = other.GetComponent<Player>();
                if(_players.Contains(instance)){
                    _players.Remove(instance);
                }
            }
        }      
        else if(_playerSide == (int)PlayerSide.Enemy){
            if(other.CompareTag("Ally")){
                Player instance = other.GetComponent<Player>();
                if(_players.Contains(instance)){
                    _players.Remove(instance);
                }
            } 
        }
    }

    #endregion Trigger control
}
