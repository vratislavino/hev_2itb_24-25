using UnityEngine;

public class RPSEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int enemyCount = 50;

    [SerializeField]
    private bool spawn = true;

    [SerializeField]
    private GameObject enemyPrefab;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var pos = GetRandomPosition();
        var newEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        newEnemy.transform.SetParent(transform);
    }

    private Vector3 GetRandomPosition()
    {
        int x = Random.Range(0, 100);
        int z = Random.Range(0, 100);

        var ray = new Ray(
            new Vector3(x, 100, z),
            Vector3.down
            );

        if(Physics.Raycast(ray, out RaycastHit hit, 101))
        {
            if(hit.collider.name.Contains("Terrain"))
            {
                return hit.point;
            } else
            {
                return GetRandomPosition();
            }
        } else
        {
            return GetRandomPosition();
        }
    }
}
