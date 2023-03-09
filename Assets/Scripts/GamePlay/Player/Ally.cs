using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Player
{   
    public Vector2 _assemblePoint {set;get;}
    public float _timeReviveCounter;

    new void Update() {
        base.Update();
  
    }
   
    override protected void MoveDefault(){
        _animator.SetFloat("movingSpeed",0.5f);
        transform.position = Vector2.MoveTowards(transform.position,_assemblePoint,Time.deltaTime * _speed);
    }

    
   
    override public void SelfDestroy(){

        GameObject dieInstance = Instantiate(gameObject);
        
        PlayDead(dieInstance.GetComponent<Ally>());

        _isDie = true;
        _isAttack = false;
        _isMoving = true;
        _target = null;
        
        _movingType = (int)MovingType.MoveDefault;
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
