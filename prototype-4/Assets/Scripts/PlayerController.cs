using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [Header("Powerup")]
    [SerializeField] private PlayerPowerup playerPowerup;

    private GameObject focalPoint;
    private Rigidbody playerRb;
    private float forwardInput;
    private float horizontalInput;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.right * speed * horizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerPowerup.currentPowerupType == PowerupType.Pushback)
        {
            playerPowerup.PushbackEnemy(collision);
        }
    }
}
