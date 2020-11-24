using UnityEngine;

public abstract class ActionFsm : ScriptableObject
{
    public abstract void Act(StateControllerFsm controller);
}
