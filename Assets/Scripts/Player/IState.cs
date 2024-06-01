using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    public virtual void Enter()
    {
        // code that runs when we first enter the state
    }

    public virtual void Update()
    {
        // per-frame logic, include condition to transition to a new state
    }

    public virtual void Exit()
    {
        // code that runs when we exit the state
    }
    
    //LogicUpdate handles input handling, AI behavior, and state transitions
    void LogicUpdate();
    // PhysicisUpdate 
    void PhysicsUpdate();
}
