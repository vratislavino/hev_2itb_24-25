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

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Transform groundCheck;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CheckGrounded();
        DoMovement();
        DoRotation();
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(
            groundCheck.position,
            Vector3.down,
            0.03f
            );
    }

    private void DoMovement()
    {
        var hor = Input.GetAxis("Horizontal") * speed;
        var ver = Input.GetAxis("Vertical") * speed;
        var yVel = rb.linearVelocity.y;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            yVel = jumpSpeed;
        }
        var move = new Vector3(hor, yVel, ver);
        var rotatedMove = transform.rotation * move;
        
        rb.linearVelocity = rotatedMove;
    }

    private void DoRotation()
    {
        var rotX = Input.GetAxis("Mouse Y") * mouseSensitivity;
        var rotY = Input.GetAxis("Mouse X") * mouseSensitivity;

        var currentX = cameraHolder.localRotation.eulerAngles.x;
        currentX -= rotX;

        if (currentX > 180)
            currentX -= 360;

        currentX = Mathf.Clamp(currentX, -80, 80);

        cameraHolder.localRotation = Quaternion.Euler(currentX, 0, 0);
        transform.Rotate(Vector3.up * rotY);
    }
}
