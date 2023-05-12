using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

class SkinPanel : MonoBehaviour
{

    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _normalSkin;
    [SerializeField] TMP_Text _summerSkin;

    [SerializeField] Image _normalSelect;
    [SerializeField] Image _summerSelect;

    // SkinTypeEnum skinType = SkinSystem.Instance.SkinType;

    SkinSystem _skinController; 

    void Start()
    {
        _skinController = SkinSystem.Instance;
        _title.text = UIString.Instance.skinTitle;
        _normalSkin.text = UIString.Instance.normalSkin;
        _summerSkin.text = UIString.Instance.summerSkin;

        if (_skinController.SkinType == SkinTypeEnum.DEFAULT){
            _summerSelect.gameObject.SetActive(false);
        }
        else {
            _normalSelect.gameObject.SetActive(false);
        }
    }

    public void setNormal()
    {
        _summerSelect.gameObject.SetActive(false);
        _normalSelect.gameObject.SetActive(true);
        _skinController.SkinType = SkinTypeEnum.DEFAULT;
    }

    public void setSummer()
    {
        _summerSelect.gameObject.SetActive(true);
        _normalSelect.gameObject.SetActive(false);
        _skinController.SkinType = SkinTypeEnum.SUMMER;
    }
}