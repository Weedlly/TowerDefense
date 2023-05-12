using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelectController: MonoBehaviour
{
    User user;

    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;
    [SerializeField] private GameObject stage4;
    [SerializeField] private GameObject stage5;

    // Start is called before the first frame update
    void Awake()
    {
        user = User.Instance;
        
    } 

    void Start() {
        var count = user.getMaxAvailableStage();
        stage1.gameObject.SetActive(count >= 0);
        stage2.gameObject.SetActive(count >= 1);
        stage3.gameObject.SetActive(count >= 2);
        stage4.gameObject.SetActive(count >= 3);
        stage5.gameObject.SetActive(count >= 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}