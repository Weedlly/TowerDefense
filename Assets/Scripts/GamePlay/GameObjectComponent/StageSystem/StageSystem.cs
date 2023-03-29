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

    private bool _enableSpawn = true;
    private void Start() {
        GameControl.CurrentWave = 1;
        GameControl.MaxWave = _maxWave;
        _gates = _routeSet.GetGates();


        // Spawner instance = new Spawner(_poolers[0],_gates[1]);
        // instance.SpawnerSingleObject();

    
    }
   
    // void ShowCallWaveButton(){
    //     if(_enableSpawn == false){
    //         _callWaveBt.gameObject.SetActive(false);
    //     }
    //     else {
    //         _callWaveBt.gameObject.SetActive(true);
    //     }
    // }
    public void CallWave(){
        StartCoroutine(SpawnWaveOfStage());
        
    }
    IEnumerator SpawnWaveOfStage(){
        
        for (int i = 0; i < _maxWave; i++)
        {
            
            _enableSpawn = false;
            StartCoroutine(SpawnSubWaveOfWave());
            yield return new WaitForSeconds(20f);
            _enableSpawn = true;
            GameControl.CurrentWave ++;
            if(_isCalledBoss == false && GameControl.CurrentWave + 1 == GameControl.MaxWave){
                _isCalledBoss = true;
                Spawner instance = new Spawner(_poolers[0],_gates[1]);
                instance.SpawnerSingleObject();
            }
        }
    }
    IEnumerator SpawnSubWaveOfWave(){
        int maxSubWave = Random.Range(2,5);
        for (int i = 0; i < maxSubWave; i++)
        {
            
            _enableSpawn = false;
            StartCoroutine(SpawnTurnOfWave());
            yield return new WaitForSeconds(_spawnWaveInterval);
            _enableSpawn = true;
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
     
    private void Update() {
        if(GameControl.CurrentWave == GameControl.MaxWave){
            _enableSpawn = false;
        }
        // ShowCallWaveButton();
    }
}
