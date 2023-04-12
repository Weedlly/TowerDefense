using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _healthBarImage;
    [SerializeField] private Canvas _healthObject;
    public float _maxHealth;

    private float _currentHealth;
    public float CurrentHealth
    { 
        get{
            return _currentHealth;
        }
        set{
            if(value < _currentHealth){
                StartCoroutine(ShowHeathObject());
            }
            _currentHealth = value;
        }
    }

    IEnumerator ShowHeathObject(){
        _healthObject.overrideSorting = true;
        _healthObject.sortingLayerName = "GameObject";
        yield return new WaitForSeconds(3f);
        _healthObject.sortingLayerName = "Invisible";
    }
    
    void Start()
    {
    }
    void Update()
    {
        _healthBarImage.fillAmount = CurrentHealth /_maxHealth;
    }
}
