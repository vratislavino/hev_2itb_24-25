using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGenerator : MonoBehaviour
{
    public float interval = 1;
    public float maxDistance = 10;
    public GameObject eggPrefab;

    void Start()
    {
        StartCoroutine(CreateEggRoutine());
    }

    IEnumerator CreateEggRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            CreateEgg();
        }
    }

    void CreateEgg()
    {
        var egg = Instantiate(eggPrefab, transform);
        
        Destroy(egg, 4f);

        egg.transform.localPosition = new Vector3(
            Random.Range(-maxDistance, maxDistance),
            0,
            Random.Range(-maxDistance, maxDistance)
            );

        egg.transform.localRotation = Quaternion.Euler(
            Random.Range(0, 360),
            Random.Range(0, 360),
            Random.Range(0, 360)
            );

        var rb = egg.GetComponent<Rigidbody>();
        rb.AddTorque(
            Random.Range(0, 360),
            Random.Range(0, 360),
            Random.Range(0, 360)
            );
    }
}
