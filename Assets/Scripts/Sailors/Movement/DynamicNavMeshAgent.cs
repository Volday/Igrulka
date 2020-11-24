using UnityEngine;

public class DynamicNavMeshAgent : MonoBehaviour
{
    public Transform targetSurface;
    public Transform navMeshSurface;

    private AvatarNavMeshAgent avatarNavMeshAgent;

    private Transform targetTransform;
    
    private void Awake()
    {
        SetUpAgent();
    }

    private void Update()
    {
        Move();
    }

    public void SetUpAgent()
    {
        transform.parent = targetSurface;

        GameObject targetPoint = new GameObject(gameObject.name + "TargetPoint");
        targetPoint.transform.parent = transform;
        targetPoint.transform.position = transform.position;
        targetTransform = targetPoint.transform;

        SetUpAvatar();
    }

    public void SetUpAvatar() {
        GameObject avatar = new GameObject(gameObject.name + "Avatar");

        avatar.transform.parent = navMeshSurface;
        avatar.transform.localPosition = transform.localPosition;

        avatarNavMeshAgent = avatar.AddComponent<AvatarNavMeshAgent>();
        avatarNavMeshAgent.Initialization();
    }

    void Move() {
        transform.localPosition = avatarNavMeshAgent.transform.localPosition;
    }

    void SetTarget(Vector3 target) {
        targetTransform.position = target;
        targetTransform.RotateAround(targetSurface.position, new Vector3(0, 1, 0), -targetSurface.eulerAngles.y);
        Vector3 targetOnNavMesh = (targetTransform.position - targetSurface.position) + navMeshSurface.position;

        avatarNavMeshAgent.SetTarget(targetOnNavMesh);
    }
}
