using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;



public class PlayerInformationBoard : MonoBehaviour {
    ///<summary>
    /// 
    ///</summary>
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _attackDameText;
    [SerializeField] private TMP_Text _attackSpeedText;
    [SerializeField] private TMP_Text _attackRangeText;
    [SerializeField] private TMP_Text _movementSpeedText;
    private static string _title;
    private static float _health;
    private static float _attackDame;
    private static float _attackSpeed;
    private static float _attackRange;
    private static float _movementSpeed;
    private void Update() {
        _titleText.text = _title;
        _healthText.text = _health.ToString();
        _attackDameText.text = _attackDame.ToString();
        _attackSpeedText.text= _attackSpeed.ToString();
        _attackRangeText.text = _attackRange.ToString();
        _movementSpeedText.text = _movementSpeed.ToString();
    }

    public static void UpdatePlayerBoardInformation(string playerName,float health,float attackDame, float attackSpeed, float attackRange,float movingSpeed){
        _title = playerName;
        _health = health;
        _attackDame = attackDame;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
        _movementSpeed = movingSpeed;
    }
}
