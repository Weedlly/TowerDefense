using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageRating
{
    private GameObject _threeStart;
    private GameObject _twoStart;
    private GameObject _oneStart;
    public StageRating(GameObject oneStart,GameObject twoStart,GameObject threeStart){
        _threeStart = threeStart;
        _twoStart = twoStart;
        _oneStart = oneStart;
    }
    bool IsOneStarCondition(int currentHealthPoint, int healthPointMax){
        if(currentHealthPoint < 0.5 * healthPointMax){
            _oneStart.SetActive(true);
            return true;
        }
        return false;
    }
    bool IsTwoStarCondition(int currentHealthPoint, int healthPointMax){
        if(currentHealthPoint < 0.7 * healthPointMax){
             _twoStart.SetActive(true);
            return true;
            
        }
        return false;
    }
    bool IsThreeStarCondition(int currentHealthPoint, int healthPointMax){
        if(currentHealthPoint == healthPointMax){
             _threeStart.SetActive(true);
            return true;
        }
        return false;
    }
 
    public int GetRatingStar(int currentHealthPoint, int healthPointMax){
        if(IsOneStarCondition(currentHealthPoint,healthPointMax)){
            return 1;
        }
        else if(IsTwoStarCondition(currentHealthPoint,healthPointMax)){
            return 2;
        }
        else if(IsThreeStarCondition(currentHealthPoint,healthPointMax)){
            return 3;
        }
        return 0;
    }
}