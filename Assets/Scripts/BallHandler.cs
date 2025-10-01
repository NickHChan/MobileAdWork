using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    public Camera mainCamera;
    public SpringJoint2D currentBallSpringJoint;
    public float delayTime = 5f;
    private bool isDragging;
    public Rigidbody2D currentBallRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBallRigidbody == null) return;
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }
            
            isDragging = false;
            return;
        }

        isDragging = true;
        currentBallRigidbody.bodyType = RigidbodyType2D.Kinematic;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        currentBallRigidbody.position = worldPosition;
    }

    private void LaunchBall()
    {
        currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;
        currentBallRigidbody = null;
        Invoke(nameof(DetachBall), delayTime);
    }

    private void DetachBall()
    {
        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;
    }
}
