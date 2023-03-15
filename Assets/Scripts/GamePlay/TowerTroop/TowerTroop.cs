using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTroop : Tower
{
    [SerializeField] private int _numberEvils;
    // [SerializeField] private float _allyAttackRange;
    // [SerializeField] private float _allyAttackSpeed;
    // [SerializeField] private float _allyHealth;
    // [SerializeField] private float _allyDame;
    [SerializeField] private Evil _prefab;
    [SerializeField] private List<Evil> _evils = new List<Evil>();
    
    [SerializeField] private GameObject _assemblePoint;

    public float _timeRevive = 5f;
    

    public bool _settingAssemblePoint = false;
   
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Debug.Log(_prefab);
        InitEvil();
        SetEvilAssemblePoint();
        _assemblePoint.transform.position = transform.position;
    }
    void SetEvilAssemblePoint(){
        for (int i = 0; i < _evils.Count; i++)
        {
            _evils[i]._assemblePoint =  new Vector2(
                _assemblePoint.transform.position.x + Random.value * 2,
                _assemblePoint.transform.position.y + Random.value * 2
            );
        }
    }
  
    void InitEvil(){
        
        for (int i = 0; i < _numberEvils; i++)
        {
            _evils.Add(Instantiate(_prefab));
            _evils[i].transform.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(_settingAssemblePoint == true){
            SetAssemblePoint();
        }
        RunReviveProcess();

    }


    void RunReviveProcess(){
        foreach (var item in _evils)
        {
            if(item._isDie == true){
                item._timeReviveCounter -= Time.deltaTime;
            }
            if(item._timeReviveCounter <= 0){
                SetupAfterRevive(item);
            }
        }
    }
  
    void SetupAfterRevive(Evil evil){
        
        evil.gameObject.SetActive(true);
        evil._isDie = false;
        evil._timeReviveCounter = _timeRevive;
        evil.transform.position = transform.position;
        BattleControler.AddEvil(evil);
    }
    
    private void SetAssemblePoint(){
        // Debug.Log(curMousePoint);
        if (Input.GetMouseButton(0))
        {
            Vector2 curMousePoint =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(Vector2.Distance(transform.position,curMousePoint) < _rangeToFire){
                _assemblePoint.transform.position = curMousePoint;
                _settingAssemblePoint = false;
                SetEvilAssemblePoint();
                Debug.Log(curMousePoint);
            }
        }
        
    }
}
