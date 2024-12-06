using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;
    protected const float RANGE = 5f;
    public float Range => RANGE;

    public State(NavMeshAgent agent) { 
        this.agent = agent;
    }

    public virtual void EnterState() {  }

    public abstract void UpdateState();

    public abstract State TryToChangeState();
}
