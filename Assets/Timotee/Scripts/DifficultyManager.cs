using System;
using UnityEngine;

public class DifficultyManager : MonoBehaviour{
    public static DifficultyManager Instance;

    public static int MaxCharacters => Instance._characterCount;
    [SerializeField] private int _characterCount;

    public static float GrowthSpeed => Instance._growthSpeed;
    [SerializeField] private float _growthSpeed;

    private void OnEnable(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}