using System;
using UnityEngine;

public class CharacterCounter : MonoBehaviour{
    public static int Count = 0;

    private float _scale = 0.01f;
    
    private void OnEnable(){
        Count++;
        _scale = 0.01f;
        transform.localScale = Vector3.one * _scale;
    }

    private void Update(){
        if (_scale < 1f){
            _scale = Math.Min(_scale + (DifficultyManager.GrowthSpeed * Time.deltaTime), 1f);
            transform.localScale = Vector3.one * _scale;
        }
    }

    private void OnDisable(){
        Count--;
    }
}