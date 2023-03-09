using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMelee : Ally
{

    override protected void NextTarget(){
        if(_target == null){
            _isMoving = true;
            _movingType = (int)MovingType.MoveDefault;
            _isAttack = false;

            _animator.SetBool("isAttack",_isAttack);
            _animator.SetFloat("movingSpeed",0.5f);
            
            SetTarget();
        }
        else{
            
            CheckTargetActive();
        } 
    }
    protected void SetTarget(){
        if(_players.Count > 0){
            if(_players[0] == null || _players[0]._meleeCompetitorCounter > 0){
                _players.RemoveAt(0);
            }
            else{
                _target = _players[0];
                _movingType = (int)MovingType.MoveToTarget;
                _target._meleeCompetitorCounter++;
                _target._target = this;
            }
        }
    }

    void CheckTargetActive(){
        if(_target.gameObject.activeSelf == false){
            _target._meleeCompetitorCounter = 0;
            _isAttack = false;
            _target = null;
        }
        else{
            _targetPositon = _target.transform.position;
        }
    }

    


}
