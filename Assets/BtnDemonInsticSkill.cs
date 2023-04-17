using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDemonInsticSkill : MonoBehaviour
{
    [SerializeField] private DemonChampion _champ;
    [SerializeField] private FireRain FR_Skill;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        
        Debug.Log("Test Button");
        FireRain fr = Instantiate(FR_Skill, _champ.transform.position * Random.value * 2, Quaternion.identity);

    }
}
