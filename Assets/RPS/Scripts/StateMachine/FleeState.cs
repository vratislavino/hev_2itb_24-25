using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    public FleeState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        Debug.Log("I am ready to leave your ass!");
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
