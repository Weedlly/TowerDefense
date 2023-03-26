using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BossMelee : Human
{
    [SerializeField] private InputActionReference _movingSpeed, _attack, _pointerPosition;
    [SerializeField] private NightBorneSkill _skill_1;
    
    private Vector2 _pointerInput, _movementInput;
    public static bool _isBossEmploySkill;

    public static float delay = 1f;
    private bool attackBlocked;
    new void Update()
    {     
        base.Update();
        if(_health <= 0){
            attackBlocked = false;
            _isBossEmploySkill = false; 
            
           
        }
        else if(_health <= 800 && _target != null)
        {
            if (attackBlocked) 
                return;

            Debug.Log("Boss turn skill");
            attackBlocked = true;
            _animator.SetBool("isAttack",false);
            _isBossEmploySkill = true; 
            //Rotate();
            EmploySkill();   
        }
        
    }

    protected override void EmploySkill()
    {      
        if(_isBossEmploySkill)
        {   
            NightBorneSkill ndSkill = Instantiate(_skill_1, transform.position, Quaternion.identity);
            ndSkill.SetTarget(this._target); //boss target 
            StartCoroutine(DelayAttack()); 
            Destroy(ndSkill.gameObject, 1f);
        }           
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
