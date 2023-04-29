using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> _maps;
    public void ActiveMap(int stageId)
    {
        for (int i = 0; i < _maps.Count; i++)
        {
            if (i + 1 == stageId)
            {
                _maps[i].SetActive(true);
            }
            else
            {
                _maps[i].SetActive(false);
            }
        }
    }
}
