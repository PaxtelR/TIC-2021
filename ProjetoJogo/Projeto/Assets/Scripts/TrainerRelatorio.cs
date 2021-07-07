using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityStandardAssets.Characters.FirstPerson;
public class TrainerRelatorio : MonoBehaviour
{

    public int shots = 0;
    public int hits = 0;
    public int miss = 0;
    //Precisão
    const string display = "{0}%";
    public TextMeshProUGUI precisionText;
    public float precision = 0f;
    //Pontuação
    public float score = 0f;
    //Timer
    public int timeInSec = 60;
    public float timeRemaining = 0;
    bool timerIsRunning = false;
    public TextMeshProUGUI timerGame;
    public string displayTime = "{0}:{1}";
    public TextMeshProUGUI timerStart;
    public Image timerCross;
    public TextMeshProUGUI scoreText;
    public FPS_Shot fpsShot;
    public FirstPersonController fpsController;

    public virtual void Start()
    {
        StartCoroutine(startTimer());
        fpsController.m_MouseLook.canMove = false;
    }

    IEnumerator startTimer()
    {
        int startTime = 5;
        do
        {
            timerStart.text = startTime.ToString();
            timerCross.transform.DORotate(new Vector3(0, 0, timerCross.transform.rotation.eulerAngles.z + 90), 0.3f);
            startTime--;
            yield return new WaitForSecondsRealtime(1);

        } while (startTime >= 0);
        timerStart.gameObject.SetActive(false);
        timerCross.gameObject.SetActive(false);

        StartTreino();
        fpsShot.setCanShot(true);
        fpsController.m_MouseLook.canMove = true;

    }

    public void StartTreino()
    {
        timerIsRunning = true;
        timeRemaining = timeInSec;
    }
    public virtual void EndTreino()
    {

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);
                timerGame.text = string.Format(displayTime, minutes.ToString("D2"), seconds.ToString("D2"));
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndTreino();
            }
        }
    }

    public virtual void shot(bool _hit)
    {
        shots++;
        if (_hit)
        {
            hits = hits + 1;
        }
        else
        {
            miss = miss + 1;
        }

        AttPrecisionText();
    }

    void AttPrecisionText()
    {
        precision = (float)hits / shots;
        precisionText.text = string.Format(display, (precision * 100).ToString("0.##"));
    }

    public void AttScoreText()
    {
        scoreText.text = score.ToString();
    }

}
