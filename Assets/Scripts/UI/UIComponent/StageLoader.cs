using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    [SerializeField] int _stageId;
    public void updateStageId(){
        GlobalValue.Instance.stageId = _stageId;
        GlobalValue.Instance.StageDifficulty = DifficultyTypeEnum.Normal;
        //SceneManager.LoadScene(2);
    }

    [SerializeField] Image _star1;
    [SerializeField] Image _star2;
    [SerializeField] Image _star3;

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

    void Awake() {
        User _user = User.Instance;
    }

    void Start() {
        
        stageInfoUpdate();
    }
    
}
