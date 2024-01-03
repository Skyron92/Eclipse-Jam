using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG. Tweening;
using UnityEngine.EventSystems;

public class TweenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData){
        gameObject.transform.DOScale(1.05f, 0.3f);
    }
    public void OnPointerExit(PointerEventData eventData){
        gameObject.transform.DOScale(1f, 0.3f);
    }
}
