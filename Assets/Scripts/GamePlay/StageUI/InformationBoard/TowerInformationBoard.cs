using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class TowerInformationBoard : MonoBehaviour {
    ///<summary>
    /// 
    ///</summary>
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _attackDameText;
    [SerializeField] private TMP_Text _attackSpeedText;
    [SerializeField] private TMP_Text _attackRangeText;

    private static string _title;
    private static float _attackDame;
    private static float _attackSpeed;
    private static float _attackRange;
    private void Update() {
        _titleText.text = _title;
        _attackDameText.text = _attackDame.ToString();
        _attackSpeedText.text = _attackSpeed.ToString();
        _attackRangeText.text = _attackRange.ToString();
    }
    public static void UpdateTowerBoardInformation(string towerName,float attackDame, float attackSpeed, float attackRange){
        _title = towerName;
        _attackDame = attackDame;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
    }
}
