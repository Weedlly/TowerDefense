using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonOnClick : MonoBehaviour
{
    [SerializeField] private DemonChampion _champion;

    //private bool _stateMove = false;

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
        _champion.SetMovement();
    }
}
