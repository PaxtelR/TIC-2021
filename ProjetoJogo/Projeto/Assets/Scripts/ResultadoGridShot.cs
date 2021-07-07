using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultadoGridShot : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public modelRelatorioGridShot relatorio;
    public void SetData(float _precision, float _score, int _shots, int _hits, float _ttk, float _kps, string type)
    {
        this.gameObject.SetActive(true);


        relatorio = new modelRelatorioGridShot(_precision, _score, _shots, _hits, _ttk, _kps, type);
        //Enviar relatorio;
        StartCoroutine(ApiConnect.SendDataWithAuth("/report/reportGridShot", relatorio, relatorioCallBack));
    }

    public void Desativar()
    {
        this.gameObject.SetActive(false);
    }

    public void BotaoMenu()
    {
        SceneManager.LoadScene(1);
    }

    void relatorioCallBack(string response, bool success)
    {
        //menuScript.DesactiveLoading();
        if (!success)
        {
            msgError resposta = JsonUtility.FromJson<msgError>(response);
            //  modal.SetModal(resposta.msg);
        }
        else
        {
            //Sucesso
        }
        SceneManager.LoadScene(1);
    }
}
