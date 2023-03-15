using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSystem : MonoBehaviour
{
   
    [SerializeField] private  List<GameObject> _playerTypeInBattle;
    [SerializeField] private  int _waveCount;
    [SerializeField] private  List<int> _numbers;
    [SerializeField] private  List<LineRenderer> _gates;
    
    [SerializeField] private Button _callWaveBt;

    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnWaveInterval;

    [SerializeField] private List<ObjectPooler> _poolers = new List<ObjectPooler>();

    // private int _currentWave = 0;
    private bool _enableSpawn = true;
    private void Start() {
        _callWaveBt.onClick.AddListener(CallWave);
    }
   
    void ShowCallWaveButton(){
        if(_enableSpawn == false){
            _callWaveBt.gameObject.SetActive(false);
        }
        else {
            _callWaveBt.gameObject.SetActive(true);
        }
    }
    void CallWave(){
        StartCoroutine(SpawnWaveOfStages());
    }
    IEnumerator SpawnWaveOfStages(){
        int numberWave = Random.Range(2,6);
        for (int i = 0; i < numberWave; i++)
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
            int type = Random.Range(0,2);
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
        ShowCallWaveButton();
    }
}
