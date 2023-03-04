// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Threading;

// public class Room : MonoBehaviour
// {

//     // Start is called before the first frame update
//     // private List<Ally> _allySide;
//     // private List<Enemy> _enemySide;
//     private Ally _allySide;
//     private Enemy _enemySide;

//     public static bool InviateToRoom(Ally p1, Enemy p2){
//         if(!p1._inCombat && !p2._inCombat){
//             p1.SetTarget(p2);
//             p2.SetTarget(p1);
//             return true;
            
//         }
//         return false;
//     }
//     public static void EndedRoom(Ally p1, Enemy p2){
//         p1.RoomDestroy();
//         p2.RoomDestroy();
//     }

  

//     // public void AddPlayer<T>(T player){
//     //     if(typeof(T) == typeof(Enemy)){
//     //         // _enemySide.Add(player as Enemy);
//     //         _enemySide = player as Enemy;
//     //     }
//     //     else if(typeof(T) == typeof(Ally)){
//     //         // _allySide.Add(player as Ally);
//     //         _allySide = player as Ally;
//     //     }
//     // }
    
//     // private void CombatPlaying(){
//     //     // If at least 1 close fighter each side the room will looked then combat starting
//     //     if(_allySide && _enemySide){
//     //         _allySide.CombatBehavious();
//     //         _enemySide.CombatBehavious();
//     //         // Looked Room until 
//     //     }
//     //     // If one side die, the room unlocked and ended
//     //     else if(!_allySide || !_enemySide){

//     //     }
//     // }
// }
