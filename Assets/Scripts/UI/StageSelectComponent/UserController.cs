using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UserController: MonoBehaviour
{
    [SerializeField] TMP_Text _username;
    [SerializeField] TMP_Text _star;
    [SerializeField] TMP_Text _profileBtnText;
    [SerializeField] Image _expBar;
    User _user;

    void Awake(){
        _user = User.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _profileBtnText.text = UIString.Instance.profileBtnText;
    } 

    // Update is called once per frame
    void Update()
    {
          _username.text = _user.getUsername();
        _star.text = _user.getStar().ToString();
    }
    
}
