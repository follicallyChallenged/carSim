using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 10.0f;
    public float turnSpeed;
    public InputAction moveAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);

    }
}
