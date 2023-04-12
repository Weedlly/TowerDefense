using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;



public enum InformationBoard{
    TowerBoard,
    PlayerBoard,
    none
}

public class InformationBoardControl : MonoBehaviour
{
    ///<summary>
    /// Control Which information board should be show 
    /// In one time just have only one board will be show
    ///</summary>

    [SerializeField] private GameObject _towerInformationBoard;
    [SerializeField] private GameObject _playerInformationBoard;
    // private static GameObject _towerBoard;
    // private static GameObject _playerBoard;

    public EventSystem _eventSystem;

    void Start()
    {      
        Debug.Log(SystemInfo.deviceUniqueIdentifier);
        // _towerBoard = _towerInformationBoard;
    }
    
    void Update()
    {

        if(_eventSystem.currentSelectedGameObject != null){
            GameObject go = _eventSystem.currentSelectedGameObject;
            // go.transform.parent.gameObject.GetComponent<Tower>(); 
            Debug.Log(go.transform.parent.gameObject.GetComponentInChildren<Tower>());

            CheckObjectHasInformationBoard(go);
        }else{
            ActiveBoard(InformationBoard.none);
        }
        // else{
        //     CheckObjectHasInformationBoard();
        // }

        
        
   
    }

    private void CheckObjectHasInformationBoard(GameObject go){
        if((Player)go.gameObject.GetComponent<Player>() != null){
            Debug.Log((Player)_eventSystem.currentSelectedGameObject.gameObject.GetComponent<Player>());
            ((Player)go.gameObject.GetComponent<Player>()).SendInformation();
            ActiveBoard(InformationBoard.PlayerBoard);
        }
        else if((Tower)go.transform.parent.gameObject.GetComponentInChildren<Tower>() != null){
            Debug.Log((Tower)_eventSystem.currentSelectedGameObject.gameObject.GetComponent<Tower>());
            ((Tower)go.transform.parent.gameObject.GetComponentInChildren<Tower>()).SendInformation();
            ActiveBoard(InformationBoard.TowerBoard);
        }
        else{
            ActiveBoard(InformationBoard.none);
        }
    }
    void ActiveBoard(InformationBoard activeBoard ){
        switch (activeBoard)
        {
            case InformationBoard.TowerBoard:{
                _towerInformationBoard.gameObject.SetActive(true);
                _playerInformationBoard.gameObject.SetActive(false);
                break;
            } 
            case InformationBoard.PlayerBoard:{
                _towerInformationBoard.gameObject.SetActive(false);
                _playerInformationBoard.gameObject.SetActive(true);
                break;
            } 
            default:{
                _towerInformationBoard.gameObject.SetActive(false);
                _playerInformationBoard.gameObject.SetActive(false);
                break;
            }
        }
    }
    // public static void ShowTroopInformation(float attackDame, float attackSpeed, float attackRange){
    //     // _attackDame = attackDame;
    //     // _attackSpeed = attackSpeed;
    //     // _attackRange = attackRange;
    //     // _towerBoard.SetActive(true);
    // }
    // public static void HideTowerInformation(){
    //     _towerBoard.SetActive(false);
    // }
   
}
