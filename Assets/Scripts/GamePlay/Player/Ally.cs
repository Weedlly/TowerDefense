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
        _animator.SetFloat("movingSpeed",-0.5f);
        transform.position = Vector2.MoveTowards(transform.position,_assemblePoint,Time.deltaTime * _speed);
    }

    
   
    override public void SelfDestroy(){
        base.SelfDestroy();

        _isDie = true;
        _isAttack = false;
        _isMoving = true;
        _target = null;
        
        _movingType = (int)MovingType.MoveDefault;
        gameObject.SetActive(false);
    }       
}
