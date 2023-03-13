// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WaveSystem 
// {
//     private List<ObjectPooler> _poolers;
//     private List<int> _numbers;
//     private float _spawnInterval;

//     private List<LineRenderer> _gates;

//     public WaveSystem(List<ObjectPooler> poolers,List<int> number, List<LineRenderer> gates,float spawnInterval){
//         _poolers = poolers;
//         _numbers = number;
//         _spawnInterval = spawnInterval;
//         _gates = gates;
//     }

//     public List<GateSystem> CreateGate(){
//         GateSystem gateSystem = new List<GateSystem>();
//         for (int i = 0; i < _poolers.Count; i++)
//         {
//             TurnSystem instance = new Spawner(_poolers[i],_numbers[i],_gates[i],_spawnInterval);
//             instance.CreateGate();

//         }
        
//         return gateSystem;
//     }


    
// }