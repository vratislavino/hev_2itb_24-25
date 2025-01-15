using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    public AggroState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        Debug.Log("I am ready to attack your ass!");
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

        if (symbolCol != null)
        {
            var symbol = symbolCol.GetComponentInParent<RPSSymbol>();
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(symbol.CurrentSymbol);

            if (!wouldWin.HasValue)
            {
                return this;
            }
            else
            {
                if (wouldWin.Value)
                {
                    return new AggroState(agent);
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
