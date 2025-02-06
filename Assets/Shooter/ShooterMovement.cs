using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShooterMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float mouseSensitivity;

    [SerializeField]
    private Transform cameraHolder;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DoMovement();
        DoRotation();
    }

    private void DoMovement()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        var move = new Vector3(hor, 0, ver);
        rb.linearVelocity = move * speed;
    }

    private void DoRotation()
    {

    }
}
