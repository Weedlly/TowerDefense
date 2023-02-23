using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image _healthBarImage;

    // [SerializeField]
    public float _maxHealth;

    public float CurrentHealth { set; get;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _healthBarImage.fillAmount = CurrentHealth /_maxHealth;
    }
}
