using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

namespace Character
{
    public class CharacterMovementStateMachine : StateMachine
    {
        public CharacterIdlingState IdlingState { get; }
        public CharacterRunningState RunningState { get; }

        public CharacterMovementStateMachine()
        {
            IdlingState = new CharacterIdlingState();
            RunningState = new CharacterRunningState();
        }
    }
}
