using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DemonSkillTypeEnum {
    ActiveSkill,
    InsticSkill
}

public class DemonSkill : MonoBehaviour
{
    #region variables
        public DemonSkillTypeEnum skillType;
    #endregion

    //Fire Rain Skill
    [SerializeField] private FireRain FR_Skill;
    [SerializeField] private Vector2 _pointerPosition { get; set; }

    public float delayActiveSkill = 10f;
    private bool isDeploySkill = false;
    private bool attackBlocked;

    Vector2 lastClickedPos;
    bool deploy = false;

    void Start(){}

    void Update()
    {  
        if (!attackBlocked)
        {
            DeployActiveSkill();
        }
    }

    public void DeployActiveSkill()
    {
        if (isDeploySkill)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                deploy = true;

                if (deploy)
                {
                    deploy = false;
                    FireRain fr = Instantiate(FR_Skill, lastClickedPos , Quaternion.identity);
                    Destroy(fr.gameObject, 0.6f);
                    
                    attackBlocked = true;
                }
            } 
        }
    }

    public void setDeploySkill()
    {
        isDeploySkill = true;
        attackBlocked = false;
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(10f);
        attackBlocked = false;
    }

}