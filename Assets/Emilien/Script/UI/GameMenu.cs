using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameMenu : UIManager{

    public MainMenu _mainMenu;
    public Animator gameAnimation;

    [SerializeField] private RectTransform panelRectTransform;
    private Vector2 _panelMaxPosition, _panelMinPosition, _targetPositionY;

    private void Awake() {
        _targetPositionY = new Vector2(0.02f, 0.98f);
        _panelMaxPosition = panelRectTransform.anchorMax;
        _panelMinPosition = panelRectTransform.anchorMin;
    }

    public void ReturnToMainMenu(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(GameAnimClose());
    }

    public IEnumerator GameAnimOpen(){
        gameAnimation.Play("cameraAnim");
        panelRectTransform.DOAnchorMax(new Vector2(_panelMaxPosition.x, _targetPositionY.y), 0.8f);
        panelRectTransform.DOAnchorMin(new Vector2(_panelMinPosition.x, _targetPositionY.x), 0.8f);
        yield return null;
    }
    public IEnumerator GameAnimClose(){
        gameAnimation.Play("cameraAnimIN");
        panelRectTransform.DOAnchorMax(_panelMaxPosition, 0.8f);
        panelRectTransform.DOAnchorMin(_panelMinPosition, 0.8f);
        yield return null;
    }
}
