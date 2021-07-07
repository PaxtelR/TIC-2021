using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelRelatorioGridShot : modelRequest
{
    public float precision;
    public float score;
    public int shots;
    public int hits;
    public float ttk;
    public float kps;
    public string type;
    public string token;

    public modelRelatorioGridShot(float _precision, float _score, int _shots, int _hits, float _ttk, float _kps, string _type)
    {
        precision = _precision * 100;
        score = _score;
        shots = _shots;
        hits = _hits;
        ttk = _ttk;
        kps = _kps;
        type = _type;
    }

    public override void Success(string data)
    {

    }
    public override void Success(string data, System.Action<string, bool> callback)
    {
        callback("", true);
    }

}
