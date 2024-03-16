using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State S_currentState;
    public void InitState(State inicial)
    {
        inicial.enabled = true;
        S_currentState = inicial;
        inicial.Enter();
    }

    public void ChangeState(State Change)
    {
        S_currentState.Exid();
        S_currentState.enabled = false;
        S_currentState = Change;
        Change.enabled = true;
        Change.Enter();
    }
    public State ActualState()
    {
        return S_currentState;
    }
}
