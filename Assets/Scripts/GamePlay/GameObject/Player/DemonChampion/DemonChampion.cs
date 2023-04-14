using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonChampion : Evil
{
    Vector2 lastClickedPos;
    bool moving;

    public static bool _isChampEmploySkill;
    public static bool _isChampEmployInsticSkill;
    public static bool _isChampEmployActiveSkill;

    // new void Start()
    // {
    //     base.Start();
    //     _maxMeleeCompetitor = 1;
    //     BattleControler.AddEvil(this);
    // }

    new void Update()
    {
        base.Update();

        
    }

    


    override protected void MoveDefault()
    {
        if (Input.GetMouseButton(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2) transform.position != lastClickedPos)
        {
            _animator.SetBool("isWalking", true);
            float step = _movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

        } else {
            moving = false;
            _animator.SetBool("isWalking", false);
            
        }
    }
}
