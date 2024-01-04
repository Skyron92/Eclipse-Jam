using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private RectTransform uiRectTransform;
    private Vector2 _maxOnHandlePosition, _minOnHandlePosition, _maxOffHandlePosition;

    [SerializeField] private Image fillImage;
    [SerializeField] private Color activatedColor;
    [SerializeField] private Color unactivatedColor;

    [SerializeField, Range(0, 1)] private float animationDuration; 
    [SerializeField, Range(0, 1)] private float colorAnimationDuration; 

    private void Awake() {
        _maxOnHandlePosition = uiRectTransform.anchorMax;
        _minOnHandlePosition = uiRectTransform.anchorMin;
        _maxOffHandlePosition = new Vector2(0.4f, 1);
        toggle.onValueChanged.AddListener(OnSwitch);
        if(toggle.isOn) OnSwitch(true);
    }

    void OnSwitch(bool isOn) {
        uiRectTransform.DOAnchorMax(isOn ? _maxOnHandlePosition : _maxOffHandlePosition, animationDuration).SetEase(Ease.InOutBack);
        uiRectTransform.DOAnchorMin(isOn ? _minOnHandlePosition : Vector2.zero, animationDuration).SetEase(Ease.InOutBack);
        fillImage.DOColor(isOn ? activatedColor : unactivatedColor, colorAnimationDuration);
    }
}
