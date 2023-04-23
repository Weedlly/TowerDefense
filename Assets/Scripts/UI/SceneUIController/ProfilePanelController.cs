using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfilePanelController : MonoBehaviour
{
    [SerializeField] TMP_Text _profileTitle;
    [SerializeField] TMP_Text _usernameTitle;
    [SerializeField] TMP_Text _saveBtnText;
    [SerializeField] TMP_InputField _username;

    private User _user;

    void Awake(){
        _user = User.Instance;
    }

    public void saveUsername(){
        string nUsername = _username.text;
        _user.saveUsername(nUsername);
    }

    void Start()
    {
        _profileTitle.text = UIString.Instance.profileTitle;
        _usernameTitle.text = UIString.Instance.usernameTitle;
        _saveBtnText.text = UIString.Instance.saveBtnText;
        _username.text = _user.getUsername();
    }
}