using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MovingType{
    MoveDefault = 0,
    MoveToTarget = 1,
}
public class Character<T> : MonoBehaviour
{
    [SerializeField] public float _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _dame;
    [SerializeField] public float _rangeAttack;
    [SerializeField] public float _rangeDetecting;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected AudioSource _killedSound;
    [SerializeField] protected bool _initRotate;

    [SerializeField] protected List<T> _listCharacter;
    [SerializeField] protected CharacterWeapon _weapon;
    [SerializeField] protected GameObject _hurtBlood;

    protected float _waitTime;
    protected float _waitShotAnimation;
    protected float _delayPerShot;
    protected float _timeToAttack;

    protected const float TIME_ATTACK = 0.4f / GameControler.GAME_SPEED;
    protected const float WAIT_SHOT_ANIMATION = TIME_ATTACK   / (2f * GameControler.GAME_SPEED);
    public bool _rangedType;
    public bool _isDie = false;
    public T _target;

    public int _meleeCompetitorCounter = 0;
    public int _rangedCompetitorCounter = 0;

    
    protected Vector2 _targetPositon;
    protected Vector2 _currentPosition;

    private int _type;

    
    [SerializeField] private bool _isMoving;
    [SerializeField] private int _movingType;
    [SerializeField] private bool _isAttack;
    [SerializeField] private bool _attackAnimatorDelay;
    [SerializeField] public bool _isHurt;
    

    protected void Start()
    {
       
        _isMoving = true;
        _movingType = (int)MovingType.MoveDefault;

        if(_weapon != null){
            _rangedType = true;
        }
        SetTimeAttack();
        TypeOfCharacter();
        _healthBar = GetComponent<HealthBar>();
        _animator.speed = 1.2f;
    }

    #region Set up for start
    protected void SetTimeAttack(){
        _delayPerShot = _attackSpeed /  GameControler.GAME_SPEED;

        _timeToAttack = TIME_ATTACK;

        _waitShotAnimation = _timeToAttack / 2f;

        _waitTime = 0f;
    }

    void TypeOfCharacter(){
        if(typeof(T) == typeof(Enemy)){
            _type = ((int)CharacterType.Enemy);
        }
        else if(typeof(T) == typeof(Ally)){
            _type = ((int)CharacterType.Ally);
        }
    }

    #endregion Set up for start

    #region Flow control
    protected void Update() {
        _animator.SetFloat("motionTime",0.7f);
        if(_isDie == false){
            Rotate();
            FindTarget();
            if(_healthBar.CurrentHealth > _health){
                Destroy(Instantiate(_hurtBlood,_currentPosition,Quaternion.identity),0.25f);
            }
            _healthBar.CurrentHealth = _health;
            if(_health <= 0){
                SelfDestroy();
            }
            else if(_isAttack == true){
                AttackTarget();
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
                }
            }
            _currentPosition = transform.position;
        }
    }
    #endregion Flow control

    #region Find and select target
    void FindTarget(){
        if(_target == null){
            _isMoving = true;
            _movingType = (int)MovingType.MoveDefault;
            _isAttack = false;
            _animator.SetBool("isAttack",_isAttack);
            _animator.SetFloat("movingSpeed",0.5f);
            if(_listCharacter.Count > 0){
                if(_rangedType == true)
                {
                    if(_listCharacter[0] == null && CheckIsDie()){
                        _listCharacter.RemoveAt(0);
                        // _movingType = (int)MovingType.MoveDefault;
                    }
                    else{
                        _target = _listCharacter[0];
                        _movingType = (int)MovingType.MoveToTarget;
                    }   
                }
                else{
                    if(_listCharacter[0] == null || CheckCloseFighterCount()){
                        _listCharacter.RemoveAt(0);
                        // _movingType = (int)MovingType.MoveDefault;
                    }
                    else{
                        _target = _listCharacter[0];
                        SetTargetCloseFighterCounter(1);
                        _meleeCompetitorCounter ++;
                        _movingType = (int)MovingType.MoveToTarget;
                    }
                }
            }
        }
        else if(_target!=null){
            _isAttack = true;
            CheckTargetActive();
        }
     
    }
    
    void CheckTargetActive(){
        if(_type == 1){
            Enemy tmpTarget = _target as Enemy;
            
            if(tmpTarget.gameObject.activeSelf == false){
                ResetMeleeCounter();
                _target = default(T);
                _isAttack = false;
            }
        }
        else if(_type == 0){
            Ally tmpTarget = _target as Ally;
            if(tmpTarget.gameObject.activeSelf == false){
                ResetMeleeCounter();
                _target = default(T);
                _isAttack = false;
            }
        }
    }

    void SetTargetCloseFighterCounter(int value){
        if(_type == 1){
            Enemy tmpTarget = _target as Enemy;
            tmpTarget._target = this as Ally;
            tmpTarget._meleeCompetitorCounter = value;
        }
        else if(_type == 0){
            Ally tmpTarget = _target as Ally;
            tmpTarget._target = this as Enemy;
            tmpTarget._meleeCompetitorCounter = value;
        }
    }

    bool CheckCloseFighterCount(){
        if(_type == 1){
            Enemy tmpTarget = _listCharacter[0] as Enemy;
            if(tmpTarget._meleeCompetitorCounter > 0){
                return true;
            }
        }
        else if(_type == 0){
            Ally tmpTarget = _listCharacter[0] as Ally;
            if(tmpTarget._meleeCompetitorCounter > 0){
                return true;
            }
        }
        return false;
    }

    #endregion Find and select target

    #region Moving control
    protected void MoveToTarget(){
        if(Vector2.Distance(_targetPositon,transform.position) > _rangeAttack){
            
            //Set attack animator
            _animator.SetBool("isAttack",false);
            _animator.SetFloat("movingSpeed",0.5f);

            // MoveTowards
            transform.position = Vector2.MoveTowards(transform.position,_targetPositon,Time.deltaTime * _speed);
        }
        else{
            // Arrived range to attack
            _isMoving = false;
            _isAttack = true;
        }
    }
    virtual protected void MoveDefault(){

    }
    #endregion Moving control

    #region Acttack control 
    protected void AttackTarget(){

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
        if(_rangedType == true){
            CharacterWeapon instance = Instantiate(_weapon,_currentPosition,Quaternion.identity);
            Ally tmpTarget = _target as Ally;
            instance.SetTarget(tmpTarget);
            instance.SetDamage(_dame);
        }
        else{
            if(_type == 1){
                Enemy tmpTarget = _target as Enemy;
                
                if(tmpTarget._health <= _dame){
                    ResetMeleeCounter();
                }
                tmpTarget.HealthReduce(_dame);
                tmpTarget._isHurt = true;
            }
            else if(_type == 0){
                Ally tmpTarget = _target as Ally;
                if(tmpTarget._health <= _dame){
                    ResetMeleeCounter();
                }
                tmpTarget.HealthReduce(_dame);
            }
        }
        
    }
    #endregion Attack control

     bool CheckIsDie(){
        if(_type == 1){
            Enemy tmpTarget = _listCharacter[0] as Enemy;
            if(tmpTarget._isDie == true){
                return true;
            }
        }
        else if(_type == 0){
            Ally tmpTarget = _listCharacter[0] as Ally;
            if(tmpTarget._isDie == true){
                return true;
            }
        }
        return false;
    }
    void ResetMeleeCounter(){
        if(_rangedType == true){
            SetTargetCloseFighterCounter(0);
        }
        else{
            SetTargetCloseFighterCounter(0);
            _meleeCompetitorCounter = 0;
        }
    }

    
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

    bool CheckIsDieBeforeAdd(T instance){
        if(_type == 1){
            Enemy tmpTarget = instance as Enemy;
            if(tmpTarget._isDie == true){
                return true;
            }
        }
        else if(_type == 0){
            Ally tmpTarget = instance as Ally;
            if(tmpTarget._isDie == true){
                return true;
            }
        }
        return false;
    }




    #region Trigger control
    protected void OnTriggerStay2D(Collider2D other) {
        if(Vector2.Distance(_currentPosition,other.transform.position) <= _rangeDetecting){
            if(typeof(T) == typeof(Enemy) && this.GetType() != typeof(Enemy)){
                // Debug.Log(other.IsTouching(this.GetComponent<CircleCollider2D>()));
                if(other.CompareTag("Enemy")){
                    T instance = other.GetComponent<T>();
                    if(!_listCharacter.Contains(instance) && !CheckIsDieBeforeAdd(instance)){
                        _listCharacter.Add(instance);
                    }
                }         
            }
            else if(typeof(T) == typeof(Ally) && this.GetType() != typeof(Ally)){
                if(other.CompareTag("Ally")){
                    T instance = other.GetComponent<T>();
                    if(!_listCharacter.Contains(instance)&& !CheckIsDieBeforeAdd(instance)){
                        _listCharacter.Add(instance);
                    }
                }   
            }
        }
    }
    protected void OnTriggerExit2D(Collider2D other) {
        if(typeof(T) == typeof(Enemy) && this.GetType() != typeof(Enemy)){
            if(other.CompareTag("Enemy")){
                T instance = other.GetComponent<T>();
                if(_listCharacter.Contains(instance)){
                    _listCharacter.Remove(instance);
                    Debug.Log("remove");
                    Debug.Log(instance);
                }
            }         
        }
        else if(typeof(T) == typeof(Ally) && this.GetType() != typeof(Ally) ){
            if(other.CompareTag("Ally")){
                T instance = other.GetComponent<T>();
                if(_listCharacter.Contains(instance)){
                    _listCharacter.Remove(instance);
                    Debug.Log("remove");
                    Debug.Log(instance);
                }
            }   
        }
    }

    #endregion Trigger control
}