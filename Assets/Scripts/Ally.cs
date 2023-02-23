using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Character
{
    public Vector2 _assemblePoint {set;get;}

    private bool _isMoving = false;

    [SerializeField] private List<Enemy> _listEnemy;

    private Enemy _target;

    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        SetTarget();
    }

    public bool IsCombat(){
        if(_target != null){
            return true;
        }
        return false;
    }
    void SetTarget(){
        if(_target == null){
            if(_listEnemy.Count > 0){
                if(_listEnemy[0] == null){
                    _listEnemy.RemoveAt(0);
                }
                else{
                    if(_listEnemy[0].IsCombat() == false){
                        _target = _listEnemy[0];
                    }else{
                        _listEnemy.RemoveAt(0);
                    }
                }
            }
        }
        
    }
    override protected void Moving(){
        if(_target != null){
            AttackController();
        }
        else if( Vector2.Distance(_assemblePoint,transform.position) > 0.1){
            GoAssemblePoint();
        }
    }
    
    void GoAssemblePoint(){
        _animator.SetFloat("movingSpeed",0.5f);
        _lastPosition = _assemblePoint;
        transform.position = Vector2.MoveTowards(transform.position,_assemblePoint,Time.deltaTime * _speed);
    }
    void AttackController(){
        if(Vector2.Distance(_target.transform.position,transform.position) > 1f){
            GoEnemy();
        }
        else{
            AttackCompetitor();
        }
    }
    void AttackCompetitor(){
        _animator.SetFloat("movingSpeed",-0.5f);
        _animator.SetBool("isAttack",true);
    }

    void GoEnemy(){
        _animator.SetBool("isAttack",false);
        _animator.SetFloat("movingSpeed",0.5f);
        transform.position = Vector2.MoveTowards(
            transform.position,
            _target.transform.position,
            Time.deltaTime * _speed);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            Enemy instance = other.GetComponent<Enemy>();
            if(!_listEnemy.Contains(instance)){
                _listEnemy.Add(instance);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            Enemy instance = other.GetComponent<Enemy>();
            if(_listEnemy.Contains(instance)){
                _listEnemy.Remove(instance);
            }
        }
    }
}
