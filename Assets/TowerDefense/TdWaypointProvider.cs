using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TdWaypointProvider : MonoBehaviour
{
    private static TdWaypointProvider instance;
    public static TdWaypointProvider Instance => instance;
    [SerializeField]
    private List<Transform> waypoints;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(waypoints == null || waypoints.Count == 0)
        {
            Debug.LogWarning("You forgot to assign waypoints!", gameObject);
        }
    }

    public Transform GetNext(Transform current)
    {
        if(current == null)
            return waypoints.First();

        int index = waypoints.IndexOf(current);
        index++;

        if(index == waypoints.Count)
            index = 0;
        return waypoints.ElementAt(index);
    }
}
