using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modelLogin : modelRequest
{
    public string email;
    public string password;

    public modelLogin(string _email, string _pass)
    {
        this.email = _email;
        this.password = _pass;
    }
    public modelLogin()
    {

    }

    public override void Success(string data)
    {
        LoginResponse response = JsonUtility.FromJson<LoginResponse>(data);
        PlayerPrefs.SetString("user", response.username);
        PlayerPrefs.SetString("token", response.token);
    }
    public override void Success(string data, System.Action<string, bool> callback)
    {
        LoginResponse response = JsonUtility.FromJson<LoginResponse>(data);
        PlayerPrefs.SetString("user", response.username);
        PlayerPrefs.SetString("token", response.token);
        callback("", true);
    }
}

class LoginResponse
{
    public string token;
    public string username;
    public bool auth;
}
