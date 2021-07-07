using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public LoginMenu menuScript;
    public Modal modal;

    [Space(2)]
    [Header("Campos")]
    public TMP_InputField _user;
    public TMP_InputField _email;
    public TMP_InputField _senha;
    public TMP_InputField _senha2;

    public void GetDataAndSend()
    {
        string user = _user.text;
        string email = _email.text;
        string senha = _senha.text;
        string senha2 = _senha2.text;


        if (senha != senha2)
        {
            modal.SetModal("As senhas não são iguais");
        }
        else if (senha.Length < 6)
        {
            modal.SetModal("Senha tem que ter no minimo 8 caracteres");
        }
        else if (email != "" & senha != "" && user != "" && senha2 != "")
        {
            menuScript.ActiveLoading();
            StartCoroutine(ApiConnect.SendDataNoAuth("/users/register", new modelRegister(user, email, senha, senha2), RegisterCallBack));
        }
        else
        {
            modal.SetModal("Todos os campos precisam ser preencidos.");
        }
    }

    void RegisterCallBack(string response, bool success)
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
            modal.SetModal("Seja bem-vindo Paxtel! Meu nome é Mai, serei sua instrutora. Vamos dar o nosso melhor!", new ButtomModel("Vamos", modal.Close));
        }
    }
}
