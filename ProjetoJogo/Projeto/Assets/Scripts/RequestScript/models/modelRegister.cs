using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modelRegister : modelRequest
{
    public string username;
    public string email;
    public string password;
    public string password2;

    public modelRegister(string _user, string _email, string _pass, string _pass2)
    {
        this.email = _email;
        this.password = _pass;
        this.username = _user;
        this.password2 = _pass2;
    }
    public modelRegister()
    {

    }

    public override void Success(string data)
    {
        registerResponse response = JsonUtility.FromJson<registerResponse>(data);
    }

    public override void Success(string data, System.Action<string, bool> callback)
    {
        registerResponse response = JsonUtility.FromJson<registerResponse>(data);
        callback(response.msg, true);
    }
}

class registerResponse
{
    public string msg;
    public bool ok;
}
