using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreinoAndResult : MonoBehaviour
{
    public GameObject treino;
    public GameObject resultado;
    // Start is called before the first frame update
    void Start()
    {
        treino.SetActive(true);
        resultado.SetActive(false);
    }

    public void ActiveResultado(modelRelatorioGridShot relatorio)
    {
        treino.SetActive(false);
        resultado.SetActive(true);
        this.gameObject.GetComponentInChildren<ShowResult>().setValues(relatorio);
    }
    public void ActiveTreino()
    {
        treino.SetActive(true);
        resultado.SetActive(false);
    }

}
