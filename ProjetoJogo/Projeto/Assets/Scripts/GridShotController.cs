using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShotController : MonoBehaviour
{
    public GameObject[] balls;
    public int maxActiveBalls = 5;

    private int activeBalls = 0;
    private int totalBall;
    void Start()
    {
        totalBall = balls.Length - 1;
        foreach (GameObject a in balls)
        {
            a.SetActive(false);
        }

        for (int i = 0; i < maxActiveBalls; i++)
        {
            ActiveRandomBall();
        }
    }

    void Update()
    {

    }

    void ActiveRandomBall()
    {
        int index;
        do
        {
            index = Random.Range(0, totalBall);
        } while (balls[index].activeSelf);

        balls[index].SetActive(true);
    }

    public bool Hitball(GameObject ball)
    {
        bool achou = false;
        foreach (GameObject a in balls)
        {
            if (ball.name == a.name)
            {
                ActiveRandomBall();
                a.SetActive(false);
                achou = true;
                break;
            }
        }
        return achou;
    }
}
