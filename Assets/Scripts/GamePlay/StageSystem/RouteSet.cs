using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteSet : MonoBehaviour
{
    [SerializeField] private  List<LineRenderer> _gates;
    [SerializeField] private  SpriteRenderer sr;
    
    public List<LineRenderer> GetGates(){

        float worldScreenHeight = Camera.main.orthographicSize * 2;

        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
       
        transform.localScale = new Vector3(
            worldScreenWidth  / (sr.sprite.bounds.size.x * sr.transform.localScale.x * transform.localScale.x),
            worldScreenHeight / (sr.sprite.bounds.size.y * sr.transform.localScale.y * transform.localScale.y), 1);
        foreach (var item in _gates)
        {
            for (int i = 0; i < item.positionCount; i++)
            {
                Vector3 tmp = item.GetPosition(i);
                tmp.x = tmp.x / transform.localScale.x;
         
                tmp.y = tmp.y / transform.localScale.y;
                item.SetPosition(i,tmp);
            }
        }
        return _gates;
    }
}
