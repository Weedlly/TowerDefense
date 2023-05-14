using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuidingPlaceController : MonoBehaviour
{
    /// <summary>
    /// 1) Mapping tower building places for each stage
    /// 2) Wirting tower building places of a stage down xml file
    /// 3) Control towerBuildingKit action ( active,deactive)
    /// </summary>

    [SerializeField] private GameObject _buildingPlaces;
    [SerializeField] private GameObject _towerBuildingPlacePrefab;
    [SerializeField] private  SpriteRenderer sr;
    private static Transform _parentTransform;
    private static GameObject towerBuildingPlacePrefab;
    public List<GameObject> buildingPlaceList = new List<GameObject>();
    public static List<GameObject> _buildingPlaceList = new List<GameObject>();

    void Start(){
        _parentTransform = gameObject.transform;
        towerBuildingPlacePrefab = _towerBuildingPlacePrefab;
        _buildingPlaceList = buildingPlaceList;
    }
    
    public static void ActiveInstance(Transform transform){
        GameObject tmp = null;
        float distance = float.MaxValue;
        foreach (var item in _buildingPlaceList)
        {
            float curDistance = Vector2.Distance(transform.position, item.transform.position);
                if(curDistance <= distance){
                    distance = curDistance;
                    tmp = item;
                }
        }
        if(tmp != null){
            tmp.gameObject.SetActive(true);
        }
    }

    public static void returnToBool(GameObject buildingPlace){
        buildingPlace.gameObject.SetActive(false);
    }

    public void MappingTowerPlaceData(int stageId){
        _buildingPlaceList.Clear();
        StageData tmpStageData = XMLControler._stageDataList.FindStageData(stageId);
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
       
        transform.localScale = new Vector3(
            worldScreenWidth  / (sr.sprite.bounds.size.x * sr.transform.localScale.x * transform.localScale.x),
            worldScreenHeight / (sr.sprite.bounds.size.y * sr.transform.localScale.y * transform.localScale.y), 1);

        foreach (var place in tmpStageData.towerPlaceList)
        {
            GameObject towerBuilding = Instantiate(towerBuildingPlacePrefab);
            towerBuilding.name = "BuildingContainer" + place.towerPlaceId;
            towerBuilding.transform.position = new Vector3(
                    place.x = place.x * transform.localScale.x,
                    place.y = place.y * transform.localScale.y,
                    0f
                );
            towerBuilding.transform.SetParent(_parentTransform);
            _buildingPlaceList.Add(towerBuilding);
        }
        buildingPlaceList = _buildingPlaceList;
    }
    public void WriteDownTowerPlaceSetForStage(int stageId){
        _buildingPlaceList = buildingPlaceList;
        StageData tmpStageData = XMLControler._stageDataList.FindStageData(stageId);
        tmpStageData.towerPlaceList.Clear();

        for (int i = 0; i < _buildingPlaceList.Count; i++)
        {
            if(_buildingPlaceList[i].activeSelf){
                TowerPlaceData tmpTL = new TowerPlaceData();
                tmpTL.towerPlaceId = i;
                tmpTL.x = _buildingPlaceList[i].transform.position.x;
                tmpTL.y = _buildingPlaceList[i].transform.position.y;
                tmpStageData.towerPlaceList.Add(tmpTL);
            }
        }
        XMLControler.WriteDownXML<StageListData>("StageWrite.xml",XMLControler._stageDataList);
    }
  
}
