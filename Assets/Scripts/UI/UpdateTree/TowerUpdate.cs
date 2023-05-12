using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface TowerUpdate
{
    Tower ApplyUpdate(Tower tower);
}
public class AttackSpeedUpdate: TowerUpdate{
    float attackSpeedBuffPercent = 0.1f;
    public Tower ApplyUpdate(Tower tower){
        tower._attackSpeed += attackSpeedBuffPercent * tower._attackSpeed;
        return tower;
    }
}
public class AttackDameUpdate: TowerUpdate{
    float attackDameBuffPercent = 0.1f;
    public Tower ApplyUpdate(Tower tower){
        tower._attackDame += attackDameBuffPercent * tower._attackDame;
        return tower;
    }
}
public class AttackRangeUpdate: TowerUpdate{
    float attackRangeBuffPercent = 0.1f;
    public Tower ApplyUpdate(Tower tower){
        tower._attackRange += attackRangeBuffPercent * tower._attackRange;
        return tower;
    }
}
public class IncreaseHeathUpdate: TowerUpdate{
    float increaseHeathPercent = 0.1f;
    public Tower ApplyUpdate(Tower tower){
        tower._health += increaseHeathPercent * tower._health;
        return tower;
    }
}
