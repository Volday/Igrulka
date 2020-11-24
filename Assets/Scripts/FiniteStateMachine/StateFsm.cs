using UnityEngine;

[CreateAssetMenu (menuName = "Finite State Machine/State")]
public class StateFsm : ScriptableObject
{
    public ActionFsm[] actions;
    public TransitionFsm[] transitions;

    public void UpdateState(StateControllerFsm controller) 
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateControllerFsm controller) 
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateControllerFsm controller) 
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].decision.Decide(controller)) 
            {
                controller.TrasitionToState(transitions[i].state);
                break;
            }
        }
    }
}
