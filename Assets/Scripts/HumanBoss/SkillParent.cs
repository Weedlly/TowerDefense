using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillParent : MonoBehaviour
{
    // public SpriteRenderer _characterRenderer, _weaponRenderer;
    // public Vector2 _pointerPosition { get; set; }
    // public Animator _animator;
    // public float _dame;

    // public float delay = 0.3f; 
    // private bool attackBlocked;

    // public bool IsDeloySkill { get; private set; }

    // public Transform circleOrigin;
    // public float radius;

    // public void ResetIsDeloySkill()
    // {
    //     IsDeloySkill = false;
    // }
    // private void Update()
    // {
    //     if (IsDeloySkill)
    //         return;
    //     Vector2 direction = (_pointerPosition - (Vector2)transform.position).normalized;
    //     transform.right = direction;

    //     Vector2 scale = transform.localScale;
    //     if (direction.x < 0)
    //     {
    //         scale.y = -1;
    //     }

    //     else if (direction.x > 0)
    //     {
    //         scale.y = 1;
    //     }
    //     transform.localScale = scale;

    //     if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
    //     {
    //         _weaponRenderer.sortingOrder = _characterRenderer.sortingOrder - 1;

    //     }else{
    //         _weaponRenderer.sortingOrder = _characterRenderer.sortingOrder + 1; 
    //     }
    // }

    // public void SkillAttack()    
    // {
    //     if (attackBlocked) 
    //         return;

    //     _animator.SetTrigger("Attack");
    //     IsDeloySkill = true;
    //     attackBlocked = true;
    //     StartCoroutine(DelayAttack()); 
    // }

    // private IEnumerator DelayAttack()
    // {
    //     yield return new WaitForSeconds(delay);
    //     attackBlocked = false;
    // }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.blue;
    //     Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
    //     Gizmos.DrawWireSphere(position, radius);
    // }

    // public void DetectColliders()
    // {
    //     foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
    //     {
    //         Debug.Log(collider.name);
    //     }
    // }
}
