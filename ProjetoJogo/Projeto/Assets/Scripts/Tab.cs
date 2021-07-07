using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tab : MonoBehaviour, IPointerClickHandler
{
    public bool active;
    public GameObject tab;
    TabMenu tabMenu;

    private void Start()
    {
        tabMenu = GetComponentInParent<TabMenu>();

        if (GameObject.Find("TelaResultado") && gameObject.CompareTag("TREINOMenuItem"))
        {
            StartCoroutine(t());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (active)
        {
            openTab();
        }

    }

    public void openTab()
    {
        tabMenu.activeScene(gameObject.name, tab);
    }

    IEnumerator t()
    {
        yield return new WaitForSecondsRealtime(1);
        ResultadoGridShot telaRes = GameObject.Find("TelaResultado").GetComponent<ResultadoGridShot>();
        openTab();
        tab.GetComponent<TreinoAndResult>().ActiveResultado(telaRes.relatorio);
    }

}
