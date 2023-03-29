using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteSet : MonoBehaviour
{
    [SerializeField] private  List<LineRenderer> _gates;
    [SerializeField] private  SpriteRenderer sr;
    
    private static List<LineRenderer> gates;

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
                tmp.x = tmp.x * transform.localScale.x;
         
                tmp.y = tmp.y * transform.localScale.y;
                item.SetPosition(i,tmp);
            }
        }
        gates = _gates;
        return _gates;
    }
    public static Vector2 FindNearestPoint(Vector2 point){
        Vector2 nearstPoint = new Vector2(0f,0f);
        float dis = float.MaxValue;
        foreach (var item in gates)
        {
            for (int i = 0; i < item.positionCount; i++)
            {
                float tmpDis = Vector2.Distance(item.GetPosition(i),point);
                if(tmpDis< dis){
                    dis = tmpDis;
                    nearstPoint = item.GetPosition(i);;
                }
            }
        }
        return nearstPoint;
    }
}
