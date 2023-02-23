using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTroop : Tower
{
    [SerializeField] private int _numberAllys;
    [SerializeField] private float _allyAttackRange;
    [SerializeField] private float _allyAttackSpeed;
    [SerializeField] private float _allyHealth;
    [SerializeField] private float _allyDame;
    [SerializeField] private Ally _prefab;
    [SerializeField] private List<Ally> _allyList;
    
    [SerializeField] private GameObject _assemblePoint;

    public bool _settingAssemblePoint = false;
   
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        InitTroop();
        SetTroopAssemblePoint();
        _assemblePoint.transform.position = transform.position;
    }
    void SetTroopAssemblePoint(){
        for (int i = 0; i < _allyList.Count; i++)
        {
            _allyList[i]._assemblePoint =  new Vector2(
                    _assemblePoint.transform.position.x + Random.value * 2,
                    _assemblePoint.transform.position.y + Random.value * 2
                );
        }
    }
    void InitTroop(){
        _allyList = new List<Ally>();
        for (int i = 0; i < _numberAllys; i++)
        {
            _allyList.Add(Instantiate(_prefab));
            _allyList[i].transform.position = transform.position;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(_settingAssemblePoint == true){
            SetAssemblePoint();
       }

    }

    private void SetAssemblePoint(){
        // Debug.Log(curMousePoint);
        if (Input.GetMouseButton(0))
        {
            Vector2 curMousePoint =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(Vector2.Distance(transform.position,curMousePoint) < _rangeToFire){
                _assemblePoint.transform.position = curMousePoint;
                _settingAssemblePoint = false;
                SetTroopAssemblePoint();
                Debug.Log(curMousePoint);
            }
        }
        
    }
}
