using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSystem : MonoBehaviour
{
   
    [SerializeField] private  List<GameObject> _playerTypeInBattle;
    // [SerializeField] private  GameObject _bossTypeInBattle;
    [SerializeField] private  int _maxWave;
    [SerializeField] private  int _currentWave = 0;
    [SerializeField] private  int _maxSubwave;
    [SerializeField] private  int _currentSubwave = 0;
    [SerializeField] private  List<int> _numbers;
    private  List<LineRenderer> _gates;
    [SerializeField] private  RouteSet _routeSet;
    // [SerializeField] private Button _callWaveBt;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnWaveInterval;
    private bool _isCalledBoss = false;
    [SerializeField] private List<ObjectPooler> _poolers = new List<ObjectPooler>();



    private StageData _stageData;
    private WaveData _currentWaveData;
    private SubwaveData _currentSubwaveData;

    // private bool _enableSpawn = true;
    protected bool MappingStageData(int stageId, string difficultyType){
        _stageData = XMLControler._stageDataList.FindStageData(stageId);
        _maxWave = _stageData.waveList.Length;
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
        foreach (var wave in _stageData.waveList)
        {   
            _currentWaveData = wave;
            StartCoroutine(SpawnSubwaveOfWave());
            float totalTimeWave = _currentWaveData.GetTotalTimeWave(_spawnInterval) + _spawnWaveInterval;
            yield return new WaitForSeconds(totalTimeWave);
            
            
            // if(_isCalledBoss == false && GameControl.CurrentWave  == GameControl.MaxWave){
            //     _isCalledBoss = true;
            //     Spawner instance = new Spawner(_poolers[0],_gates[1]);
            //     instance.SpawnerSingleObject();
            // }
            if(GameControl.CurrentWave  < GameControl.MaxWave){
                GameControl.CurrentWave ++;
            }
        }
    }
    IEnumerator SpawnSubwaveOfWave(){
        for (int i = 0; i < _currentWaveData.subwaveList.Length; i++)
        {
            _currentSubwaveData = _currentWaveData.subwaveList[i];
            StartCoroutine(SpawnObjectOfSubwave());
            float timeNextSubwave = 0f;
            if( i + 1 < _currentWaveData.subwaveList.Length){
                timeNextSubwave = _currentWaveData.subwaveList[i+1].appearTime;
            }
            yield return new WaitForSeconds(timeNextSubwave);
        }
    }
    IEnumerator SpawnObjectOfSubwave(){
        int gateId = _currentSubwaveData.gateId;
        int numberObject =_currentSubwaveData.number;
        int typeObjectId = _currentSubwaveData.unitID;
        for (int i = 0; i < numberObject; i++)
        {
            SpawnObject(typeObjectId,_gates[gateId]);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    void SpawnObject(int type,LineRenderer gate){
        Spawner instance = new Spawner(_poolers[type],gate);
        instance.SpawnerSingleObject();
    }
    
}
