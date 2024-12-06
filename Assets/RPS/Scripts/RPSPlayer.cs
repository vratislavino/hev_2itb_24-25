using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RPSPlayer : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    RPSSymbol symbol;

    [SerializeField]
    float symbolChangeTime = 5f;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        symbol = GetComponent<RPSSymbol>();
        StartCoroutine(ChangeSymbol());
    }

    private IEnumerator ChangeSymbol()
    {
        while (true)
        {
            yield return new WaitForSeconds(symbolChangeTime);
            symbol.ChangeSymbolToRandom();
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // klik myší
        {
            // raycast - camera
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 150f))
            {
                // bod na terénu
                agent.SetDestination(hit.point);
            }
        }
    }
}
