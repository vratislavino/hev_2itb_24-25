using NUnit.Framework;
using System.Collections.Generic;
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
        // zm�na stavu na z�klad� pozice hr��e
        var clds = Physics.OverlapSphere(
            agent.transform.position,
            RANGE
            );

        var symbolCol = clds.FirstOrDefault(
            cld => cld.GetComponentInParent<RPSSymbol>() 
            && cld.transform.parent != agent.transform
            );
        
        if(symbolCol != null)
        {
            var symbol = symbolCol.GetComponentInParent<RPSSymbol>();
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(symbol.CurrentSymbol);

            if(!wouldWin.HasValue)
            {
                return this;
            } else
            {
                if(wouldWin.Value)
                {
                    return new AggroState(agent);
                } else
                {
                    return new FleeState(agent);
                }
            }
        }

        return this;
    }
}
