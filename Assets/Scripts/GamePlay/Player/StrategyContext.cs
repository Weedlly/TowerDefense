using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyContext : MonoBehaviour
{
    private IPlayerStratergy _strategy;
    public void SetStrategy(IPlayerStratergy strategy){
        _strategy = strategy;
    }
    public void DoAction(){
        _strategy.Execute();
    }
}
