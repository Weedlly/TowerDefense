using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create Mul object in specified gate
public class Spawner
{

    private LineRenderer _route;
    
    private ObjectPooler _pooler;

    public Spawner(ObjectPooler pooler,LineRenderer route){
        _pooler = pooler;
        _route = route;
    }

  
    
    public void SpawnerSingleObject(){
        Debug.Log(_pooler);
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.SetActive(true);

        EnemyMelee enemy1 = newInstance.GetComponent<EnemyMelee>();
        EnemyRange enemy2 = newInstance.GetComponent<EnemyRange>();

        if(enemy1 != null){
            enemy1.SetRoute(_route);
        }
        if(enemy2 != null){
            enemy2.SetRoute(_route);
        }
    }
}
