using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset1 = new Vector3(0, 5, -11);
    private Vector3 offset2 = new Vector3(0, 2, 0.5f);
    private Quaternion startRotation;
    private bool isCameraInsideView = false;

    private void Start()
    {
        startRotation = transform.rotation;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isCameraInsideView = !isCameraInsideView;
        }
    }

    private void LateUpdate()
    {
        // Moves the camera to follow the player
        if (isCameraInsideView)
        {
            transform.position = player.transform.position + offset2;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = player.transform.position + offset1;
            transform.rotation = startRotation;
        }
    }
}
