using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkCubeScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(this.gameObject);
    }
}
