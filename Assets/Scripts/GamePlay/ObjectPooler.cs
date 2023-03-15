using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _pool = new List<GameObject>();
    // [SerializeField] private GameObject _poolContainer;
   
    // public void SetUpObjectPooler(GameObject prefab, int poolSize){
    //     _prefab = prefab;
    //     _poolSize = poolSize;
    // }
    // public void CreatePoolerContainer(){
    //     _pool = new List<GameObject>();
    //     _poolContainer = new GameObject($"Pool - {_prefab.name}");
    //     CreatePooler();
    // }
    private void Awake(){        
        // _poolContainer = new GameObject($"Pool - {_prefab.name}");
        CreatePooler();
    }
    private void CreatePooler(){
        for (int i = 0; i < _poolSize; i++)
        {
            _pool.Add(CreateInstance());   
        }
    }
    private GameObject CreateInstance(){
        GameObject newInstance = Instantiate(_prefab);
       
        newInstance.transform.SetParent(transform);
        newInstance.SetActive(false);
        return newInstance;
    }
    public GameObject GetInstanceFromPool(){
        for (int i = 0; i < _pool.Count; i++)
        {
            if(!_pool[i].activeInHierarchy){
                _pool[i].transform.position = _prefab.transform.position;
                return _pool[i];
            }
        }
        return CreateInstance();
    }
    // Update is called once per frame
    public static void ReturnToPool(GameObject instance){
        instance.SetActive(false);
        
    }
    public static IEnumerator ReturnToPoolWithDelay(GameObject instance,float delay){
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);

    }
}
