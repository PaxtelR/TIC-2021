using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using TMPro;
using UnityEngine.SceneManagement;

public class FPS_Shot : MonoBehaviour
{

    public Material hitMaterial;
    public VisualEffect muzzle;
    public AudioSource shotSound;
    public AudioClip[] akAudios;
    public AkAnimation anim;
    public GameObject hitMarkObject;
    public bool showImpact;
    public GridShotController gridController;
    public TrainerRelatorio treinoScript;

    public float fireRate = 0.1f;

    bool canShot = true;
    int previusIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        shotSound.volume = PlayerPrefs.GetFloat("volume", 0.5f);
        canShot = false;
    }
    public void setCanShot(bool value)
    {
        canShot = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShot)
        {
            StartCoroutine(Shot());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }

    }

    IEnumerator Shot()
    {
        int layerMask = ~(1 << 6);
        canShot = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (gridController.Hitball(hit.transform.gameObject))
            {
                treinoScript.shot(true);
            }
            else
            {
                treinoScript.shot(false);
            }
            if (MenuScript.intToBool(PlayerPrefs.GetInt("showImpact", 1)))
            {
                Instantiate(hitMarkObject, hit.point, Quaternion.identity);
            }

        }
        else
        {
            treinoScript.shot(false);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        muzzle.Play();
        DoShotSound();
        anim.DoAnimation();


        yield return new WaitForSecondsRealtime(fireRate);

        canShot = true;
    }

    void DoShotSound()
    {
        int index = 1;
        do
        {
            index = Random.Range(0, akAudios.Length);
        } while (index == previusIndex);
        previusIndex = index;
        shotSound.clip = akAudios[index];
        shotSound.Play();
    }



}
