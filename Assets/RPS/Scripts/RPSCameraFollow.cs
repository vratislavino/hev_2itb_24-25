using UnityEngine;

public class RPSCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
