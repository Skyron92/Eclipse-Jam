using System;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public static event Action OnDeath;
    public static event Action OnReset;
    public static event Action OnPause;

    public static float Timer => Instance._timer;
    private float _timer;

    public static bool Paused => Instance._paused; 
    [SerializeField] private bool _paused;

    public float GameSpeed => Instance._gameSpeed;
    private float _gameSpeed = 1;
    
    private void OnEnable(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Update(){
        if (_paused) return;

        _timer += Time.deltaTime;
    }

    public static void ResetGame(){
        Instance._timer = 0;
        Instance._gameSpeed = 1;
        Instance._paused = false;

        OnReset?.Invoke();
    }

    public static void GameOver(){
        Instance._paused = true;
        
        OnDeath?.Invoke();
    }
    
    public static void SetPauseState(bool pause){
        Instance._paused = pause;
        OnPause?.Invoke();
    }
}
