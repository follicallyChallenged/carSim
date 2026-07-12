using UnityEngine;

public class KeyboardInputProvider : MonoBehaviour, ICarInputProvider
{
    private CarInput input;
    private CarInputData inputData = new CarInputData();

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

    public CarInputData GetInput()
    {
        inputData.throttle = input.Driving.Throttle.ReadValue<float>();
        inputData.steering = input.Driving.Steer.ReadValue<float>();
        inputData.brake = input.Driving.Brake.ReadValue<float>();

        return inputData;
    }
}