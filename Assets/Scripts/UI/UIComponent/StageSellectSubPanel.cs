using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSellectSubPanel : MonoBehaviour {
    [SerializeField] int _stageId;
    [SerializeField] Image _star1;
    [SerializeField] Image _star2;
    [SerializeField] Image _star3;

    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _startBtn;

    void stageInfoUpdate()
    {
        CompletetedStageData stage = User.Instance.getStageData(_stageId);
        _star3.gameObject.SetActive(false);
        _star2.gameObject.SetActive(false);
        _star1.gameObject.SetActive(false); 
        if (stage != null)
        {    
            var star = stage.star;
            if (star >= 1) _star1.gameObject.SetActive(true);
            if (star >= 2) _star2.gameObject.SetActive(true);
            if (star == 3) _star3.gameObject.SetActive(true); 
        }
    }

    void Start() 
    {
        // _stageId = GlobalValue.Instance.stageId;
        // stageInfoUpdate();
        _startBtn.text = UIString.Instance.startBtnText;
    }

    void OnEnable() {
        _stageId = GlobalValue.Instance.stageId;
        _title.text = UIString.Instance.stageText + " " +  (_stageId + 1).ToString(); 
        stageInfoUpdate();
    }


    public void loadStage()
    {
        GlobalValue.Instance.nextScene = 4;
        SceneManager.LoadScene(2);
    }


}