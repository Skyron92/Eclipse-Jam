using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Script;

public class MainMenu : UIManager
{
    public List<GameObject> button = new List<GameObject>();
    public SettingMenu _settingMenu;
    public CreditMenu _creditMenu;
    public GameMenu _gameMenu;

    [SerializeField] private RectTransform logoRectTransform;
    private Vector2 _minLogoPos, _maxLogoPos, _targetLogoPosY;

    public DropDown dropdown;
    public CanvasScaler scaler;

    private void Awake() {
        scaler = GetComponent<CanvasScaler>();
        _minLogoPos = new Vector2(0.2f, 2.5f);
        _maxLogoPos = new Vector2(1.8f, 3.3f);
        _targetLogoPosY = new Vector2(1.2f, 2);
        
        logoRectTransform.DOAnchorMax(new Vector2(_maxLogoPos.x, _targetLogoPosY.y), 0.8f);
        logoRectTransform.DOAnchorMin(new Vector2(_minLogoPos.x, _targetLogoPosY.x), 0.8f);
    }
    
    private void Update() {
        ResolutionModifier(gameObject);
    }
    public void ResolutionModifier(GameObject obj){
        ResolutionHeight = dropdown.resolutions[dropdown.dropdownMenu.value].height;
        ResolutionWidth = dropdown.resolutions[dropdown.dropdownMenu.value].width;  
    }

    public void PlayButton(){
        StartCoroutine(MainAnimClose());
        StartCoroutine(_gameMenu.GameAnimOpen());
    }

    public void SettingButton(){
        StartCoroutine(MainAnimClose());
        StartCoroutine(_settingMenu.SettingAnimOpen());
    }

    public void CreditButton(){
        StartCoroutine(MainAnimClose());
        StartCoroutine(_creditMenu.CreditAnimOpen());
    }

    public void QuitButton(){
        Application.Quit();
    }
    
    public IEnumerator MainAnimOpen(){
        logoRectTransform.DOAnchorMax(new Vector2(_maxLogoPos.x, _targetLogoPosY.y), 0.8f);
        logoRectTransform.DOAnchorMin(new Vector2(_minLogoPos.x, _targetLogoPosY.x), 0.8f);
        for (int i = 0; i <= button.Count - 1; i++){
            button[i].transform.DOMoveX(ResolutionWidth / 6.5f, 0.4f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
    
    public IEnumerator MainAnimClose(){
        logoRectTransform.DOAnchorMax(_maxLogoPos, 0.8f);
        logoRectTransform.DOAnchorMin(_minLogoPos, 0.8f);
        for (int i = 0; i <= button.Count - 1; i++){
            button[i].transform.DOMoveX(-ResolutionWidth / 2, 0.4f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
