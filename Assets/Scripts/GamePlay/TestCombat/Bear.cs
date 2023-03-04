using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float _heal;
    [SerializeField] private float _dame;

    [SerializeField] private float _attackDelay;

    public List<Samurai> _listSamurai;

    public Samurai _target;

    private float _timeCounter;

    public int _countCompetitor = 0;

    public HealthBar _healthBar;
    void FindTarget(){
        if(_target == null){
            _countCompetitor = 0;
            if(_listSamurai.Count > 0){
                if(_listSamurai[0] == null || _listSamurai[0]._countCompetitor > 0){
                    _listSamurai.RemoveAt(0);
                }
                else if(_listSamurai[0]._countCompetitor == 0){
                    _target = _listSamurai[0];
                    _target._countCompetitor++;
                    _countCompetitor++;
                    _target._target = this;
                }
            }
            
        }
    }

    void Start()
    {
          _timeCounter = _attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.CurrentHealth = _heal;
        FindTarget(); 
        if(_target!= null){
            Attack();
        }
        SelfDestroy();
    }
    void Attack(){
        _timeCounter -= Time.deltaTime;
        if(_timeCounter < 0){
            if(_target._heal < _dame){
                WinCombat();

            }
            _target._heal -= _dame;
            _timeCounter = _attackDelay;
            
        }
    }
    void WinCombat(){
        _countCompetitor = 0;
        _target._countCompetitor = 0;
    }
    void SelfDestroy(){
        
        if(_heal <= 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other){

        if(other.CompareTag("Samurai")){
            Samurai instance = other.GetComponent<Samurai>();
            if(!_listSamurai.Contains(instance))
            _listSamurai.Add(instance);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Samurai")){
            Samurai instance = other.GetComponent<Samurai>();
            if(_listSamurai.Contains(instance)){
                _listSamurai.Remove(instance);
            }
        }
    }
}


// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;



// public class Character<T> : MonoBehaviour
// {
    
//     [SerializeField] protected float _speed;
//     [SerializeField] protected float _attackSpeed;
//     [SerializeField] protected float _dame;
//     [SerializeField] public float _health;
//     [SerializeField] protected float _rangeAttack;
//     [SerializeField] protected Animator _animator;
//     [SerializeField] protected HealthBar _healthBar;
//     [SerializeField] protected SpriteRenderer _spriteRenderer;
//     [SerializeField] protected AudioSource _killedSound;

//     [SerializeField] protected List<T> _listCharacter;


//     protected bool _isAttack = false;
//     protected float _waitTime;
//     protected float _waitShotAnimation;
//     protected float _delayPerShot;
//     protected float _timeToAttack;
//     protected const float TIME_ATTACK = 0.4f / GameControler.GAME_SPEED;
//     protected const float WAIT_SHOT_ANIMATION = TIME_ATTACK   / (2f * GameControler.GAME_SPEED);



//     protected Vector2 _lastPosition;
//     public bool _isDie = false;
//     public T _target;

//     public int _closeCompetitorCounter = 0;

    
//     protected Vector2 _targetPositon;

//     private int _type;


//     protected void SetTimeAttack(){
//         _delayPerShot = _attackSpeed /  GameControler.GAME_SPEED;

//         _timeToAttack = TIME_ATTACK;

//         _waitShotAnimation = _timeToAttack / 2f;

//         _waitTime = 0f;
//     }

//     void TypeOfCharacter(){
//         if(typeof(T) == typeof(Enemy)){
//             _type = ((int)CharacterType.Enemy);
//         }
//         else if(typeof(T) == typeof(Ally)){
//             _type = ((int)CharacterType.Ally);
//         }
//     }

  
//     bool CheckCloseFighterCount(){
//         if(_type == 1){
//             Enemy tmpTarget = _listCharacter[0] as Enemy;
//             if(tmpTarget._closeCompetitorCounter > 0){
//                 return true;
//             }
//         }
//         else if(_type == 0){
//             Ally tmpTarget = _listCharacter[0] as Ally;
//             if(tmpTarget._closeCompetitorCounter > 0){
//                 return true;
//             }
//         }
//         return false;
//     }
//     void SetTargetCloseFighterCounter(int value){
//         if(_type == 1){
//             Enemy tmpTarget = _target as Enemy;
//             tmpTarget._target = this as Ally;
//             tmpTarget._closeCompetitorCounter = value;
//         }
//         else if(_type == 0){
//             Ally tmpTarget = _target as Ally;
//             tmpTarget._target = this as Enemy;
//             tmpTarget._closeCompetitorCounter = value;
//         }
//     }

//     void FindTarget(){
//         if(_target == null){
//             if(_listCharacter.Count > 0){
//                 Debug.Log(_listCharacter[0]);
//                 if(_listCharacter[0] == null || CheckCloseFighterCount()){
//                     _listCharacter.RemoveAt(0);
//                 }
//                 else{
//                     _target = _listCharacter[0];
//                     SetTargetCloseFighterCounter(1);
//                     _closeCompetitorCounter ++;
                    
//                 }
//             }
//         }
     
//     }
   
   

//     protected void AttackController(){
//         if(Vector2.Distance(_targetPositon,transform.position) > 1.5f){
//             GoTarget();
//         }
//         else{
//             AttackTarget();
//         }
//     }

    

//     protected void AttackTarget(){
//         _animator.SetFloat("movingSpeed",-0.5f);
//         _animator.SetBool("isAttack",true);

//         if(_isAttack == true){
//             _timeToAttack-=Time.deltaTime;
//         }
//         if(_timeToAttack <= 0){
//             _isAttack = false;
//             _animator.SetBool("isAttack",_isAttack);
//             _timeToAttack = TIME_ATTACK;
//         }

//         _waitTime -= Time.deltaTime;

//         if (_waitTime <= 0f)
//         {
//             if(_isAttack == false){
//                 _isAttack = true;
//                 _animator.SetFloat("movingSpeed",-0.5f);
//                 _animator.SetBool("isAttack",_isAttack);
//             }
//             _waitShotAnimation -= Time.deltaTime;
//             if(_waitShotAnimation <= 0 ){
//                 Hit();
//                 _waitShotAnimation = WAIT_SHOT_ANIMATION;
//                 _waitTime = _delayPerShot - WAIT_SHOT_ANIMATION;
//             }
//         }
    
//     }
//     void WinCombat(){
//         SetTargetCloseFighterCounter(0);
//         _closeCompetitorCounter = 0;
//     }
//     void Hit(){
//         if(_type == 1){
//             Enemy tmpTarget = _target as Enemy;
            
//             if(tmpTarget._health <= _dame){
//                 WinCombat();
//             }
//             tmpTarget.HealthReduce(_dame);
//         }
//         else if(_type == 0){
//             Ally tmpTarget = _target as Ally;
//             if(tmpTarget._health <= _dame){
//                 WinCombat();
//             }
//             tmpTarget.HealthReduce(_dame);
//         }
//     }
//     public void HealthReduce(float healthReduce){
//         _health -= healthReduce;
//     }
    

//     protected void GoTarget(){
//         _animator.SetBool("isAttack",false);
//         _animator.SetFloat("movingSpeed",0.5f);
        
//         transform.position = Vector2.MoveTowards(
//             transform.position,
//             _targetPositon,
//             Time.deltaTime * _speed
//             );
//     }
 

//     protected void Start()
//     {
//         SetTimeAttack();
//         TypeOfCharacter();
//         _lastPosition = transform.position;
//         _healthBar = GetComponent<HealthBar>();
//         _animator.speed = 1.2f;
//     }


//     protected void Update()
//     {
//         Rotate();
//         _healthBar.CurrentHealth = _health;
//         FindTarget();
//         if(_health <= 0 && _isDie == false){
//             SelfDestroy();
//         }

//         if(_isDie == false){
//             Moving();
//         }
        
//     }
    
//     virtual protected void Moving(){
//     }

   
//     virtual public void SelfDestroy(){
//         // do something
//     }       

//     protected void Rotate(){
        
//         if(transform.position.x > _lastPosition.x){
//             _spriteRenderer.flipX = false;
//         }
//         else{
//             _spriteRenderer.flipX = true;
//         }
        
//     }
//     protected void OnTriggerStay2D(Collider2D other) {
//         if(typeof(T) == typeof(Enemy) && this.GetType() != typeof(Enemy)){
//             if(other.CompareTag("Enemy")){
//                 T instance = other.GetComponent<T>();
//                 if(!_listCharacter.Contains(instance)){
//                     _listCharacter.Add(instance);
//                 }
//             }         
//         }
//         else if(typeof(T) == typeof(Ally) && this.GetType() != typeof(Ally)){
//             if(other.CompareTag("Ally")){
//                 T instance = other.GetComponent<T>();
//                 if(!_listCharacter.Contains(instance)){
//                     _listCharacter.Add(instance);
//                 }
//             }   
//         }
//     }
//     protected void OnTriggerExit2D(Collider2D other) {
//         if(typeof(T) == typeof(Enemy) && this.GetType() != typeof(Enemy)){
//             if(other.CompareTag("Enemy")){
//                 T instance = other.GetComponent<T>();
//                 if(_listCharacter.Contains(instance)){
//                     _listCharacter.Remove(instance);
//                     Debug.Log("remove");
//                     Debug.Log(instance);
//                 }
//             }         
//         }
//         else if(typeof(T) == typeof(Ally) && this.GetType() != typeof(Ally) ){
//             if(other.CompareTag("Ally")){
//                 T instance = other.GetComponent<T>();
//                 if(_listCharacter.Contains(instance)){
//                     _listCharacter.Remove(instance);
//                     Debug.Log("remove");
//                     Debug.Log(instance);
//                 }
//             }   
//         }
//     }
// }