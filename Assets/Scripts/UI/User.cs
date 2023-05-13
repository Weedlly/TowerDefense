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

    public bool saveUsername(string nUsername){
        if (_data.username != nUsername)
        {
            _data.username = nUsername;
            saveUserData();
        }
        return true;
    }

    public int getStar(){
        return _data.currentStar;
    }

    public void StageSuccess(int id, int star, DifficultyTypeEnum difficulty){
        CompletetedStageData newStage = getStageData(id,difficulty);
        if(newStage != null){
            if(star > newStage.star){
                UpdateStarOfStage(newStage,star);
                saveUserData();
                return;
            }
        }
        else{
            newStage = CreateNewCompletedStageData(id,star,difficulty);
            _data.currentStar += star;
            _data.completetedStageList.Add(newStage);
            saveUserData();
        }
        
    }
    void UpdateStarOfStage(CompletetedStageData stageData, int updateStar){
        int increStar = updateStar - stageData.star;
        stageData.star = updateStar;
        _data.currentStar += increStar;
    }
    private CompletetedStageData CreateNewCompletedStageData(int id, int star, DifficultyTypeEnum difficulty){
        CompletetedStageData newStage = new CompletetedStageData();
        newStage.completetedStageId = id;
        newStage.difficulty = difficulty.ToString();
        newStage.star = star;
        return newStage;
    }

    public CompletetedStageData getStageData(int id, DifficultyTypeEnum difficulty){
        if (_data.completetedStageList != null) 
            foreach (var i in _data.completetedStageList){
                if (i.completetedStageId == id && i.difficulty == difficulty.ToString()) return i;
            }
        return null;
    }

    public int getMaxAvailableStage() {
        int maxStage = -1;
        foreach (var stage in _data.completetedStageList)
        {
            int id = stage.completetedStageId;
            if(id > maxStage){
                maxStage = id;
            }
        }
        return maxStage;
    }

    public int getTowerLevelById(int id){
        if (_data.towerUpdateList != null)
            foreach (var i in _data.towerUpdateList){
                if (i.towerUpdateId == id) return i.level;
            }
        return 0;
    }

    public bool upgradeTowerById(int id){
        if (_data.currentStar > 0) {
            for(int i = 0; i < _data.towerUpdateList.Count; i++){
                if (_data.towerUpdateList[i].towerUpdateId == id && _data.towerUpdateList[i].level < levelCap) {
                    _data.towerUpdateList[i].level++;
                    _data.currentStar-= _data.towerUpdateList[i].level;//currency down
                    break;
                }
            }
            saveUserData();
            return true;
        }
        return false;
    }

    public ChampionData GetChampionData(int id){
        if (_data.championData != null)
            foreach(var i in _data.championData){
                if (i.championId == id) return i;
            }
        return null;
    }

    public bool UpdateChampionData(ChampionData nData){
        for(int i = 0; i < _data.championData.Count; i++){
            if (_data.championData[i].championId == nData.championId) {
                _data.championData[i] = nData;
                saveUserData();
                return true;
            }
        }
        return false;
    }
}
