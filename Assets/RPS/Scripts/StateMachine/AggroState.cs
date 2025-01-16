using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    private Transform target;

    public AggroState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        if(target == null)
            return;

        agent.SetDestination(target.position);
        Debug.Log("I am ready to attack your ass!");
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
                    return this;
                }
                else
                {
                    return new FleeState(agent);
                }
            }
        }

        return this;
    }
}
