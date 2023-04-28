using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DemonBehavior {
    Idle,
    Moving,
    Attack,
    DeploySkill,
}


public class DemonChampion : Evil
{
    #region variables
        public DemonBehavior currentBehavior = DemonBehavior.Idle;
	#endregion

    public bool _isAttackState;

    public static bool _isChampEmploySkill;
    public static bool _isChampEmployInsticSkill;
    public static bool _isChampEmployActiveSkill;

    private bool _setMoving = false;
    bool _moving;

    private Vector2 lastClickedPos;
    private Vector3 lastPosition; 

    public ExpSystem _expSystem;
    private bool upgrageBlock;

    new void Update()
    {
        if (_expSystem.isLevelUp)
        {
            UpgradeChampion();
            _expSystem.isLevelUp = false;
        }
        
        // Cancel attacking to move
        if (!_isAttackState && currentBehavior == DemonBehavior.Moving)
        {
            this._target = null;
        }

        if (_target != null) { 
            SetTarget(_target);
            SetAttack(); 
        }

        base.Update();
        CorrectDirection();
        

        switch (currentBehavior)
        {
            case DemonBehavior.Idle:
                Idle();
                break;

            case DemonBehavior.Moving:
                MoveDefault();  
                break;

            case DemonBehavior.Attack:
                Attack();
                break;
        }
        
    }

    public void CorrectDirection()
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
                _moving = true;
            }

            if (_moving && (Vector2.Distance((Vector2)transform.position, lastClickedPos) > 0.2f))
            { 
                _animator.SetBool("isWalking", true);
                float step = _movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            } 
           
            else if (Vector2.Distance((Vector2)transform.position, lastClickedPos) <= 0.2f) {
                _moving = false;
                _animator.SetBool("isWalking", false);

                lastClickedPos = new Vector2(0, 0);
                Idle();
            }   
        }
    }

    public void Idle()
    {
        currentBehavior = DemonBehavior.Idle;

        _setMoving = false;
        _animator.SetBool("isAttack", false);
        _isAttackState = false;       
    }

    public void SetMovement()
    {
        currentBehavior = DemonBehavior.Moving;
        this._animator.SetBool("isAttack", false);
        _isAttackState = false;
        _setMoving = true;
    }

    public void Moving() 
    {  
        this._animator.SetBool("isAttack", false);
        _setMoving = true;
    }

    public void SetAttack()
    {
        currentBehavior = DemonBehavior.Attack;
        _isAttackState = true;
    }

    public void Attack()
    {
        if (_target != null)
        {
            if (this._target._health <= 0)
            {
                _expSystem.AddExperience(5);
            }
        } else { 
            Idle(); 
        }
    }

    public void UpgradeChampion()
    {
        _attackDame = _expSystem.GetAttackDameIncrease(_attackDame);
        _attackSpeed = _expSystem.GetAttackSpeedIncrease(_attackSpeed);
    }

    public DemonBehavior CurrentBehavior {
        get { return currentBehavior; }
    }
}
