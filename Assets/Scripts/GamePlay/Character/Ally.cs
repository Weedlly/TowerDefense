using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Character<Enemy>
{
    public Vector2 _assemblePoint {set;get;}
    public float _timeReviveCounter;
    
    new void Start()
    {
        base.Start();
        _timeReviveCounter = 0f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if(_target != null){
            _targetPositon = _target.transform.position;
        }
    }
    
    override protected void MoveDefault(){
        _animator.SetFloat("movingSpeed",0.5f);
        transform.position = Vector2.MoveTowards(transform.position,_assemblePoint,Time.deltaTime * _speed);
    }
   
    override public void SelfDestroy(){

        GameObject dieInstance = Instantiate(gameObject);
        
        // Create new instance to perform destroy
        PlayDead(dieInstance.GetComponent<Ally>());
        this._isDie = true;
        // Put back to pool
        // ObjectPooler.ReturnToPool(gameObject);

        // _currentPositionIndex = 0; // reset position
        // _health =  _healthBar._maxHealth;
        gameObject.SetActive(false);
    }       
    
    protected void PlayDead(Ally ally){
        ally._isDie = true;
        ally._animator.SetBool("isDie",true);
        ally._meleeCompetitorCounter = 1;
        ally._killedSound.Play();

        Destroy(ally.gameObject,0.25f);
    }
}
