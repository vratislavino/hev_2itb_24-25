using UnityEngine;

public class TeleportFool : Fool
{
    public override void Hit()
    {
        var pos = transform.position;
        pos.x *= -1;
        pos.z *= -1;
        transform.position = pos;
        transform.Rotate(0, 180, 0);
        base.Hit();
    }
}
