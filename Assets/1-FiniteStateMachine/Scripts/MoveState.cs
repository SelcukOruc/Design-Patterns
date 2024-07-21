using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public override void OnStateEnter(CharacterStateManager _characterManager)
    {
        _characterManager.Animator.SetBool("walk",true);
        Debug.Log("Started Moving!");
        if (_characterManager.gameObject.TryGetComponent(out CharacterUIManager _chUIManager))
            _chUIManager.SetText("Moving");
    }

    public override void OnStateExit(CharacterStateManager _characterManager)
    {
        _characterManager.Animator.SetBool("walk", false);
        Debug.Log("Exited Moving!");
    }

    public override void OnStateStay(CharacterStateManager _characterManager)
    {
        Debug.Log("Moving...");

        float _distance = _characterManager.Agent.remainingDistance;
        if (_distance < 0.2f)
        {
            _characterManager.SwitchState(_characterManager.sitstate);
        }
    }

  
}
