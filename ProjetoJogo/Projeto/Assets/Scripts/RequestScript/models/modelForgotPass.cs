using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelForgotPass : modelRequest
{
    public string email;

    public modelForgotPass(string _email)
    {
        this.email = _email;
    }
    public modelForgotPass()
    {

    }

    public override void Success(string data)
    {
        ForgotResponse response = JsonUtility.FromJson<ForgotResponse>(data);
    }

    public override void Success(string data, System.Action<string, bool> callback)
    {
        ForgotResponse response = JsonUtility.FromJson<ForgotResponse>(data);
        callback(response.msg, true);
    }
}

class ForgotResponse
{
    public string msg;
    public bool success;
}

