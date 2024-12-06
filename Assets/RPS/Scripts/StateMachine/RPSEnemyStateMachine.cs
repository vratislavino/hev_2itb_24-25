using UnityEngine;
using UnityEngine.AI;

public class RPSEnemyStateMachine : MonoBehaviour
{
    State currentState;

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        currentState = new WanderState(agent);
        currentState.EnterState();
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(); // iteration
            var newState = currentState.TryToChangeState();
            if(newState != currentState)
            {
                currentState = newState;
                currentState.EnterState();
            }
        } 
    }

    [ContextMenu("TEST")]
    public void Test()
    {
        if (currentState != null)
            Debug.Log((currentState as WanderState).currentDistance);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, currentState.Range);
        }
    }
}
