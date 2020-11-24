using UnityEngine;

public abstract class DecisionFsm : ScriptableObject
{
    public abstract bool Decide(StateControllerFsm controller);
}
