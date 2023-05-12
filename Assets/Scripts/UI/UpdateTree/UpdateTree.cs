using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UpdateTree
{
    TowerUpdate towerUpdate;
    public void ApplyWeaponTowerUpdateTreeBranchUpdate(Tower tower,int level){
        switch(level){
            case 0:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
            case 1:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new AttackSpeedUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
            case 2:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new AttackSpeedUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new AttackRangeUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
        }
    }
    public void ApplyTroopTowerUpdateTreeBranchUpdate(Tower tower,int level){
        switch(level){
            case 0:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
            case 1:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new AttackSpeedUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
            case 2:{
                towerUpdate = new AttackDameUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new AttackSpeedUpdate();
                towerUpdate.ApplyUpdate(tower);
                towerUpdate = new IncreaseHeathUpdate();
                towerUpdate.ApplyUpdate(tower);
                return;
            }
        }
    }
}