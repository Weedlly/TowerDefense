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

private DemonBehavior behavior;

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
        switch (behavior)
        {
            case DemonBehavior.Idle:
                DirectionCorrection();

            case DemonBehavior.Moving:
                MoveDefault();

            case DemonBehavior.Attack:
                _maxMeleeCompetitor = 1;
                BattleControler.AddEvil(this);

            case DemonBehavior.DemonSkill:
                

            default:
        }
        
    }

    public void DirectionCorrection()
    {
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

    public void Idle()
    {

    }

    public void SetMovement()
    {
        this._animator.SetBool("isAttack", false);
        Debug.log("is click to move");
        _setMoving = true;
    }

    public DemonBehavior CurrentBehavior {
        get { return crrentBehavior; }
    }
}
