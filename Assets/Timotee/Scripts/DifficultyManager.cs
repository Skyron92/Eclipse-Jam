using System;
using UnityEngine;

public class DifficultyManager : MonoBehaviour{
    public static DifficultyManager Instance;

    public static int MaxCharacters{
        get{
            if (ThirdPhase)
                return Instance._thirdPhaseCharacters;
            if (SecondPhase)
                return Instance._secondPhaseCharacters;
            return Instance._characterCount;
        }
    }
    [SerializeField] private int _characterCount;
    [SerializeField] private int _secondPhaseCharacters;
    [SerializeField] private int _thirdPhaseCharacters;

    public static float GrowthSpeed => Instance._growthSpeed;
    [SerializeField] private float _growthSpeed;

    public static bool SecondPhase => GameManager.Timer >= Instance._secondPhaseThreshold;
    [SerializeField] private float _secondPhaseThreshold;

    public static bool ThirdPhase => GameManager.Timer >= Instance._thirdPhaseThreshold;
    [SerializeField] private float _thirdPhaseThreshold;
    
    private void OnEnable(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    
    
}