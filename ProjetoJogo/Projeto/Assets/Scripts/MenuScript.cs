using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_InputField sensInput;
    public Toggle showImpact;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sensInput.text = PlayerPrefs.GetFloat("sense", 1f).ToString();
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        showImpact.isOn = intToBool(PlayerPrefs.GetInt("showImpact", 1));

    }

    public void SetSens()
    {
        PlayerPrefs.SetFloat("sense", float.Parse(sensInput.text));
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SetImpact()
    {
        if (showImpact.isOn)
        {
            PlayerPrefs.SetInt("showImpact", boolToInt(true));
        }
        else
        {
            PlayerPrefs.SetInt("showImpact", boolToInt(false));
        }
    }

    public static int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public static bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
