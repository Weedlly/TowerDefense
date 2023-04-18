using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour
{
    [SerializeField] private Animator _animatorFireRain;

    public Transform circleOrigin;
    public float radius;
    private float _dame = 100f;
    [SerializeField] private float _rangeExplore;

    void Start()
    {
        _animatorFireRain.SetBool("isDeploySkill", true);
        
    }

    
    void Update()
    {
        DameByExplored();
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

     private void DameByExplored()
    {
        GameObject[] instanceList = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject item in instanceList)
        {
            Human human = item.GetComponent<Human>();
            if(Vector2.Distance(human.transform.position, transform.position) < _rangeExplore)
            {
                human.HealthReduce(_dame);
            }
            if(human._health <= 0f)
            {
                human.SelfDestroy();
            }
        }
    }
}
