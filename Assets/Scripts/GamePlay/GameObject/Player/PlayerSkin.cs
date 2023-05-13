using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerSkin : MonoBehaviour {
    [SerializeField] private List<AnimatorController> _animatorControllers;
    public bool ChangingSkin(Animator animator,int skinOrder){
        if(skinOrder < _animatorControllers.Count){
            animator.runtimeAnimatorController = _animatorControllers[skinOrder];
            return true;
        }
        return false;
    }
}