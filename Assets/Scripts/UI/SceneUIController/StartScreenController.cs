using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] GameObject _languagePanel;
    [SerializeField] GameObject _newsPanel;

    [SerializeField] TMP_Text _startBtn;

    // Start is called before the first frame update
    void Start()
    {
        _languagePanel.gameObject.SetActive(false);
        _newsPanel.gameObject.SetActive(false);

        _startBtn.text = UIString.Instance.startBtnText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
