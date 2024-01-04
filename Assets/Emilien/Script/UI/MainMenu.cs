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

    public DropDown dropdown;
    public CanvasScaler scaler;

    private void Awake() {
        scaler = GetComponent<CanvasScaler>();
    }


    private void Update()
    {
        scaler.referenceResolution = new Vector2(ResolutionWidth, ResolutionHeight);
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



    public IEnumerator MainAnimClose(){
        for (int i = 0; i <= button.Count - 1; i++){
            button[i].transform.DOMoveX(-ResolutionWidth / 2, 0.4f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
    public IEnumerator MainAnimOpen(){
        for (int i = 0; i <= button.Count - 1; i++){
            button[i].transform.DOMoveX(ResolutionWidth / 6.5f, 0.4f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
