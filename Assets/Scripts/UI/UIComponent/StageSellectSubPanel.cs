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
    [SerializeField] TMP_Text _curDiffText;

    [SerializeField]  DifficultyTypeEnum _curDiff;
    [SerializeField] Image normalSelect;
    [SerializeField] Image hardSelect;
    [SerializeField] Image hellSelect;


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
            _curDiffText.text = "~~ < " + stage.difficulty + " > ~~";
        }
        else {
             _curDiffText.text = "~~ < " + "None" + " > ~~";
        }
         
    }

    public void normalDiffSelect(){
        normalSelect.gameObject.SetActive(true);
        hardSelect.gameObject.SetActive(false);
        hellSelect.gameObject.SetActive(false);
        _curDiff = DifficultyTypeEnum.Normal;
    }

    public void hardDiffSelect(){
        normalSelect.gameObject.SetActive(false);
        hardSelect.gameObject.SetActive(true);
        hellSelect.gameObject.SetActive(false);
        _curDiff = DifficultyTypeEnum.Nightmare;
    }

    public void hellDiffSelect(){
        normalSelect.gameObject.SetActive(false);
        hardSelect.gameObject.SetActive(false);
        hellSelect.gameObject.SetActive(true);
        _curDiff = DifficultyTypeEnum.Hell;
    }

    void Start() 
    {
        // _stageId = GlobalValue.Instance.stageId;
        // stageInfoUpdate();
        _startBtn.text = UIString.Instance.startBtnText;
        normalDiffSelect();
    }

    void OnEnable() {
        _stageId = GlobalValue.Instance.stageId;
        _title.text = UIString.Instance.stageText + " " +  (_stageId).ToString(); 
        stageInfoUpdate();
    }


    public void loadStage()
    {
        GlobalValue.Instance.nextScene = 4;
        GlobalValue.Instance.StageDifficulty = _curDiff;
        SceneManager.LoadScene(2);
    }


}