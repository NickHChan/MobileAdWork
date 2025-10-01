using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed) return;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        Debug.Log(worldPosition);
    }
}
