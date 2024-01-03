using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum MoonSpeed { veryLow, low, normal, fast, veryFast }
public class MoonManager : MonoBehaviour
{
    public static event Action FlashBang;
    [SerializeField] private InputActionReference triggerInputActionReference;
    private InputAction TriggerInputActon => triggerInputActionReference.action;
    private float TriggerInputValue => TriggerInputActon.ReadValue<float>();
    public GameObject Moon;
    public Slider _slider;
    private MoonSpeed _moonSpeed;

    private float reloadFlash = 360;
    private float moonTimeParkour;
    private float speedValue;

    private void Awake() {
        if(triggerInputActionReference == null) Debug.LogError("Trigger input action reference not assigned !");
        TriggerInputActon.Enable();
        TriggerInputActon.performed += context => SwitchSpeed();
        TriggerInputActon.canceled += context => SetNormalSpeed();
    }

    private void OnDestroy() {
        TriggerInputActon.Disable();
    }

    void Start(){
        // �tat de base de la lune
        _moonSpeed = MoonSpeed.normal;

        // d�finie la valeur max du slider
        _slider.maxValue = reloadFlash;
    }

    
    void Update(){
        if (GameManager.Paused == false){
            moonTimeParkour += speedValue * Time.deltaTime;

            // g�re la rotation de la lune pour faire un tour complet
            Moon.transform.Rotate(new Vector3(0, 1, 1), speedValue * Time.deltaTime);
        }

        // d�finie la valeur actuelle du slider
        _slider.value = moonTimeParkour;

        // g�re la rotation de la lune pour faire un tour complet
        Moon.transform.Rotate(new Vector3(0,0,1),  speedValue * Time.deltaTime);

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

    void SwitchSpeed() {
        switch (TriggerInputValue) {
            case < -0.5f :
              SetVeryLowSpeed();
                break;
            case < 0 when TriggerInputValue >= -0.5f :
                SetLowSpeed();
                break;
            case 0 :
                SetNormalSpeed();
                break;
            case > 0 when TriggerInputValue <= 0.5f :
                SetFastSpeed();
                break;
            case > 0.5f :
                SetVeryFastSpeed();
                break;
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
