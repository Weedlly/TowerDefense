using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour
{
    [SerializeField] private Animator _animatorFireRain;

    void Start()
    {
        _animatorFireRain.SetBool("isDeploySkill", true);
        Destroy(this.gameObject, 1f);
    }

    
    void Update()
    {
        
    }
}
