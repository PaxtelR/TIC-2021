using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePanelScript : MonoBehaviour
{
    public TreinoModel model;

    void Start()
    {
        transform.Find("Title").GetComponent<TextMeshProUGUI>().text = model.Title;
        transform.Find("foco").GetComponent<TextMeshProUGUI>().text = model.foco;
        transform.Find("description").GetComponent<TextMeshProUGUI>().text = model.description;
        transform.Find("ImageTreino").GetComponent<RawImage>().texture = model.image;
    }

    public void Play()
    {
        if (!model.notReady)
        {
            SceneManager.LoadScene(model.scene);
        }

    }

    public void GoToTreino()
    {
        if (!model.notReady)
        {
            GameObject.FindGameObjectWithTag("TreinoMenu").GetComponent<TabMenu>().tabs[1].openTab();
            GameObject.FindGameObjectWithTag("TreinoMenu").GetComponent<TabMenu>().tabs[1].tab.GetComponent<TreinoAndResult>().ActiveTreino();
            GameObject.FindGameObjectWithTag("TreinoMenu").GetComponent<TabMenu>().tabs[1].tab.GetComponentInChildren<GamePanelScript>().model = model;
            GameObject.FindGameObjectWithTag("TreinoMenu").GetComponent<TabMenu>().tabs[1].tab.GetComponentInChildren<GamePanelScript>().UpdateHud();

        }

    }

    public void UpdateHud()
    {
        transform.Find("Title").GetComponent<TextMeshProUGUI>().text = model.Title;
        transform.Find("foco").GetComponent<TextMeshProUGUI>().text = model.foco;
        transform.Find("description").GetComponent<TextMeshProUGUI>().text = model.description;
        transform.Find("ImageTreino").GetComponent<RawImage>().texture = model.image;
    }
}
