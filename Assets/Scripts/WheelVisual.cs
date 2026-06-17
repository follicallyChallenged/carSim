using UnityEngine;

public class WheelVisual : MonoBehaviour
{
    public WheelCollider wheelCollider;

    private Vector3 positionOffset;
    private Quaternion rotationOffset;

    void Start()
    {
        positionOffset = transform.position - wheelCollider.transform.position;
        rotationOffset = Quaternion.Inverse(wheelCollider.transform.rotation) * transform.rotation;
    }

    void Update()
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        transform.position = pos + positionOffset;
        transform.rotation = rot * rotationOffset;
    }
}