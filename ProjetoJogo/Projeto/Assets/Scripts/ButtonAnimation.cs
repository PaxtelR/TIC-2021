using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform crosshair;
    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        crosshair.DOScale(1.5f, 0.2f);
        crosshair.DORotate(new Vector3(0, 0, -90), 0.2f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        crosshair.DOScale(1.0f, 0.2f);
        crosshair.DORotate(new Vector3(0, 0, 0), 0.2f);
    }
}
