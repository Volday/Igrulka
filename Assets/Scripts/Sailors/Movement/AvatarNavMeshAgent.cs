using UnityEngine;
using UnityEngine.AI;

public class AvatarNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public void Initialization() {
        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
    }

    public void SetTarget(Vector3 target) {
        navMeshAgent.SetDestination(target);
    }
}
