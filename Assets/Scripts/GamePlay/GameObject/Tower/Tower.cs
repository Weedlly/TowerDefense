using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour,IInformationToBoard
{
    [Header("Tower attribute")]
    [SerializeField] public int _towerId;
    [SerializeField] public string _name;
    [SerializeField] public float _attackSpeed;
    [SerializeField] public float _attackDame;
    [SerializeField] public float _attackRange;
    [SerializeField] public float _health;
    [SerializeField] public int _price;
    [SerializeField] public int _sellPrice;
    [SerializeField] public int _level;


    [SerializeField] protected Button _controlButton;
    [SerializeField] protected Image _updateAndSelllContainer;


    
    public int Level{
        get{
            return _level;
        }
        set{
            _level = value;
        }
    }
    public int Price{
        get{
            return _price;
        }
        set{
            _price = value;
        }
    }
    public int SellPrice{
        get{
            return _sellPrice;
        }
        set{
            _sellPrice = value;
        }
    }
    
    protected void Start()
    {
        _controlButton.onClick.AddListener(OpenUpdateAndSell);
        MapTowerData(_towerId,_level);
    }
    void OpenUpdateAndSell(){
        _controlButton.gameObject.SetActive(false);
        _updateAndSelllContainer.gameObject.SetActive(true);
    }

    public bool IsAbleUpdateTower(){
        if(_level < 2){
            return true;
        }
        return false;
    }
    public void UpdateTower(){
        MapTowerData(_towerId,++_level);
    }

    protected bool MapTowerData(int id, int level){
        TowerData towerData = XMLControler._towerDataList.FindTowerData(id,level);
        if(towerData != null){
            _name = towerData.name;
            _attackDame = towerData.attackDame;
            _attackSpeed = towerData.attackSpeed;
            _attackRange = towerData.attackRange;
            _health = towerData.health;
            _price = towerData.price;
            _sellPrice +=(int)(_price * 0.3f);
            User userData = User.Instance;
            int levelUpdate = userData.getTowerLevelById(id);
            UpdateTree updateTree = new UpdateTree();
            if(id != 3){
                updateTree.ApplyTroopTowerUpdateTreeBranchUpdate(this,levelUpdate);
            }
            else{
                updateTree.ApplyWeaponTowerUpdateTreeBranchUpdate(this,levelUpdate);
            }
            return true;
        }

        return false;
    }

    protected void Update(){}
    public void SendInformation(){
          TowerInformationBoard.UpdateTowerBoardInformation(_name,_attackDame,_attackSpeed,_attackRange);
    }

}
