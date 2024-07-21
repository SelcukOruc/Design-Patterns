using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void OnStateEnter(CharacterStateManager _characterManager)
    {
        _characterManager.Animator.SetBool("walk", false);
        _characterManager.Animator.SetBool("sit", false);

        if (_characterManager.gameObject.TryGetComponent(out CharacterUIManager _chUIManager))
            _chUIManager.SetText("Idle");
    }

    public override void OnStateExit(CharacterStateManager _characterManager)
    {
    }

    public override void OnStateStay(CharacterStateManager _characterManager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _characterManager.Agent.SetDestination(_characterManager.sit_point.position);
            _characterManager.SwitchState(_characterManager.movestate);
        }
    }


}
