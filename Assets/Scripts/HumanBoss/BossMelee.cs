using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Unity.Jobs;
using UnityEngine.Jobs;

public class BossMelee : Human 
{
    [SerializeField] private InputActionReference _movingSpeed, _attack, _pointerPosition;
    [SerializeField] private NightBorneSkill _skill;
    
    public static ISkillable _iSkillable;
    
    private Vector2 _pointerInput, _movementInput;

    public static bool _isBossEmploySkill;
    public static bool _isBossEmployInsticSkill;

    public static float delay = 1f;
    private bool attackBlocked;
    new void Update()
    {     
        base.Update();
        if(_health <= 0){
            // attackBlocked = false;
            _isBossEmploySkill = false; 
            _isBossEmployInsticSkill = true;
            
            EmploySkill();

            _isBossEmployInsticSkill = false;
            _animator.SetBool("isDie", true);
             
        }
        else if(_health <= 900 && _target != null)
        {
            if (attackBlocked) 
                return;

            Debug.Log("Boss turn skill");
            attackBlocked = true;
            _animator.SetBool("isAttack",false);
            _isBossEmploySkill = true; 
            EmploySkill();   
        } 
    }

    protected override void EmploySkill()
    {      
        if(_isBossEmploySkill)
        {   
            NightBorneSkill nbSkill = Instantiate(_skill, transform.position, Quaternion.identity);
            nbSkill.SetTypeSkill(SkillTypeEnum.ActiveSkill);
            nbSkill.SetTarget(this._target); //boss target 
            
            
            StartCoroutine(DelayAttack()); 
            Destroy(nbSkill.gameObject, 1f);
        }  
        else if(_isBossEmployInsticSkill)
        {   
            NightBorneSkill nbSkill = Instantiate(_skill, transform.position, Quaternion.identity);
            nbSkill.SetTypeSkill(SkillTypeEnum.InsticSkill);
            nbSkill.SetTarget(this._target); //boss target 
            

            StartCoroutine(DelayAttack()); 
            Destroy(nbSkill.gameObject, 1f);
        }             
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
