using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{   
    [SerializeField] private LineRenderer _route;
    [SerializeField] private int _earningCoin;
    private int _currentPositionIndex;
    private int _lengthOfPath;
    new void Start() {
        base.Start();
       _currentPositionIndex = 0;
        _lengthOfPath = _route.positionCount; 
    }
    public void SetRoute(LineRenderer route){
        _route = route;
        transform.position = _route.GetPosition(0);
    }
    
    override protected void MoveDefault(){
        
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
        enemy._animator.SetBool("isDie",true);
 
        enemy._killedSound.Play();
        enemy._meleeCompetitorCounter = 1;

        Destroy(enemy.gameObject,0.25f);
    }
    
}
