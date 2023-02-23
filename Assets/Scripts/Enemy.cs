using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Character
{
    [SerializeField] private LineRenderer _route;
    [SerializeField] private int _earningCoin;

    [SerializeField] private List<Ally> _listAlly;
    private int _currentPositionIndex;
    private int _lengthOfPath;

    private Ally _target;
    new void Start()
    {
        base.Start();
        _currentPositionIndex = 0;
        _lengthOfPath = _route.positionCount;
    }
    
    new void Update()
    {
        base.Update();
        SetTarget();
    }
    public bool IsCombat(){
        if(_target != null){
            return true;
        }
        return false;
    }
    void SetTarget(){
        if(_target == null){
            if(_listAlly.Count > 0){
                if(_listAlly[0] == null){
                    _listAlly.RemoveAt(0);
                }
                else{
                    if(_listAlly[0].IsCombat() == false){
                        _target = _listAlly[0];
                    }
                    else{
                        _listAlly.RemoveAt(0);
                    }
                    
                }
            }
        }
    }
    
    

    public void SetRoute(LineRenderer route){
        _route = route;
        transform.position = _route.GetPosition(0);
    }

    override public void SelfDestroy(){

        GameObject dieInstance = Instantiate(gameObject);
        
        // Create new instance to perform destroy
        PlayDead(dieInstance.GetComponent<Enemy>());

        // Put back to pool
        ObjectPooler.ReturnToPool(gameObject);

        _currentPositionIndex = 0; // reset position
        _health =  _healthBar._maxHealth;
        
    }       
    protected void PlayDead(Enemy enemy){
        GameControl.IncreaseCoin(_earningCoin);
        enemy._isDie = true;
        enemy._animator.SetBool("_isDie",true);
 
        enemy._killedSound.Play();

        Destroy(enemy.gameObject,0.25f);
    }


    #region Moving
    override protected void Moving(){
        if(_target != null){
            AttackController();
        }
        else if(_target == null){
            _animator.SetBool("isAttack",false);
            GoDestination();
        }
    }

    void GoDestination(){
        if(Vector2.Distance(transform.position,_route.GetPosition(_currentPositionIndex)) < 0.1f ){
            _currentPositionIndex += 1;
            ArrivedDestination();
        }
        transform.position = Vector2.MoveTowards(transform.position,_route.GetPosition(_currentPositionIndex),Time.deltaTime * _speed);
    }
    void ArrivedDestination(){
        if(_currentPositionIndex == _lengthOfPath){
            _currentPositionIndex = 0;
            transform.position = _route.GetPosition(_currentPositionIndex);
            ObjectPooler.ReturnToPool(gameObject);
            GameControl.ReduceHealth();

        }
    }

    void GoEnemy(){
         _animator.SetBool("isAttack",false);
        _animator.SetFloat("movingSpeed",0.5f);
        transform.position = Vector2.MoveTowards(
            transform.position,
            _target.transform.position,
            Time.deltaTime * _speed);
    }

    #endregion Moving


    #region Attack
    void AttackController(){
        if(Vector2.Distance(_target.transform.position,transform.position) > 1f){
            GoEnemy();
        }
        else{
            AttackCompetitor();
        }
    }


    void AttackCompetitor(){
        _animator.SetFloat("movingSpeed",-0.5f);
        _animator.SetBool("isAttack",true);
    }

    #endregion Attack

    
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ally")){
            Ally instance = other.GetComponent<Ally>();
            if(!_listAlly.Contains(instance)){
                _listAlly.Add(instance);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Ally")){
            Ally instance = other.GetComponent<Ally>();
            if(_listAlly.Contains(instance)){
                _listAlly.Remove(instance);
            }
        }
    }
}