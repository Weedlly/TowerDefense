using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDemonInsticSkill : MonoBehaviour
{
    [SerializeField] private DemonSkill _champSkill;
    

    void Start()
    {  
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickToDeploySkill);        
    }

    void Update()
    {
        
    }

    public void ClickToDeploySkill()
    {
        _champSkill.setDeploySkill();         
    }
}
