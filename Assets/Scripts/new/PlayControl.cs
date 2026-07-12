using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 10.0f;
    public float turnSpeed;
    public InputAction moveAction;
    public Vector2 moveInput;
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);

    }
}
