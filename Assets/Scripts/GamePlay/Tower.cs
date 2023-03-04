using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float _rangeToFire;
    [SerializeField] protected int _towerPrice;
    [SerializeField] private Button _updateAndSelllButton;
    [SerializeField] private Image _updateAndSelllContainer;


    protected int _level;


    public static int _currentPrice;
 
    protected void Start()
    {
        _updateAndSelllButton.onClick.AddListener(OpenUpdateAndSell);
        SetTowerRange();
        SetupPrice();
    }
    void OpenUpdateAndSell(){
        _updateAndSelllButton.gameObject.SetActive(false);
        _updateAndSelllContainer.gameObject.SetActive(true);
    }

    void SetLevel(int level){
        _level = level;
    }

    public int GetTowerPrice(){
        return _towerPrice;
    }

    void SetupPrice(){
        _currentPrice = _towerPrice;
    }
    

    protected void SetTowerRange(){
        CircleCollider2D instance = GetComponent<CircleCollider2D>();
        instance.radius = _rangeToFire;
    }




}
