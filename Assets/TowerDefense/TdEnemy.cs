using System;
using UnityEngine;

public class TdEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 2f;

    private Transform currentWaypoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!currentWaypoint)
        {
            currentWaypoint = TdWaypointProvider.Instance.GetNext(null);
        }

        if (currentWaypoint)
        {
            Vector2 direction = (currentWaypoint.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                currentWaypoint = TdWaypointProvider.Instance.GetNext(currentWaypoint);
            }
        }
    }
}
