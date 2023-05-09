using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UserController: MonoBehaviour
{
    [SerializeField] TMP_Text _username;
    [SerializeField] TMP_Text _star;
    [SerializeField] TMP_Text _profileBtnText;
    [SerializeField] Image _expBar;
    [SerializeField] TMP_Text _level;
    User _user;

    void Awake(){
        _user = User.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _profileBtnText.text = UIString.Instance.profileBtnText;
    } 

     void updateExp(){
        ChampionData _curChamp = _user.GetChampionData(0);
        _level.text  = "LV: " + _curChamp.level.ToString();
        float progressVal = Mathf.Clamp01((float)_curChamp.currentExp / (float)_curChamp.expCap);
        _expBar.fillAmount = progressVal;
    }


    // Update is called once per frame
    void Update()
    {
          _username.text = _user.getUsername();
        _star.text = _user.getStar().ToString();
        updateExp();
    }
    
}
