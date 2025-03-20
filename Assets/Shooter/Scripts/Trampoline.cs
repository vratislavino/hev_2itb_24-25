using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private float force = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
