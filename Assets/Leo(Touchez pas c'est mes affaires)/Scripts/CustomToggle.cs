using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private RectTransform uiRectTransform;
    private Vector2 _handlePosition;

    [SerializeField] private Image fillImage;
    [SerializeField] private Color activatedColor;
    [SerializeField] private Color unactivatedColor;

    [SerializeField, Range(0, 1)] private float animationDuration; 
    [SerializeField, Range(0, 1)] private float colorAnimationDuration; 

    private void Awake() {
        _handlePosition = uiRectTransform.anchoredPosition;
        toggle.onValueChanged.AddListener(OnSwitch);
        if(toggle.isOn) OnSwitch(true);
    }

    void OnSwitch(bool isOn) {
        //uiRectTransform.anchoredPosition = isOn ? _handlePosition : _handlePosition / 10;
        uiRectTransform.DOAnchorPos(isOn ? _handlePosition : _handlePosition / 10, animationDuration).SetEase(Ease.InOutBack);
        fillImage.DOColor(isOn ? activatedColor : unactivatedColor, colorAnimationDuration);
    }
}
