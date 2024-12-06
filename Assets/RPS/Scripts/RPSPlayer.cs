using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RPSPlayer : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    RPSSymbol symbol;
    Animator animator;

    [SerializeField]
    float symbolChangeTime = 5f;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        symbol = GetComponent<RPSSymbol>();
        animator = GetComponent<Animator>();
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

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
