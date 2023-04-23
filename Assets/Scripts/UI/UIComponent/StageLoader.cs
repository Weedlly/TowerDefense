using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    [SerializeField] int _stageId;
    public void load(){
        GlobalValue.Instance.nextScene = 4;
        GlobalValue.Instance.stageId = _stageId;
        SceneManager.LoadScene(2);
    }
    
}
