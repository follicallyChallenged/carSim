using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;

    public float motorForce = 15000f;
    public float steeringAngle = 30f;
    public float brakeForce = 25000f;

    private ICarInputProvider inputProvider;

    private void Awake()
    {
        inputProvider = GetComponent<ICarInputProvider>();

        if (inputProvider == null)
        {
            Debug.LogError("No ICarInputProvider found on this GameObject.");
        }
    }

    private void FixedUpdate()
    {
        if (inputProvider == null) return;

        CarInputData input = inputProvider.GetInput();

        float torque = input.throttle * motorForce;

        FL.motorTorque = torque;
        FR.motorTorque = torque;
        RL.motorTorque = torque;
        RR.motorTorque = torque;

        FL.steerAngle = input.steering * steeringAngle;
        FR.steerAngle = input.steering * steeringAngle;

        float brakeTorque = input.brake * brakeForce;

        FL.brakeTorque = brakeTorque * 1.4f;
        FR.brakeTorque = brakeTorque * 1.4f;
        RL.brakeTorque = brakeTorque * 0.8f;
        RR.brakeTorque = brakeTorque * 0.8f;
    }
}