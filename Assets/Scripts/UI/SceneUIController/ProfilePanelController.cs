using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ProfilePanelController : MonoBehaviour
{
    [SerializeField] TMP_Text _profileTitle;
    [SerializeField] TMP_Text _usernameTitle;
    [SerializeField] TMP_Text _saveBtnText;
    [SerializeField] TMP_Text _championBtnText;
    [SerializeField] TMP_InputField _username;

    [SerializeField] TMP_Text _heroName;
    [SerializeField] TMP_Text _heroLevel;
    [SerializeField] Image _heroExp;

    [SerializeField] TMP_Text _skillTitle;
    [SerializeField] TMP_Text _skillDescriptionTitle;
    [SerializeField] TMP_Text _skillDescription;
    private User _user;
    private ChampionData _curChamp;

    void Awake(){
        _user = User.Instance;
    }

    public void saveUsername(){
        string nUsername = _username.text;
        _user.saveUsername(nUsername);
    }

    public void loadSkillDescription(int skill){
        switch(skill)
        {
            case 1: _skillDescription.text = ChampionSkillDescription.Instance.skill1; return; 
        }
    }

    void Start()
    {
        _profileTitle.text = UIString.Instance.profileTitle;
        _usernameTitle.text = UIString.Instance.usernameTitle;
        _saveBtnText.text = UIString.Instance.saveBtnText;
        _championBtnText.text = UIString.Instance.championBtnText;
        _username.text = _user.getUsername();
        _curChamp = _user.getSelectedHero();
        _heroName.text = _curChamp.name;
        _heroLevel.text = "Lv: " + _curChamp.level.ToString();
        updateExp();
        _skillTitle.text = UIString.Instance.skillTitle;
        _skillDescriptionTitle.text = UIString.Instance.skillDescTitle;
        loadSkillDescription(1);
    }

    void updateExp(){
    
        float progressVal = Mathf.Clamp01(_curChamp.experiencePercent / 100f);
        Debug.Log(progressVal);
        _heroExp.fillAmount = progressVal;
    }

    void Update()
    {
        
    }
}