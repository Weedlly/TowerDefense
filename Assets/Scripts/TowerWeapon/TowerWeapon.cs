using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TowerWeapon : Tower
{
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackDame;
    [SerializeField] protected List<Enemy> _enemys;
    [SerializeField] protected Animator _animator;


    protected bool _isAttack = false;
    protected float _waitTime;
    protected float _waitShotAnimation;
    protected float _delayPerShot;
    protected float _angle;
    protected float _timeToAttack;

    protected const float TIME_ATTACK = 0.4f / GameControler.GAME_SPEED;
    protected const float WAIT_SHOT_ANIMATION = TIME_ATTACK   / (2f * GameControler.GAME_SPEED);

    protected new void Start()
    {
        base.Start();
        SetTimeAttack();
    }

    protected void SetTimeAttack(){
        _delayPerShot = _attackSpeed /  GameControler.GAME_SPEED;

        _timeToAttack = TIME_ATTACK;

        _waitShotAnimation = _timeToAttack / 2f;

        _waitTime = 0f;
    }
    // Update is called once per frame
    protected void Update() {
        AttackControler(); 
    }

    // Atack controller : start
    protected void AttackControler(){
        if(_enemys.Count != 0){
            if(_enemys[0] != null){

                if(_isAttack == true){
                    _timeToAttack-=Time.deltaTime;
                }
                if(_timeToAttack <= 0){
                    _isAttack = false;
                    _animator.SetBool("isAttack",_isAttack);
                    _timeToAttack = TIME_ATTACK;
                }

                _waitTime -= Time.deltaTime;

                if (_waitTime <= 0f)
                {
                    if(_enemys[0]._health >= 0){
                        if(_isAttack == false){
                            _isAttack = true;
                            _animator.SetBool("isAttack",_isAttack);
                        }

                        Rotate();
                        _waitShotAnimation -= Time.deltaTime;
                        if(_waitShotAnimation <= 0 ){
                            Shoot();
                            _waitShotAnimation = WAIT_SHOT_ANIMATION;
                            _waitTime = _delayPerShot - WAIT_SHOT_ANIMATION;
                        }
                    }
                }

            }
            else{
                _enemys.RemoveAt(0);
            }
        }
        else{
            _isAttack = false;
            _animator.SetBool("isAttack",_isAttack);
            _waitTime = _delayPerShot;
        }
    }
     // Atack controller : end

    protected virtual void Shoot(){
        // do something
    }

    protected virtual void Rotate(){
        Vector3 line = _enemys[0].transform.position - transform.position;
        _angle = Vector3.SignedAngle(transform.up,line,transform.forward);
        transform.Rotate(0f,0f,_angle); 
    }

    

    // Focus the target and remove target : start
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            _enemys.Add(collision.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            Enemy enemy = collision.GetComponent<Enemy>();
            if(_enemys.Contains(enemy)){
                _enemys.Remove(enemy);
            }
        }
    }
    // Focus the target and remove target : end

}
