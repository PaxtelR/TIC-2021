using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public LoginMenu menuScript;
    public Modal modal;

    [Space(2)]
    [Header("Campos")]
    public TMP_InputField _email;
    public TMP_InputField _senha;
    public Toggle remember;

    private void Start()
    {
        string token = PlayerPrefs.GetString("token", "");
        bool rememberB = MenuScript.intToBool(PlayerPrefs.GetInt("remember", 0));

        if (token != "" && remember == true)
        {
            Debug.Log(1);
            StartCoroutine(ApiConnect.SendDataWithAuth("/users/loginToken", new modelLogin(), LoginCallBack));
        }
    }

    public void LoginGetDataAndSend()
    {
        string email = _email.text;
        string senha = _senha.text;

        if (email != "" & senha != "")
        {
            menuScript.ActiveLoading();
            StartCoroutine(ApiConnect.SendDataNoAuth("/users/login", new modelLogin(email, senha), LoginCallBack));
        }
        else
        {
            if (email == "")
            {
                modal.SetModal("E-mail inválido");
            }
            else if (senha == "")
            {
                modal.SetModal("Senha inválida");
            }
        }
    }

    void LoginCallBack(string response, bool success)
    {
        menuScript.DesactiveLoading();
        if (!success)
        {
            msgError resposta = JsonUtility.FromJson<msgError>(response);
            modal.SetModal(resposta.msg);
        }
        else
        {
            bool _remember = remember.isOn;
            PlayerPrefs.SetInt("remember", MenuScript.boolToInt(_remember));
            SceneManager.LoadScene(1);
        }
    }
}
