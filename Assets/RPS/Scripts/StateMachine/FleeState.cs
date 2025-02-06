using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    private Transform target = null;

    public FleeState(NavMeshAgent agent) : base(agent)
    {
        Debug.Log("I am ready to leave your ass!");
    }

    public override void UpdateState()
    {
        if(target == null)
            return;

        Vector3 goPoint = target.position - agent.transform.position;
        agent.SetDestination(goPoint);
    }

    public override State TryToChangeState()
    {
        // zmìna stavu na základì pozice hráèe
        var clds = Physics.OverlapSphere(
            agent.transform.position,
            RANGE
            );

        var symbolCol = clds.FirstOrDefault(
            cld => cld.GetComponentInParent<RPSSymbol>()
            && cld.transform.parent != agent.transform
            );

        if (symbolCol != null)
        {
            var symbol = symbolCol.GetComponentInParent<RPSSymbol>();
            target = symbol.transform;
            
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(symbol.CurrentSymbol);

            if (!wouldWin.HasValue)
            {
                return new WanderState(agent);
            }
            else
            {
                if (wouldWin.Value)
                {
                    return new AggroState(agent);
                }
                else
                {
                    return this;
                }
            }
        }

        return this;
    }
}
