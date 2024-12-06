using System.Threading;
using UnityEngine;

public class FoolCatcher : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                var fool = hit.collider.GetComponent<Fool>();
                if(fool != null)
                {
                    fool.Hit();
                }
            }
        }
    }
}
