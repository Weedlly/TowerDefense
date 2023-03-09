// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// // public enum MovingType{
// //     MoveDefault = 0,
// //     MoveToTarget = 1,
// // }
// public class BattleControl : MonoBehaviour
// {
//     private List<Character> _allies;
//     private List<Character> _enemys;

//     Character FindClosestTarget(Character character, List<Character> competitor){
//         Character tmpCt = null;
//         float closestDis = float.MaxValue;
//         foreach (var item in competitor)
//         {
//             float tmpDis = Vector2.Distance(character.transform.position,item.transform.position);
//             if(tmpDis > closestDis){
//                 closestDis = tmpDis;
//                 tmpCt = item;
//             }
//         }
//         return tmpCt;
//     }
    
//     private void Start() {
        
//     }
//     private void Update() {
        
//     }
//     void BattleFightting(){

//     }
    


// }