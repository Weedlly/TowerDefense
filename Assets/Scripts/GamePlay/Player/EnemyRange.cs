// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyRange : Enemy
// {   

//     override protected void NextTarget(){
//         if(_target == null){
//             _isMoving = true;
//             _movingType = (int)MovingType.MoveDefault;
//             _isAttack = false;

//             _animator.SetBool("isAttack",_isAttack);
//             _animator.SetFloat("movingSpeed",0.5f);
            
//             SetTarget();
//         }
//         else{
//             _isAttack = true;
//             CheckTargetActive();
//         } 
//     }
//     protected void SetTarget(){
//         if(_players.Count > 0){
//             if(_players[0] == null){
//                 _players.RemoveAt(0);
//             }
//             else{
//                 _target = _players[0];
//             }
//         }
//     }

//     void CheckTargetActive(){
//         // switch (_target._unitType)
//         // {
//         //     case (int)UnitType.Melee:{
//         //         _isMoving = false;
//         //         break;
//         //     }
//         //     // case (int)UnitType.Range:{
//         //     //     _isAttack = true;
//         //     //     break;
//         //     // }
//         // }
//         if(_target.gameObject.activeSelf == false){
//             _meleeCompetitorCounter = 0;
//             _isAttack = false;
//             _target = null;
//         }
//         else{
//             _targetPositon = _target.transform.position;
//         }
//     }
// }
