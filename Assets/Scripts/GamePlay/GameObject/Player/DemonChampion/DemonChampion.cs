using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DemonBehavior {
    Idle,
    Moving,
    Attack,
    DeploySkill
}

public class DemonChampion : Evil
{
    Vector2 lastClickedPos;
    bool moving;

    public static bool _isChampEmploySkill;
    public static bool _isChampEmployInsticSkill;
    public static bool _isChampEmployActiveSkill;

    private bool _setMoving = false;

    new void Update()
    {
        base.Update();
        if(transform.position.x > _lastPosition.x){
            _spriteRenderer.flipX = true;
        }
        else if(transform.position.x < _lastPosition.x){
            _spriteRenderer.flipX = false;
        }
    }

    override protected void MoveDefault()
    {
        if (_setMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }

            if (moving && (Vector2) transform.position != lastClickedPos)
            {
                _animator.SetBool("isWalking", true);
                float step = _movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

            } else {
                moving = false;
                _animator.SetBool("isWalking", false);
                
            }
        }
        
    }

    public void StopAttacking()
    {
        //Stop attacking then moving
        _target = null;
        _animator.SetBool("isAttack", false);
    }

    public void StopDeploySkill()
    {
       //Stopping skill
    }

    public void SetMovement()
    {
        _setMoving = true;
    }
}
