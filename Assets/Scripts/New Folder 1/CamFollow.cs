using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    private Vector3 offset = new Vector3(0, 4.1f, -7.061f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position  = player.transform.position + offset;
    }
}
