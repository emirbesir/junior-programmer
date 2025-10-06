using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float rocketStrength = 15.0f;
    [SerializeField] private float aliveTimer = 5.0f;
    private Transform target;
    private bool homing;

    private void Update()
    {
        if (homing && target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }

    public void Fire(Transform newTarget)
    {
        target = newTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (target != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = collision.gameObject.transform.position - transform.position;
                enemyRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
