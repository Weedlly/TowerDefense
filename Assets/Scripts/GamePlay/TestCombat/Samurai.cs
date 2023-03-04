using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float _heal;
    [SerializeField] private float _dame;

    [SerializeField] private float _attackDelay;

    public List<Bear> _listBear;

    public Bear _target;

    private float _timeCounter;

    public int _countCompetitor = 0;

    public HealthBar _healthBar;
    
   
    void FindTarget(){
        if(_target == null){
            _countCompetitor = 0;
            if(_listBear.Count > 0){
                if(_listBear[0] == null || _listBear[0]._countCompetitor > 0){
                    _listBear.RemoveAt(0);
                }
                else if(_listBear[0]._countCompetitor == 0){
                    _target = _listBear[0];
                    _target._countCompetitor++;
                    _countCompetitor++;
                    _target._target = this;
                }
            }
            
        }
    }

    void Start()
    {
          _timeCounter = _attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.CurrentHealth = _heal;
        FindTarget(); 
        if(_target!= null){
            Attack();
        }
        SelfDestroy();
    }

    void Attack(){
        _timeCounter -= Time.deltaTime;
        if(_timeCounter < 0){
            if(_target._heal < _dame){
                WinCombat();

            }
            _target._heal -= _dame;
            _timeCounter = _attackDelay;
            
        }
    }
    void WinCombat(){
        _countCompetitor = 0;
        _target._countCompetitor = 0;
    }
    void SelfDestroy(){
        
        if(_heal <= 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other){

        if(other.CompareTag("Bear")){
            Bear instance = other.GetComponent<Bear>();
            if(!_listBear.Contains(instance))
                _listBear.Add(instance);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Bear")){
            Bear instance = other.GetComponent<Bear>();
            if(_listBear.Contains(instance)){
                _listBear.Remove(instance);
            }
        }
    }
}
