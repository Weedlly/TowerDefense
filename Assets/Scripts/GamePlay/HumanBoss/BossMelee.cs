using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Jobs;
using UnityEngine.Jobs;

public class BossMelee : Human 
{
    [SerializeField] private NightBorneSkill _skill;
    
    private Vector2 _pointerInput, _movementInput;

    public static bool _isBossEmploySkill;
    public static bool _isBossEmployInsticSkill;
    public static bool _isBossEmployActiveSkill;

    public static float delay = 1f;
    private bool attackBlocked;
    new void Update()
    {     
        base.Update();
        if(_health <= 0){
            _isBossEmployActiveSkill = false;

            _isBossEmploySkill = true; 
            _isBossEmployInsticSkill = true;
            
            EmploySkill();

            _isBossEmployInsticSkill = false;
            _isBossEmploySkill = false;

            _animator.SetBool("isDie", true);
             
        }
        else if((_health <= 900 && _health >= 0) && _target != null)
        {
            if (attackBlocked) 
                return;

            attackBlocked = true;
            _animator.SetBool("isAttack",false);

            _isBossEmploySkill = true; 
            _isBossEmployActiveSkill = true;

            EmploySkill();   
        } 
    }

    protected void EmploySkill()
    {      
        if(_isBossEmploySkill)
        {   
            NightBorneSkill nbSkill = Instantiate(_skill, transform.position, Quaternion.identity);
            nbSkill.SetTarget(this._target); //boss target   
            if (_isBossEmployActiveSkill){
                nbSkill.SetTypeSkill(SkillTypeEnum.ActiveSkill);
            }
            else{
                nbSkill.SetTypeSkill(SkillTypeEnum.InsticSkill);
            }
            
                      
            
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
