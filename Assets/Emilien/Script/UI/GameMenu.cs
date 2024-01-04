using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameMenu : UIManager{

    public MainMenu _mainMenu;
    public GameObject gamePanel;
    public Animator gameAnimation;

    private void Awake(){
        gamePanel.transform.DOMoveY(-ResolutionHeight, 0);
    }

    private void Update(){
        ResolutionHeight = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].height;
        ResolutionWidth = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].width;
    } 

    public void ReturnToMainMenu(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(GameAnimClose());
    }

    public IEnumerator GAmeAnimOpen(){
        gameAnimation.Play("cameraAnim");
        gamePanel.transform.DOMoveY(ResolutionHeight / 2, 0.8f);
        yield return null;
    }
    public IEnumerator GameAnimClose(){
        gameAnimation.Play("cameraAnimIN");
        gamePanel.transform.DOMoveY(ResolutionHeight + (ResolutionHeight / 2), 0.8f);
        yield return null;
    }
}
