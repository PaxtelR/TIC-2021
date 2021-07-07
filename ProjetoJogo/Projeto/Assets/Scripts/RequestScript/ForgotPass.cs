using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ForgotPass : MonoBehaviour
{
    public LoginMenu menuScript;
    public Modal modal;

    [Space(2)]
    [Header("Campos")]
    public TMP_InputField _email;

    public void GetDataAndSend()
    {
        string email = _email.text;

        if (email != "")
        {
            menuScript.ActiveLoading();
            StartCoroutine(ApiConnect.SendDataNoAuth("/users/forgotPassword", new modelForgotPass(email), ForgotCallBack));
        }
        else
        {
            modal.SetModal("Todos os campos precisam ser preencidos.");
        }
    }

    void ForgotCallBack(string response, bool success)
    {
        menuScript.DesactiveLoading();
        if (!success)
        {
            msgError resposta = JsonUtility.FromJson<msgError>(response);
            modal.SetModal(resposta.msg);
        }
        else
        {
            menuScript.ActiveLogin();
            modal.SetModal("Eiii! que desatenção... Te enviei um e-mail, veja se recebeu. Recupere sua conta logo, quero treinar com você.", new ButtomModel("Vamos", menuScript.ActiveLogin));
        }
    }
}
