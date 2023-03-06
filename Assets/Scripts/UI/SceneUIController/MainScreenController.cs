using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenController : MonoBehaviour
{

    [SerializeField] GameObject _settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        _settingPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
