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

    [SerializeField]
    private Text _currentHeathPoint;

    [SerializeField]
    private Text _currentCoinPoint;

    [SerializeField]
    private int _healthPointMax;

    [SerializeField]
    private int _coinPointMax;

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
    void GameOver(){
        if(_healthPoint <= 0){
            Debug.Log("GameOver");
        }
    }

}
