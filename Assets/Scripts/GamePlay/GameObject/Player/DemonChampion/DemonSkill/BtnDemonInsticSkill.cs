using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDemonInsticSkill : MonoBehaviour
{
    [SerializeField] private Abilities _abilitySkill;

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
        _abilitySkill.SetAbility();   
    }
}
