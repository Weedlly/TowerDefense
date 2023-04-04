using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSystem : MonoBehaviour
{
   
    [SerializeField] private  List<GameObject> _playerTypeInBattle;
    // [SerializeField] private  GameObject _bossTypeInBattle;
    [SerializeField] private  int _maxWave;
    [SerializeField] private  List<int> _numbers;
    private  List<LineRenderer> _gates;
    [SerializeField] private  RouteSet _routeSet;
    // [SerializeField] private Button _callWaveBt;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnWaveInterval;
    private bool _isCalledBoss = false;
    [SerializeField] private List<ObjectPooler> _poolers = new List<ObjectPooler>();
    // private bool _enableSpawn = true;
    protected bool MapStageData(int stageId, string difficultyType){
        
        return true;
    }
    private void Start() {
        GameControl.CurrentWave = 1;
        GameControl.MaxWave = _maxWave;
        _gates = _routeSet.GetGates();


        // Spawner instance = new Spawner(_poolers[0],_gates[1]);
        // instance.SpawnerSingleObject();

    
    }
   
    public void CallWave(){
        StartCoroutine(SpawnWaveOfStage());
        
    }
    IEnumerator SpawnWaveOfStage(){
        
        for (int i = 0; i < _maxWave; i++)
        {
            
            StartCoroutine(SpawnSubWaveOfWave());
            yield return new WaitForSeconds(20f);
            
            
            if(_isCalledBoss == false && GameControl.CurrentWave  == GameControl.MaxWave){
                _isCalledBoss = true;
                Spawner instance = new Spawner(_poolers[0],_gates[1]);
                instance.SpawnerSingleObject();
            }
            if(GameControl.CurrentWave  < GameControl.MaxWave){
                GameControl.CurrentWave ++;
            }
        }
    }
    IEnumerator SpawnSubWaveOfWave(){
        int maxSubWave = Random.Range(2,5);
        for (int i = 0; i < maxSubWave; i++)
        {
            
            StartCoroutine(SpawnTurnOfWave());
            yield return new WaitForSeconds(_spawnWaveInterval);
        }
    }
    IEnumerator SpawnTurnOfWave(){
        for (int i = 0; i < _gates.Count; i++)
        {
            int type = Random.Range(1,3);
            StartCoroutine(SpawnObject(type,_gates[i]));
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    IEnumerator SpawnObject(int type,LineRenderer gate){
        int numberSpawn = Random.Range(1,4);
        for (int i = 0; i < numberSpawn; i++)
        {
            Spawner instance = new Spawner(_poolers[type],gate);
            instance.SpawnerSingleObject();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    
}
