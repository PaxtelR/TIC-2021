using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Modal : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void SetModal(string text)
    {
        this.gameObject.SetActive(true);
        texto.text = text;

    }
}
