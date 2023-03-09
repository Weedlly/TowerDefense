using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Setting")]
    [SerializeField] private int _enemyCount = 10;
    // [SerializeField] private GameObject test;
    [SerializeField] private float _delaySpawnerTime;

    [SerializeField] private LineRenderer _route;
    
    [SerializeField]
    private ObjectPooler _pooler;
    private float _spawnerTime;
    private int _enemySpawned;

    
    void Start()
    {

        _pooler = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log(_spawnerTime);
        _spawnerTime -= Time.deltaTime;
        if(_enemySpawned <= _enemyCount){
            if(_spawnerTime < 0 ){
                SpawnerEnemy();
                _enemySpawned++;
                _spawnerTime = _delaySpawnerTime;
            }
        }
    }
    void SpawnerEnemy(){
       GameObject newInstance = _pooler.GetInstanceFromPool();
       newInstance.SetActive(true);
       EnemyMelee enemy1 = newInstance.GetComponent<EnemyMelee>();
       EnemyRange enemy2 = newInstance.GetComponent<EnemyRange>();
       
       Enemy enemy = newInstance.GetComponent<Enemy>();
       if(enemy != null){
            enemy.SetRoute(_route);
       }
       if(enemy1 != null){
            enemy1.SetRoute(_route);
       }
       if(enemy2 != null){
            enemy2.SetRoute(_route);
       }

    }
}
