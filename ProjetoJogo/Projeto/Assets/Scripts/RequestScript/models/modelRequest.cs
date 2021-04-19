using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
