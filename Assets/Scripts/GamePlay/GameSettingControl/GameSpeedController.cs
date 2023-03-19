using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeGameSpeed(){
        switch(GameControler.GAME_SPEED){
            case (float)GameSpeed.Default:{
                GameControler.GAME_SPEED = (float)GameSpeed.Double;
                // this.gameObject.text = "x2";
                break;
            }
            case (float)GameSpeed.Double:{
                GameControler.GAME_SPEED = (float)GameSpeed.Default;
                break;
            }
        }
        Time.timeScale = GameControler.GAME_SPEED;
    }
}
