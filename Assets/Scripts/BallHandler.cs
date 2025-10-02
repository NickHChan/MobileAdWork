using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class BallHandler : MonoBehaviour
{
    public GameObject ballPrefab;
    public Rigidbody2D pivot;
    public Camera mainCamera;
    public float delayTime;
    public float respawnTime;
    private bool isDragging;
    private SpringJoint2D currentBallSpringJoint;
    private Rigidbody2D currentBallRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewBall();
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

    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        
        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
        
        currentBallSpringJoint.connectedBody = pivot;
    }

    private void LaunchBall()
    {
        currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;
        currentBallRigidbody = null;
        Invoke(nameof(DetachBall), delayTime);
        Invoke(nameof(SpawnNewBall), respawnTime);
    }

    private void DetachBall()
    {
        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;
    }
}
