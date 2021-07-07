using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreinoModel", menuName = "Projeto/TreinoModel", order = 0)]
public class TreinoModel : ScriptableObject
{
    public Texture2D image;
    public string Title;
    public string foco;
    [TextArea]
    public string description;
    [Space(3)]
    public bool notReady;
    public int scene;


}