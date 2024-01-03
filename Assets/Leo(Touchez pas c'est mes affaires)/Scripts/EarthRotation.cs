using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EarthRotation : MonoBehaviour
{
    [SerializeField] private InputActionReference joystickInputActionReference;
    [SerializeField] private InputActionReference mouseInputActionReference;
    private InputAction JoystickInputAction => joystickInputActionReference.action;
    private InputAction MouseInputAction => mouseInputActionReference.action;
    private Vector2 JoystickInput => JoystickInputAction.ReadValue<Vector2>();
    private bool _inputIsPerformed;
    [SerializeField, Range(0, 100)] private float rotationSpeed;
    private Vector3 _mouseOrigin;

    private void Awake() {
        if(joystickInputActionReference == null) Debug.LogError("Attach the joystick input action reference !");
        if(mouseInputActionReference == null) Debug.LogError("Attach the mouse input action reference !");
        if(rotationSpeed == 0) Debug.LogWarning("Rotation speed is equal to 0 !");
        JoystickInputAction.Enable();
        JoystickInputAction.performed += context => _inputIsPerformed = true;
        JoystickInputAction.canceled += context => {
            _inputIsPerformed = false;
            StopCoroutine(Rotate());
        };
        MouseInputAction.Enable();
        MouseInputAction.started += context => _mouseOrigin = Input.mousePosition; 
        MouseInputAction.performed += context => _inputIsPerformed = true;
        MouseInputAction.canceled += context => {
            _inputIsPerformed = false;
            StopCoroutine(Rotate());
        };
    }

    private void Update() {
        if (_inputIsPerformed) StartCoroutine(Rotate());
    }

    private void OnDestroy() {
        JoystickInputAction.Disable();
        MouseInputAction.Disable();
    }

    IEnumerator Rotate() {
        if (JoystickInput != Vector2.zero) { //Rotation à la manette
            Vector3 rotationDirection = new Vector3();
            rotationDirection = Vector3.forward * JoystickInput.y + Vector3.up * JoystickInput.x;
            rotationDirection.x = 0;
            transform.Rotate(rotationDirection * rotationSpeed * 0.1f, Space.World);
        }
        else { // Rotation à la souris
            Vector3 offset = Input.mousePosition - _mouseOrigin;
            float rotationX = offset.y * rotationSpeed * Time.deltaTime;
            float rotationY = -offset.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.forward, rotationX, Space.World);
            _mouseOrigin = Input.mousePosition;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
