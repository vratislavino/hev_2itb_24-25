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
        return this;
    }
}
