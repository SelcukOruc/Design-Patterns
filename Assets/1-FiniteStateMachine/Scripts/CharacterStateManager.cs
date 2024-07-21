using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStateManager : MonoBehaviour
{
    public IdleState idlestate = new IdleState();
    public MoveState movestate = new MoveState();
    public SitState sitstate = new SitState();
    public State currentState;

    NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    public Transform sit_point;

    [SerializeField] private Animator animator;
    public Animator Animator => animator;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SwitchState(idlestate);
    }

    private void Update()
    {
        if (currentState == null)
            return;

        currentState.OnStateStay(this);
    }


    public void SwitchState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit(this);

        currentState = state;
        state.OnStateEnter(this);

    }

   
}
