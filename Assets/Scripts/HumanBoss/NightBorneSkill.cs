using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneSkill : MonoBehaviour
{ 
    [SerializeField] private HellFire _prefab;
    [SerializeField] protected Player _target;
    [SerializeField] private Animator _animator;

    public bool IsDeloySkill { get; private set; }

    public Transform circleOrigin;
    public float radius;
    
    public void ResetIsDeloySkill()
    {
        IsDeloySkill = false;
    }
    
    public void SetTarget(Player target){     
        _target = target; 
        SkillAttack();
    }

    void Update()
    {
        if (!IsDeloySkill)
            return;
        // Vector2 direction = _pointerPosition ;
        
        
        if (_target != null && BossMelee._isBossEmploySkill == true)
        {
            
            HellFire hellfire = Instantiate(_prefab,transform.position,Quaternion.identity);
            hellfire._target = _target;
            //hellfire.Employing();
            //Destroy(hellfire.gameObject, 0.4f);
        }  
        
    }

    public void SkillAttack()    
    {
        IsDeloySkill = true;
        _animator.SetTrigger("Attack");
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            Debug.Log(collider.name);
        }
    }

    
    
}
