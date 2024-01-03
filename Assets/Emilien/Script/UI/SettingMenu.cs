using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingMenu : UIManager
{
    public MainMenu _mainMenu;
    public GameObject settingPanel;
    private void Awake(){
        settingPanel.transform.DOMoveX(ResolutionWidth + (ResolutionWidth / 2), 0);
    }
    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(SettingAnimClose());
    }

    public IEnumerator SettingAnimOpen(){
        settingPanel.transform.DOMoveX(ResolutionWidth / 2, 0.8f);
        yield return null;
    }
    public IEnumerator SettingAnimClose()
    {
        settingPanel.transform.DOMoveX(ResolutionWidth + (ResolutionWidth / 2), 0.8f);
        yield return null;
    }
}
