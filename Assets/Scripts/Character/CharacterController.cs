using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        private CharacterMovementStateMachine movementStateMachine;

        private void Awake()
        {
            movementStateMachine = new CharacterMovementStateMachine();
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.FixedUpdate();
        }
    }
}
