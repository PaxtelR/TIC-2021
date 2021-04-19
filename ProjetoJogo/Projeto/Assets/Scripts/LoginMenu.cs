using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMenu : MonoBehaviour
{
    public GameObject login;
    public GameObject register;
    public GameObject forgotPass;
    public GameObject loading;

    public void ActiveLoading()
    {
        loading.SetActive(true);
    }

    public void DesactiveLoading()
    {
        loading.SetActive(false);
    }

    public void ActiveLogin()
    {
        login.SetActive(true);
        register.SetActive(false);
        forgotPass.SetActive(false);
    }
    public void ActiveRegister()
    {
        register.SetActive(true);
        login.SetActive(false);
        forgotPass.SetActive(false);
    }
    public void ActiveForgotPass()
    {
        forgotPass.SetActive(true);
        register.SetActive(false);
        login.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
