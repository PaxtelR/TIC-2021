using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Modal : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public GameObject buttomL;
    public GameObject buttomR;

    private void Start()
    {
        this.gameObject.SetActive(false);
        buttomL.SetActive(false);
        buttomR.SetActive(false);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void SetModal(string text, ButtomModel bR, ButtomModel bL)
    {
        this.gameObject.SetActive(true);
        setButtom(buttomL, bL);
        setButtom(buttomR, bR);
        buttomL.SetActive(true);
        buttomR.SetActive(true);
        texto.text = text;
    }
    public void SetModal(string text, ButtomModel bR)
    {
        this.gameObject.SetActive(true);
        buttomR.SetActive(true);
        setButtom(buttomR, bR);
        texto.text = text;
    }
    public void SetModal(string text)
    {
        this.gameObject.SetActive(true);
        texto.text = text;
    }

    void setButtom(GameObject buttom, ButtomModel values)
    {
        buttom.GetComponent<Button>().onClick.AddListener(values.onClick);
        buttom.GetComponent<TextMeshProUGUI>().text = values.text;

    }
}
