using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShotRelatorio : TrainerRelatorio
{
    /*
    Precisão
    Pontuação
    Acertos
    Erros
    Tempo médio entre kill
    Kill por segundo
    */
    float timeToKill = 0f;
    float averageTTk = 0f;
    float time = 0f;
    float lastKill = 0f;
    float kpsRT = 0f;
    public ResultadoGridShot telaResultado;
    public GameObject AK;
    // (a¹ * (n - 1)) + a² / n   
    // a¹ = media anterior
    // n = numero de acerto
    // a² = tempo atual

    public override void Start()
    {
        base.Start();
        telaResultado.Desativar();
    }

    public override void shot(bool _hit)
    {
        base.shot(_hit);
        if (time != 0f && _hit)
        {
            lastKill = Time.time - time;
            averageTTk = ((averageTTk * (hits - 1)) + lastKill) / hits;
        }
        if (_hit)
        {
            time = Time.time;
            kpsRT = hits / (timeInSec - timeRemaining);
            float fixedTtk = 1;
            if (averageTTk != 0)
            {
                fixedTtk = averageTTk;
            }

            float calc = Mathf.Round((float)((float)(hits * 10) * (float)precision) +
                                (float)((float)hits * (float)precision * (float)precision * (float)kpsRT)
                             + (float)((float)((float)hits * (float)precision) / (float)((float)fixedTtk * (float)precision)));
            score += calc;

        }
        AttScoreText();
    }

    public override void EndTreino()
    {
        fpsShot.setCanShot(false);
        fpsController.m_MouseLook.canMove = false;
        float kps = (float)hits / (float)timeInSec;
        AK.SetActive(false);
        telaResultado.SetData(precision, score, shots, hits, averageTTk, kps, "Ranked");
    }

}
