using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolSpawner : MonoBehaviour
{
    [SerializeField]
    private float interval;

    [SerializeField]
    private List<Fool> prefabs;

    void Start()
    {
        StartCoroutine(SpawnFoolsRoutine());
    }

    private IEnumerator SpawnFoolsRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            SpawnFool();
        }
    }

    private void SpawnFool()
    {
        var prefab = prefabs[Random.Range(0, prefabs.Count)];
        var fool = Instantiate(prefab, transform);

        fool.transform.localPosition = Vector3.zero;
        fool.transform.Rotate(0, Random.Range(0f, 360f), 0);
    }

}
