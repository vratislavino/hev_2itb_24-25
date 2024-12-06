using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var screen = FindFirstObjectByType<DeathScreen>();
            if(screen)
            {
                screen.ShowDeathScreen();
                Time.timeScale = 0;
            } else
            {
                Debug.LogError("DeathScreen not found");
            }
        } 
    }
}
