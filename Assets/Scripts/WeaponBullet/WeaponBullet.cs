using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBullet : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] private AudioSource FireAudio;

    [SerializeField] protected Enemy _target;

    [SerializeField] protected float _movingSpeed;

    [SerializeField] protected Animator _animator;

    [SerializeField] protected AudioSource _hitSound;

    protected float _dame;

    protected float _angle;

    void Start()
    {
        _animator.SetFloat("movingSpeed", _movingSpeed);
    }

    // Update is called once per frame
    protected void Update()
    {
        if (_target != null)
        {
            Moving();
        }
    }
    void Moving(){
        Vector3 line = _target.transform.position - transform.position;
        // Debug.Log(transform.up);
        _angle = Vector3.SignedAngle(transform.up,line,transform.forward);
        transform.Rotate(0f,0f,_angle); 

        if(Vector2.Distance(transform.position,_target.transform.position) < 0.5f){
            Hitting();
        }
        transform.position = Vector2.Lerp(transform.position,_target.transform.position,_movingSpeed * Time.deltaTime);
        _movingSpeed += _movingSpeed * 0.01f;
    }

    public virtual void Hitting(){
        _target._health -= _dame;
        PlayHittingSound();

        if(_target._health <= 0f){
            _target.SelfDestroy();
        }
        Destroy(this.gameObject);
    }

    protected void PlayHittingSound(){
        _hitSound.Play();
    }
    public void SetTarget(Enemy enemy){
        _target = enemy;
    }
    public void SetDamage(float damage){
        _dame = damage;
    }

}
