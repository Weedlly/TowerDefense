using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlace : MonoBehaviour
{
    // Start is called before the first frame update
    public Button _buildingButton;
    public Image _towerMenu;

    private bool _isOpenBuilding = false;
    void Start()
    {
        _buildingButton.onClick.AddListener(BuildingButtonHandle);
    }
    void BuildingButtonHandle(){
        _isOpenBuilding = _towerMenu.gameObject.activeSelf;
        if(_isOpenBuilding == false){
            _towerMenu.gameObject.SetActive(true);
        }
        else{
            _towerMenu.gameObject.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
    }
}
