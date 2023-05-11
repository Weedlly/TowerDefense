using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage;
    public TMP_Text abilityText;

    public float abilityCooldown = 5f;
    private bool isAbilityCooldown = false;
    private float currentAbilityCooldown;
    
    [SerializeField] private DemonSkill _champSkill;

    //Ability  Input Variables
    Vector3 position;
    public Canvas abilityCanvas;
    public Image skillshot;
    public Transform champ;


    private bool isSkillDeloy;
    void Start()
    {
        abilityImage.fillAmount = 1;
        abilityText.text = "";

        
        skillshot.enabled = false;
        //targetCircle.GetComponent<Image>().enabled = false;
        //indicatorRangeCircle.GetComponent<Image>().enabled = false;

    }


    void Update()
    {  
        AbilityCooldown();
    
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, 0);
        }

        //Ability Canvas Inputs
        Quaternion tranRot = Quaternion.LookRotation(position - champ.transform.position);
        abilityCanvas.transform.rotation = Quaternion.Lerp(tranRot, abilityCanvas.transform.rotation, 0f);



        // var hitPosDir = (hit.point - transform.position).normalized;
        // float distance = Vector3.Distance(hit.point, transform.position);
        // distance = Mathf.Min(distance, maxAbilityDistance);
        
        //var newHitPos = transform.position + hitPosDir * distance;
        //abilityCanvas.transform.position = (newHitPos);
    
        
    }

    void AbilityCooldown()
    {
        if (isSkillDeloy == true && !isAbilityCooldown)
        {
            
            skillshot.enabled = true;

            Debug.Log("Ability Check:" + skillshot.enabled.ToString());
            isAbilityCooldown = true;
            currentAbilityCooldown = abilityCooldown;

            isAbilityCooldown = true;
            abilityImage.fillAmount = 1;
            _champSkill.setDeploySkill();

        }

        if (isAbilityCooldown)
        {
            currentAbilityCooldown -= Time.deltaTime;
            if (currentAbilityCooldown <= 0f)
            {
                abilityText.text = "";
            }
            else
            {
                int convertFToI = (int) currentAbilityCooldown;
                abilityText.text = convertFToI.ToString();
            }

            abilityImage.fillAmount -= 1 / abilityCooldown * Time.deltaTime;
            skillshot.enabled = false;
            if (abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 1;
                isAbilityCooldown = false;
            }
        }
        
        isSkillDeloy = false;
        
    }

    public void SetAbility()
    {
        isSkillDeloy = true;
    }
}
