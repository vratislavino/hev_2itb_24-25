using System;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int maxLives;
    private int lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        lives = maxLives;
    }

    public virtual void Hit()
    {
        RemoveLife();
    }

    private void RemoveLife()
    {
        lives--;
        if(lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        DoMovement();
    }

    protected virtual void DoMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
