using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillable //Strategy
{
    void FetchSkill(GameObject prefab, Transform transform);

    // void FetchInsticSkill(BurneSkill _prefabBurneSkill, Transform transform);
    // void FetchActiveSkill(HellFire _prefabHellfire, Transform transform);
} 


public class InsticSkill: MonoBehaviour, ISkillable{
    
    public void FetchSkill(GameObject prefab,Transform transform){
        Debug.Log(prefab.GetComponent<BurneSkill>());
        // BurneSkill burneskill = Instantiate(prefab,transform.position,Quaternion.identity) ;

        // Vector3 initialPosition = new Vector3 (this.transform.position.x, this.transform.position.y +1f,0);
        // Resources.Load("Prefabs/Skill/Skill",typeof(GameObject))
        // GameObject skill = Resources.Load("Prefabs/Skill/Skill",typeof(GameObject));
        //   Instantiate(Resources.Load("Prefabs/Skill/Skill",typeof(GameObject)),transform.position,Quaternion.identity) as GameObject;   
        // GameObject burneskill = skill.GetComponent<BurneSkill>() 
        // burneskill.transform.parent = transform;
        // burneskill.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,3f);
    } 
}

public class ActiveSkill: MonoBehaviour, ISkillable{
    
    public void FetchSkill(GameObject prefab,Transform transform){
        // Debug.Log("prefab");
        // Debug.Log(prefab);
        // // Debug.Log(transform.position);
        // // //HellFire hellfire = Instantiate(_prefabHellfire,transform.position,Quaternion.identity);
        
        // // Vector3 initialPosition = new Vector3 (this.transform.position.x, this.transform.position.y +1f,0);
        
        // // GameObject burneskill =  Instantiate(Resources.Load("HellFire",typeof(GameObject)),transform.position,Quaternion.identity) as GameObject;    
        // // 
        // // 
        // HellFire hellfire = Instantiate(prefab.GetComponent<HellFire>(),transform.position,Quaternion.identity);
        // // hellfire.transform.parent = transform;
        // // hellfire.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,3f);
         
        // hellfire.gameObject.SetActive(true);
        // Destroy(this.gameObject, 1f);
        // Destroy(hellfire.gameObject, 1f);
    }
}
