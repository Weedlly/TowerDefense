using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Singleton<User>
{
    private UserData _data = XMLControler._userData;
    private int levelCap = 2;
    
    void Start(){
        // Debug.Log("User start");
        loadUserData();
        // Debug.Log(getUsername());
        // _data = XMLControler._userData;
    }

    public void saveUserData(){
        XMLControler.LocalWriteXML<UserData>("User.xml", _data);
    }

    public void loadUserData(){
        _data = XMLControler.LocalLoadXML<UserData>("User.xml");     
        // _data = XMLControler.LoadXML<UserData>("XML/User"); 
    }

    public void generateUserData(){
        Debug.Log("generating...");
        _data = XMLControler.LoadXML<UserData>("XML/User");
        saveUserData();
    }

    public string getUsername(){
        return _data.username;
    }

    public int getStar(){
        return _data.currentStar;
    }

    public void StageSuccess(int id, int star, GameObjectEnum.DifficultyTypeEnum difficulty){
        for(int i = 0; i <=  _data.completetedStageList.Count; i++){
            if (_data.completetedStageList[i].completetedStageId == id){
                _data.completetedStageList[i].difficulty = difficulty.ToString();
                if (_data.completetedStageList[i].star < star){
                    _data.currentStar += star - _data.completetedStageList[i].star;
                    _data.completetedStageList[i].star = star;
                }
                //saveUserData();
                return;
            }
        }
        CompletetedStageData newStage = new CompletetedStageData();
        newStage.completetedStageId = id;
        newStage.difficulty = difficulty.ToString();
        newStage.star = star;
        _data.currentStar +=  star;
        _data.completetedStageList.Add(newStage);
        //saveUserData();

    }

    public CompletetedStageData getStageData(int id){
        foreach (var i in _data.completetedStageList){
            if (i.completetedStageId == id) return i;
        }
        return null;
    }

    public int getTowerLevelById(int id){
        foreach (var i in _data.towerUpdateList){
            if (i.towerUpdateId == id) return i.level;
        }
        return 0;
    }

    public bool upgradeTowerById(int id){
        if (_data.currentStar > 0) {
            for(int i = 0; i < _data.towerUpdateList.Count; i++){
                Debug.Log(i);
                if (_data.towerUpdateList[i].towerUpdateId == id && _data.towerUpdateList[i].level < levelCap) {
                    _data.towerUpdateList[i].level++;
                    break;
                }
            }
            saveUserData();
            return true;
        }
        return false;
    }
}
