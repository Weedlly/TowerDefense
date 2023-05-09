using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    /// <summary>
    /// 1) Control Coin, health of User in a stage
    /// 2) Deterimine condition when User win or loss a game
    /// </summary>
   
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

    [SerializeField] private GameObject _defeatContainer;
    [SerializeField] private GameObject _winContainer;

    [SerializeField] GameObject _threeStart;
    [SerializeField] GameObject _twoStart;
    [SerializeField] GameObject _oneStart;
    [SerializeField] GameObject _championObj;

    private StageRating _stageRating;

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
        _stageRating = new StageRating(_oneStart,_twoStart,_threeStart);
        Time.timeScale = 1;
        _healthPoint = _healthPointMax;
        _coinPoint = _coinPointMax;
    }
    
    void Update()
    {
        _currentHeathPoint.text = _healthPoint.ToString();
        _currentCoinPoint.text = _coinPoint.ToString();
        _waveCount.text = WaveFormat();

        CheckDefeat();
        CheckWinning();
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
    void CheckDefeat(){
        if(_healthPoint <= 0){
            PlayDefeat();
        }
    }
    void PlayDefeat(){
        Time.timeScale = 0;
        _defeatContainer.SetActive(true);
    }

    void SaveChampionStat() //khoi update
    {
        DemonChampion state = (DemonChampion) _championObj.GetComponent(typeof(DemonChampion));
        ChampionData cData = state.GetChampionState();
        User.Instance.UpdateChampionData(cData);
    }

    void CheckWinning(){
        if(_currentWave == _maxWave){
            if(GameObject.FindWithTag("Human") == null){
                int stageId = GlobalValue.Instance.stageId;
                int starts = _stageRating.GetRatingStar(_healthPoint,_healthPointMax);
                DifficultyTypeEnum diff = GlobalValue.Instance.StageDifficulty;
                User.Instance.StageSuccess(stageId,starts,diff);
                SaveChampionStat(); //khoi update 
                PlayWinning();
            }
        }
    }
    void PlayWinning(){
        Time.timeScale = 0;
        _winContainer.SetActive(true);
    }

}
