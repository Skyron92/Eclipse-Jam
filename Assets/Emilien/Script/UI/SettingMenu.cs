using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingMenu : UIManager
{
    public MainMenu _mainMenu;
    public Animator settingAnimation;

    [SerializeField] private RectTransform panelRectTransform;
    private Vector2 _maxPosPanel, _minPosPanel, _targetPosX;

    private void Awake() {
        _maxPosPanel = panelRectTransform.anchorMax;
        _minPosPanel = panelRectTransform.anchorMin;
        _targetPosX = new Vector2(0.365f, 0.625f);
    }

    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(SettingAnimClose());
    }

    public IEnumerator SettingAnimOpen(){
        settingAnimation.Play("settingsAnimation");
        panelRectTransform.DOAnchorMax(new Vector2(_targetPosX.y, _maxPosPanel.y), 0.8f);
        panelRectTransform.DOAnchorMin(new Vector2(_targetPosX.x, _minPosPanel.y), .8f);
        yield return null;
    }
    public IEnumerator SettingAnimClose(){
        settingAnimation.Play("settingsAnimationIN");
        panelRectTransform.DOAnchorMax(_maxPosPanel, 0.8f);
        panelRectTransform.DOAnchorMin(_minPosPanel, 0.8f);
        yield return null;
    }
}
