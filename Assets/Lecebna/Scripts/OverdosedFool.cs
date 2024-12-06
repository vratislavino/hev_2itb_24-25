using UnityEngine;

public class OverdosedFool : Fool
{
    public float angle;
    public float maxAngle;
    public bool isGoingRight = true;

    private Quaternion startRotation;

    protected override void Start()
    {
        base.Start();
        startRotation = transform.rotation;
    }

    protected override void DoMovement()
    {
        if (isGoingRight)
        {
            transform.Rotate(0, angle * Time.deltaTime, 0);
        } else
        {
            transform.Rotate(0, -angle * Time.deltaTime, 0);
        }

        if (Quaternion.Angle(startRotation, transform.rotation) > maxAngle)
        {
            isGoingRight = !isGoingRight;
        }

        base.DoMovement();
    }
}
