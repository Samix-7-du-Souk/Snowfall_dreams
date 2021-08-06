using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset; // We can set a special delay to the camera
    public Vector3 posOffset; // We can set a special position to the camera

    private Vector3 velocity;
    
    void Update()
    {
        // This line will make the camera 
        transform.position = Vector3.SmoothDamp(transform.position,  player.transform.position + posOffset, ref velocity, timeOffset);
    }
}