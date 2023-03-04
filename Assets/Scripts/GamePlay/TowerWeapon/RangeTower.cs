using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeTower : MonoBehaviour{
    public List<Enemy> _enemys;
    public float _range;
    // Focus the target and remove target : start
    private void OnTriggerStay2D(Collider2D other){
        if(Vector2.Distance(transform.position,other.transform.position) <= _range){
            Enemy enemy = other.GetComponent<Enemy>();
            if(other.CompareTag("Enemy") && !_enemys.Contains(enemy)){
                _enemys.Add(enemy);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(Vector2.Distance(transform.position,other.transform.position) <= _range){
            Enemy enemy = other.GetComponent<Enemy>();
            if(other.CompareTag("Enemy") && !_enemys.Contains(enemy)){
                _enemys.Add(enemy);
            }
        }
    }
    public bool IsTargetInRange(){
        if(_enemys[0] != null && Vector2.Distance(transform.position,_enemys[0].transform.position) <= _range){
            return true;
        }
        else{
            return false;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            Enemy enemy = other.GetComponent<Enemy>();
            if(_enemys.Contains(enemy)){
                _enemys.Remove(enemy);
            }
        }
    }
    // Focus the target and remove target : end

}
