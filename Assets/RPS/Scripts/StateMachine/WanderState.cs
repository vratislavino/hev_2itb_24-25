using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    Transform transform;
    public float currentDistance = 0;
    // destinace?
    Vector3 destination;
    public WanderState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void EnterState()
    {
        GeneratePoint();
    }

    public override void UpdateState()
    {
        currentDistance = Vector3.Distance(agent.transform.position, destination);
        if (currentDistance < 0.5f)
            GeneratePoint();

        agent.SetDestination(destination);
    }

    private void GeneratePoint()
    {
        var highPoint = new Vector3(
            Random.Range(0, 100),
            100,
            Random.Range(0, 100));

        if (Physics.Raycast(highPoint, Vector3.down, out RaycastHit hit, 105f))
        {
            if(!hit.collider.name.Contains("Terrain"))
            {
                GeneratePoint();
            } else
            {
                destination = hit.point;
            }
        }
    }

    public override State TryToChangeState()
    {
        // zmìna stavu na základì pozice hráèe
        var clds = Physics.OverlapSphere(
            agent.transform.position,
            RANGE
            );

        var symbol = clds.FirstOrDefault(
            cld => cld.GetComponentInParent<RPSSymbol>() 
            && cld.transform.parent != agent.transform
            );

        if(symbol != null)
        {
            Debug.Log(symbol.name, symbol.gameObject);
            return new AggroState(agent);
        }

        return this;
    }
}
