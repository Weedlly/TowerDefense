using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateAndSell : MonoBehaviour
{
    [SerializeField] private Button _controlButton;
    [SerializeField] private Button _updateButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _assembleButton;
    [SerializeField] private GameObject _currentTower;
    [SerializeField] private AssemblePoint _assemblePoint;




    // private bool _isOpenBuilding = false;
    // Start is called before the first frame update
    void Start()
    {
        _updateButton.onClick.AddListener(UpdateTower);
        _sellButton.onClick.AddListener(SellTower);
        _exitButton.onClick.AddListener(Exit);
        if(_assembleButton != null){
            _assembleButton.onClick.AddListener(AssemblePoint);
        }
    }

    void UpdateTower(){
        //update tower
        SetActive(false);
    }

    
    public void SellTower(){
       
        BuidingPlaceController.ActiveInstance(transform);
        
        SetActive(false);
        Destroy(_currentTower);
    }
    void Exit(){
        
        SetActive(false);
    }

    void AssemblePoint(){
        _assemblePoint._settingAssemblePoint = true;
        SetActive(false);
    }
    void SetActive(bool isActive){
        _controlButton.gameObject.SetActive(!isActive);
        this.gameObject.SetActive(isActive);
    }

}


