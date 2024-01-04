using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreditMenu : UIManager
{
    public MainMenu _mainMenu;
    public Animator creditAnimation;
    [SerializeField] private RectTransform panelRectTransform;
    private Vector2 _maxPanelPosition, _minPanelPosition;

    private void Awake() {
        _maxPanelPosition = panelRectTransform.anchorMax;
        _minPanelPosition = panelRectTransform.anchorMin;
    }

    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(CreditAnimClose());
    }

    public IEnumerator CreditAnimOpen(){
        creditAnimation.Play("CreditAnim");
        panelRectTransform.DOAnchorMax(Vector2.one, 0.8f);
        panelRectTransform.DOAnchorMin(Vector2.zero, 0.8f);
        yield return null;
    }
    public IEnumerator CreditAnimClose(){
        creditAnimation.Play("CreditAnimIN");
        panelRectTransform.DOAnchorMax(_maxPanelPosition, 0.8f);
        panelRectTransform.DOAnchorMin(_minPanelPosition, 0.8f);
        yield return null;
    }
}
