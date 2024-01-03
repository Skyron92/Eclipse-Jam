using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreditMenu : UIManager
{
    public MainMenu _mainMenu;
    public GameObject creditPanel;

    private void Awake(){
        creditPanel.transform.DOMoveY(ResolutionHeight + (ResolutionHeight / 2), 0);
    }
    public void ReturnButton(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(CreditAnimClose());
    }

    public IEnumerator CreditAnimOpen(){
        creditPanel.transform.DOMoveY(ResolutionHeight / 2, 0.8f);
        yield return null;
    }
    public IEnumerator CreditAnimClose()
    {
        creditPanel.transform.DOMoveY(ResolutionHeight + (ResolutionHeight / 2), 0.8f);
        yield return null;
    }
}
