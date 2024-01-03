using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : UIManager{

    public MainMenu _mainMenu;
    public GameObject gamePanel;
    private void Awake(){
        gamePanel.transform.DOMoveY(-ResolutionHeight, 0);
    }
    public void ReturnToMainMenu(){
        StartCoroutine(_mainMenu.MainAnimOpen());
        StartCoroutine(GameAnimClose());
    }

    public IEnumerator GAmeAnimOpen(){
        gamePanel.transform.DOMoveY(ResolutionHeight / 2, 0.8f);
        yield return null;
    }
    public IEnumerator GameAnimClose(){
        gamePanel.transform.DOMoveY(ResolutionHeight + (ResolutionHeight / 2), 0.8f);
        yield return null;
    }
}
