using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreditMenu : UIManager
{
    public MainMenu _mainMenu;
    public GameObject creditPanel;
    public Animator creditAnimation;

    private void Awake(){
       creditPanel.transform.DOMoveY(ResolutionHeight*3, 0);
    }

    private void Update(){
        ResolutionHeight = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].height;
        ResolutionWidth = _mainMenu.dropdown.resolutions[_mainMenu.dropdown.dropdownMenu.value].width;
    }

    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(CreditAnimClose());
    }

    public IEnumerator CreditAnimOpen(){
        creditAnimation.Play("CreditAnim");
        creditPanel.transform.DOMoveY(ResolutionHeight/4.5f, 0.8f);
        yield return null;
    }
    public IEnumerator CreditAnimClose(){
        creditAnimation.Play("CreditAnimIN");
        creditPanel.transform.DOMoveY(ResolutionHeight, 0.8f);
        yield return null;
    }
}
