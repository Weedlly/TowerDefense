using UnityEngine;


public class Character : MonoBehaviour
{
    
    [SerializeField] protected float _speed;
    [SerializeField] public float _health;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected AudioSource _killedSound;

    protected Vector2 _lastPosition;
    public bool _isDie = false;

    protected void Start()
    {
        _lastPosition = transform.position;
        _healthBar = GetComponent<HealthBar>();
        _animator.speed = 1.2f;
    }

    protected void Update()
    {

        Rotate();
        _healthBar.CurrentHealth = _health;
   
        if(_isDie == false){
            Moving();
        }
    }
    
    virtual protected void Moving(){
    }

   
    virtual public void SelfDestroy(){

        // GameObject dieInstance = Instantiate(gameObject);
        
       
        // // Create new instance to perform destroy
        // PlayDead(dieInstance.GetComponent<Enemy>());

        // // Put back to pool
        // ObjectPooler.ReturnToPool(gameObject);

        // _currentPositionIndex = 0; // reset position
        // _health =  _healthBar._maxHealth;
        
    }       

    protected void Rotate(){
        
        if(transform.position.x > _lastPosition.x){
            _spriteRenderer.flipX = false;
        }
        else{
            _spriteRenderer.flipX = true;
        }
        
    }

    
}