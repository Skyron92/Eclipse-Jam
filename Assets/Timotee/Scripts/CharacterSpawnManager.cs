using System;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterSpawnManager : MonoBehaviour{
    public static CharacterSpawnManager Instance;
    
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private GameObject _characterParent;

    [SerializeField] private float _planetRadius;

    [SerializeField] private float _spawnTime;

    private float _lastSpawn;

    private void OnEnable(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Update(){
        if (CharacterCounter.Count < DifficultyManager.MaxCharacters && Time.time - _lastSpawn >= _spawnTime){
            SpawnCharacter();
        }
    }

    private void SpawnCharacter(){
        GameObject go = Instantiate(_characterPrefab, _characterParent.transform);

        float radius = _planetRadius;
        float polarAngle = Random.Range(0.1f * (float)Math.PI, 0.9f * (float)Math.PI);
        float azimuthalAngle = Random.Range(-0.4f * (float)Math.PI, 0.4f * (float)Math.PI);

        double x;
        double y;
        double z;

        x = radius * Math.Cos(azimuthalAngle) * Math.Cos(polarAngle);
        y = radius * Math.Sin(azimuthalAngle);
        z = radius * Math.Cos(azimuthalAngle) * Math.Sin(polarAngle);

        go.transform.position = new Vector3((float)x, (float)y, (float)z);
        go.transform.up = new Vector3((float) x, (float) y, (float) z);
        
        _lastSpawn = Time.time;
    }
}