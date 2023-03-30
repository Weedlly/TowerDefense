using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuidingPlaceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _buildingPlaces;

    static List<Canvas> _buildingPlaceList = null;

    void Start(){
        _buildingPlaceList = new List<Canvas>(_buildingPlaces.GetComponentsInChildren<Canvas>()) ;
    }
    public static void ActiveInstance(Transform transform){
        Canvas tmp = null;
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

    public static void returnToBool(Canvas buildingPlace){
        buildingPlace.gameObject.SetActive(false);
    }
  
}
