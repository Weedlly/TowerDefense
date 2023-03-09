// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CombatRoom : MonoBehaviour
// {
//     private Enemy _meleeEnemy;
//     private List<Enemy> _rangeEnemys;
//     // private int _enemysMeleeCount = 0;
//     private Ally _ally;
//     // private List<Ally> _allys;
//     // private int _allysMelleCount = 0;

//     public bool AddMeleeEnemy(Enemy enemy){
//         if(_meleeEnemy == null){
//             _meleeEnemy = enemy;
//             return true;
//         }
//         return false;
       
//     }
//     public bool AddRangeEnemy(Enemy enemy){
//         _rangeEnemys.Add(enemy);
//         return true;
//     }

//     private void Update() {
//         if(_allys != null){

//         }
//         else{
//             DetroyRoom();
//         }
//     }
//     void DetermineCombatLocation(){

//     }
//     void DetroyRoom(){
//         // Remove all enemy in room
//         _meleeEnemy = null;
//         while(_rangeEnemys.Count > 0){
//             _rangeEnemys.RemoveAt(0);
//         }
//     }
// }
