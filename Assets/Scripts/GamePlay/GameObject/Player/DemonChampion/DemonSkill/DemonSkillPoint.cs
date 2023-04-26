using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonSkillPoint : MonoBehaviour
{
    [SerializeField] private DemonChampion _champion;
    void Start()
    {
       
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickToMovingDemon); 
    }

    
    void Update()
    {
       
    }

    public void  ClickToMovingDemon()
    {
        _champion.StopAttacking();
        _champion.SetMovement();
    }
}
