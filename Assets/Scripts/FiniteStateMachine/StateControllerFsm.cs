using UnityEngine;

public class StateControllerFsm : MonoBehaviour
{
    public StateFsm currentState;

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TrasitionToState(StateFsm nextState) 
    {
        currentState = nextState;
    }
}
