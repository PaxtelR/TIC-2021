using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AkAnimation : MonoBehaviour
{
    public Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    public void DoAnimation()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.gameObject.transform.DOLocalMove(startPos + new Vector3(0, 0, -0.05f), 0.06f));
        mySequence.Append(this.gameObject.transform.DOLocalMove(startPos, 0.06f));
    }
}
