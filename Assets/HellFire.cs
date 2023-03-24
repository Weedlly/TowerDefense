using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellFire : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer _characterRenderer, _skillRenderer;
    [SerializeField] private float _rangeExplore;
    [SerializeField] private Vector2 _pointerPosition { get; set; }

    public Player _target;
    protected bool _isTargetExist = false;

    private bool _isExplored = false;
    private float _dame = 40f;

    //protected Vector2 _lastPosition;

    void Start()
    {
        
    }
    void Update()
    {
        if (_target != null)
        {
            // Vector2 direction = (_pointerPosition - (Vector2)transform.position).normalized;
            // transform.right = direction;

            if(transform.position.x > _pointerPosition.x){
                _skillRenderer.flipX = false;
            }
            else{
                _skillRenderer.flipX = true;
            }

            Vector2 scale = transform.localScale;
            if (_pointerPosition.x < 0)
            {
                scale.y = -1;
            }

            else if (_pointerPosition.x > 0)
            {
                scale.y = 1;
            }
            transform.localScale = scale;

            if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
            {
                _skillRenderer.sortingOrder = _characterRenderer.sortingOrder - 1;

            }else{
                _skillRenderer.sortingOrder = _characterRenderer.sortingOrder + 1; 
            }
 
            Employing();
        }   
    }

    public void Employing()
    {
        Debug.Log("Hell fire attack");
        if (_isExplored == false)
        {
            DameByExplored();
        }
        _isExplored = true;
        
        Destroy(this.gameObject, 0.1f);
    }

    private void DameByExplored()
    {
        GameObject[] instanceList = GameObject.FindGameObjectsWithTag("Evil");
        foreach (GameObject item in instanceList)
        {
            Evil evil = item.GetComponent<Evil>();
            if(Vector2.Distance(evil.transform.position, transform.position) < _rangeExplore)
            {
                evil._health -= _dame;
            }
            if(evil._health <= 0f)
            {
                evil.SelfDestroy();
            }
        }
    }
    

    
}
