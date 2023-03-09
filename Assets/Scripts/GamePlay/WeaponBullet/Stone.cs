using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : WeaponBullet
{
    // Start is called before the first frame update
    [SerializeField]
    private float _rangeExplore;
    private bool _isExplored = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    public override void Hitting()
    {
        

        if(_isExplored == false){
            DameByExplored();
        }

        _isExplored = true;
        _animator.SetBool("isExplored",_isExplored);
        Destroy(this.gameObject,0.4f);
    }

    private void DameByExplored(){
        GameObject[] instanceList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in instanceList)
        {
            Enemy enemy = item.GetComponent<Enemy>();
            if(Vector2.Distance(enemy.transform.position,transform.position) < _rangeExplore){
                enemy._health -= _dame;
            }
            if(enemy._health <= 0f){
                enemy.SelfDestroy();
            }
        }
    }
}
