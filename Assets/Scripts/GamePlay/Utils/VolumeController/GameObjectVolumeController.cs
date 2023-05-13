using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectVolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Update()
    {
        ChangeVolume();
    }
    private void ChangeVolume(){
        if(VolumeController.GameObjectMusic == true){
            audioSource.volume = 100;
        }
        else{
            audioSource.volume = 0;
        }
    }
}
