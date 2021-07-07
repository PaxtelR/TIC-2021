using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TabMenu : MonoBehaviour
{
    public List<Tab> tabs;
    public Color active;
    public Color noActive;
    public Color desactive;

    private void Start()
    {
        for (int i = 0; i < tabs.Count; i++)
        {
            TextMeshProUGUI text = tabs[i].GetComponent<TextMeshProUGUI>();
            if (tabs[i].GetComponent<Tab>().active)
            {
                text.color = noActive;
            }
            else
            {
                text.color = desactive;
            }

        }
        closeAllTabs();
        if (GameObject.Find("TelaResultado"))
        {

        }
        else
        {
            tabs[0].openTab();
        }


    }

    public void activeScene(string name, GameObject tab)
    {
        closeAllTabs();
        for (int i = 0; i < tabs.Count; i++)
        {
            if (tabs[i].name == name)
            {
                tabs[i].tab.SetActive(true);
                tabs[i].GetComponent<TextMeshProUGUI>().color = active;
                break;
            }

        }
    }

    void closeAllTabs()
    {
        for (int i = 0; i < tabs.Count; i++)
        {
            TextMeshProUGUI text = tabs[i].GetComponent<TextMeshProUGUI>();
            tabs[i].tab.SetActive(false);
            if (tabs[i].GetComponent<Tab>().active)
            {
                text.color = noActive;
            }
            else
            {
                text.color = desactive;
            }
        }
    }
}
