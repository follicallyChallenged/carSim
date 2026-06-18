using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;

    public float motorForce = 2000f;
    public float steeringAngle = 30f;

    private CarInput input;

    private void Awake()
    {
        input = new CarInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        float throttle = input.Driving.Throttle.ReadValue<float>();
        float steer = input.Driving.Steer.ReadValue<float>();
        float brake = input.Driving.Brake.ReadValue<float>();

        float torque = throttle * motorForce;

        FL.motorTorque = torque;
        FR.motorTorque = torque;
        RL.motorTorque = torque;
        RR.motorTorque = torque;

        FL.steerAngle = steer * steeringAngle;
        FR.steerAngle = steer * steeringAngle;

        float brakeForce = 25000f;
        float brakeTorque = brake * brakeForce;

        FL.brakeTorque = brakeTorque * 1.4f;
        FR.brakeTorque = brakeTorque * 1.4f;

        RL.brakeTorque = brakeTorque * 0.8f;
        RR.brakeTorque = brakeTorque * 0.8f;
    }
}