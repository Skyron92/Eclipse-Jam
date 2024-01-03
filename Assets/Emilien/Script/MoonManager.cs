using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoonSpeed { veryLow, low, normal, fast, veryFast }
public class MoonManager : MonoBehaviour
{
    public GameObject Moon;
    public Slider _slider;
    private MoonSpeed _moonSpeed;

    private float reloadFlash = 360;
    private float moonTimeParkour;
    private float speedValue;
    
    
    void Start(){
        // état de base de la lune
        _moonSpeed = MoonSpeed.normal;

        // définie la valeur max du slider
        _slider.maxValue = reloadFlash;
    }

    
    void Update(){
        moonTimeParkour += speedValue * Time.deltaTime;

        // définie la valeur actuelle du slider
        _slider.value = moonTimeParkour;

        // gère la rotation de la lune pour faire un tour complet
        Moon.transform.Rotate(new Vector3(0,1,1),  speedValue * Time.deltaTime);

        // vitesse de la lune en fonction des enum
        switch (_moonSpeed){
            case MoonSpeed.veryLow:
                speedValue = 20f;
                break;

            case MoonSpeed.low:
                speedValue = 40f;
                break;

            case MoonSpeed.normal:
                speedValue = 60f;
                break;

            case MoonSpeed.fast:
                speedValue = 80f;
                break;

            case MoonSpeed.veryFast:
                speedValue = 100f;
                break;
        }

        // verifie si le slide a fait un tour complet
        if (moonTimeParkour >= reloadFlash)
        {
            moonTimeParkour = 0;
        }
    }
    // a assigner au boutton  correspondant
    public void SetVeryLowSpeed(){
        _moonSpeed = MoonSpeed.veryLow;
    }
    public void SetLowSpeed(){
        _moonSpeed = MoonSpeed.low;
    }
    public void SetNormalSpeed(){
        _moonSpeed = MoonSpeed.normal;
    }
    public void SetFastSpeed(){
        _moonSpeed = MoonSpeed.fast;
    }
    public void SetVeryFastSpeed(){
        _moonSpeed = MoonSpeed.veryFast;
    }
}
