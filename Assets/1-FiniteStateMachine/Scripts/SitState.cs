using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitState : State
{
    public override void OnStateEnter(CharacterStateManager _characterManager)
    {
        _characterManager.Agent.enabled = false;
        _characterManager.transform.position = _characterManager.sit_point.position;
        _characterManager.Animator.SetBool("sit", true);

        Debug.Log("Started Sitting.");
        if (_characterManager.gameObject.TryGetComponent(out CharacterUIManager _chUIManager))
            _chUIManager.SetText("Sitting");

        
    }

    public override void OnStateExit(CharacterStateManager _characterManager)
    {
        _characterManager.Animator.SetBool("sit", false);
        Debug.Log("Finished Sitting.");
    }

    public override void OnStateStay(CharacterStateManager _characterManager)
    {
        Debug.Log("Sitting");
    }


}
