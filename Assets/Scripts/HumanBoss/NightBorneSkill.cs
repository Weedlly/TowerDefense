using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneSkill : MonoBehaviour
{ 
    [SerializeField] private HellFire _prefab;
    [SerializeField] protected Player _target;
    [SerializeField] private Animator _animator;

    public bool IsDeloySkill { get; private set; }
    [SerializeField] private SpriteRenderer _characterRenderer, _skillRenderer;
    [SerializeField] private Vector2 _pointerPosition { get; set; }

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

        Vector2 direction = (_pointerPosition - (Vector2)transform.position).normalized;
            transform.right = direction;


        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            Debug.Log("Left face");
            scale.y = -1;
        }

        else if (direction.x > 0)
        {
            Debug.Log("right face");
            scale.y = 1;
        }
        transform.localScale = scale;

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            Debug.Log("Left face pos");
            _skillRenderer.sortingOrder = _characterRenderer.sortingOrder - 1;

        }else{
            Debug.Log("Right face pos");
            _skillRenderer.sortingOrder = _characterRenderer.sortingOrder + 1; 
        }  
        
        
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
