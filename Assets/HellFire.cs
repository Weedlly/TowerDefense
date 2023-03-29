using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellFire : MonoBehaviour
{ 
    [SerializeField] private float _rangeExplore;
    
    public Player _target;
    protected bool _isTargetExist = false;

    private bool _isExplored = false;
    private float _dame = 40f;
    // [SerializeField] private float _range;
    
    // [SerializeField] private float _movingSpeed;

    void Start()
    {
        //_movingSpeed = 2f;
    }
    void Update()
    {
        if (_target != null)
        {
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
    // void Moving(){
    //     if(Vector2.Distance(transform.position,_target.transform.position) < 0.5f){
    //         DameByExplored();
    //     }
    //     transform.position = Vector2.Lerp(transform.position,_target.transform.position,_movingSpeed * Time.deltaTime);
    //     _movingSpeed += _movingSpeed * 0.01f;
    // }
    
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
