using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class modelRequest
{
    public virtual void Success()
    {

    }
    public virtual void Success(string data)
    {

    }
    public virtual void Success(string data, System.Action<string, bool> callback)
    {

    }
}

public class msgError
{
    public string msg;
}

public class ButtomModel
{
    public string text;
    public UnityAction onClick;
    public ButtomModel(string texto, UnityAction function)
    {
        text = texto;
        onClick = function;
    }
}
