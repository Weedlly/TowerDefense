using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Update()
    {
        ChangeVolume();
    }
    private void ChangeVolume(){
        if(VolumeController.BackGroundMusic == true){
            audioSource.volume = 44;
        }
        else{
            audioSource.volume = 0;
        }
    }
}
