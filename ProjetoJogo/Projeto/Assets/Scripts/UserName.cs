using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UserName : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public Image image;
    void Start()
    {
        texto.text = PlayerPrefs.GetString("user", " ");
    }
}
