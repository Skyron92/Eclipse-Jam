using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingMenu : UIManager
{
    public MainMenu _mainMenu;
    public GameObject settingPanel;
    public Animator settingAnimation;

    private void Awake(){
        settingPanel.transform.DOMoveX(ResolutionWidth + (ResolutionWidth / 2), 0);
    }

    private void Update(){
        ResolutionHeight = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].height;
        ResolutionWidth = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].width;
    }

    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(SettingAnimClose());
    }

    public IEnumerator SettingAnimOpen(){
        settingAnimation.Play("settingsAnimation");
        settingPanel.transform.DOMoveX(ResolutionWidth / 2, 0.8f);
        yield return null;
    }
    public IEnumerator SettingAnimClose(){
        settingAnimation.Play("settingsAnimationIN");
        settingPanel.transform.DOMoveX(ResolutionWidth + (ResolutionWidth / 2), 0.8f);
        yield return null;
    }
}
