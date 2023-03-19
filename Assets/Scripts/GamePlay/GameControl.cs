using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
   
    private static int _healthPoint;
    private static int _coinPoint;
    private static int _currentWave ;
    private static int _maxWave;

    [SerializeField] private Text _currentHeathPoint;
    [SerializeField] private Text _currentCoinPoint;
    [SerializeField] private Text _waveCount;

    [SerializeField] private int _healthPointMax;
    [SerializeField] private int _coinPointMax;  
    [SerializeField] private string _wave;

    public static int CurrentWave 
    { 
        get {
            return _currentWave;
            } 
        set {
            _currentWave = value;
        }
    }
    public static int MaxWave 
    { 
        get{ return _maxWave;}
        set {
            _maxWave = value;
        }
    }



    void Start()
    {
        // SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        // SceneManager.SetActiveScene(
        //     SceneManager.GetSceneByName("SampleScene")
        // );
        
        _healthPoint = _healthPointMax;
        _coinPoint = _coinPointMax;
    }

    // Update is called once per frame
    void Update()
    {
        _currentHeathPoint.text = _healthPoint.ToString();
        _currentCoinPoint.text = _coinPoint.ToString();
        _waveCount.text = WaveFormat();
        GameOver();
    }
    public static void ReduceHealth(){
        _healthPoint--;
    }
    public static bool CoinIsEnough(int coin){
        if(_coinPoint - coin < 0){
            return false;
        }
        return true;
    }

    public static void DecreaseCoin(int coin){
        if(CoinIsEnough(coin) == true) _coinPoint-=coin;
    }
    public static void IncreaseCoin(int coin){
        _coinPoint+=coin;
    }
    string WaveFormat(){
        return _currentWave.ToString() + "/" + _maxWave.ToString();
    }
    void GameOver(){
        if(_healthPoint <= 0){
            Debug.Log("GameOver");
        }
    }

}
