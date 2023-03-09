using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTroop : Tower
{
    [SerializeField] private int _numberAllys;
    // [SerializeField] private float _allyAttackRange;
    // [SerializeField] private float _allyAttackSpeed;
    // [SerializeField] private float _allyHealth;
    // [SerializeField] private float _allyDame;
    [SerializeField] private AllyMelee _prefab;
    [SerializeField] private List<AllyMelee> _allies;
    
    [SerializeField] private GameObject _assemblePoint;

    public float _timeRevive = 5f;
    

    public bool _settingAssemblePoint = false;
   
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        InitAlly();
        SetAllyAssemblePoint();
        _assemblePoint.transform.position = transform.position;
    }
    void SetAllyAssemblePoint(){
        for (int i = 0; i < _allies.Count; i++)
        {
            _allies[i]._assemblePoint =  new Vector2(
                _assemblePoint.transform.position.x + Random.value * 2,
                _assemblePoint.transform.position.y + Random.value * 2
            );
        }
    }
  
    void InitAlly(){
        _allies = new List<AllyMelee>();
        for (int i = 0; i < _numberAllys; i++)
        {
            _allies.Add(Instantiate(_prefab));
            _allies[i].transform.position = transform.position;
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
        foreach (var item in _allies)
        {
            if(item._isDie == true){
                item._timeReviveCounter -= Time.deltaTime;
            }
            if(item._timeReviveCounter <= 0){
                SetupAfterRevive(item);
            }
        }
    }
  
    void SetupAfterRevive(Ally ally){
        ally.gameObject.SetActive(true);
        ally._isDie = false;
        ally._health = 50f;
        ally._timeReviveCounter = _timeRevive;
        ally.transform.position = transform.position;
    }
    
    private void SetAssemblePoint(){
        // Debug.Log(curMousePoint);
        if (Input.GetMouseButton(0))
        {
            Vector2 curMousePoint =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(Vector2.Distance(transform.position,curMousePoint) < _rangeToFire){
                _assemblePoint.transform.position = curMousePoint;
                _settingAssemblePoint = false;
                SetAllyAssemblePoint();
                Debug.Log(curMousePoint);
            }
        }
        
    }
}
