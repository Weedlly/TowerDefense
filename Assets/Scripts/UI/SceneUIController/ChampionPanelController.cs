using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ChampionPanelController : MonoBehaviour {
    [SerializeField] TMP_Text _championTitle; 
    [SerializeField] TMP_Text _saveBtnText;
    [SerializeField] TMP_Text _heroName;
    [SerializeField] TMP_Text _heroLevel;
    [SerializeField] TMP_Text _skillTitle;
    [SerializeField] TMP_Text _skillDescriptionTitle;
    [SerializeField] TMP_Text _skillDescription;

    [SerializeField] TMP_Text _statTitle;
    [SerializeField] TMP_Text _stat;
    private User _user;
    private ChampionData _curChamp;

    void Awake(){
        _user = User.Instance;
    }

    public void loadSkillDescription(int skill){
        switch(skill)
        {
            case 1: _skillDescription.text = ChampionSkillDescription.Instance.skill1; return; 
        }
    }

    public void statLoad(int id){
        _stat.text = "Atk: " + _curChamp.attackDamage.ToString() + "\nAtk spd: " + _curChamp.attackSpeed.ToString() + "\nHp: " + _curChamp.health.ToString();
    }

    void Start()
    {
        _championTitle.text = UIString.Instance.championTitle;
        _saveBtnText.text = UIString.Instance.saveBtnText;
        _curChamp = _user.GetChampionData(0);
        _heroName.text = _curChamp.name;
        _heroLevel.text = "Lv: " + _curChamp.level.ToString();
        _skillTitle.text = UIString.Instance.skillTitle;
        _skillDescriptionTitle.text = UIString.Instance.skillDescTitle;
        loadSkillDescription(1);
        _statTitle.text = UIString.Instance.statTitle;
        statLoad(1);

    }
}