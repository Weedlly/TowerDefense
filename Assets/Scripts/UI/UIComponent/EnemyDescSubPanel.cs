using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyDescSubPanel : MonoBehaviour {
    [SerializeField] int id;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _descTitle;
    [SerializeField] TMP_Text _desc;

    Description _unit;
    
    void Awake(){
        _unit = EnemyTowerDesc.Instance.GetEnemyDescription(id);
    }
    void Start(){
        _name.text = _unit.name;
        _descTitle.text = UIString.Instance.skillDescTitle;
        _desc.text = _unit.description;
    }
}