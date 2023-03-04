using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float _movingSpeed;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackDame;
    [SerializeField] public float _healthPoint;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _detectingRange;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected AudioSource _killedSound;

    [SerializeField] protected List<Player> _listCharacter;

    protected IMoving _moving;
    void Start()
    {
        _moving = new Ally() as IMoving;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
