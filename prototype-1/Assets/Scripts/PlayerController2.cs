using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        // Get the player input
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
