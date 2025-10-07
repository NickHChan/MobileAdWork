using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float Speed;

    public float speedGainPerSecond;

    public float turnSpeed = 200f;
    private int steerValue;

    // Update is called once per frame
    void Update()
    {
        Speed += speedGainPerSecond * Time.deltaTime;
        transform.Rotate(0, steerValue * turnSpeed * Time.deltaTime, 0);
        transform.Translate(new Vector3(0f ,0f,Speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
