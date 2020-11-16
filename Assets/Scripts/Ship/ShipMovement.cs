using UnityEngine;

[RequireComponent(typeof(ShipMovementData))]
public class ShipMovement : MonoBehaviour
{
    private float currentSpeed = 0;

    private ShipMovementData shipMovementData;

    private void Awake()
    {
        shipMovementData = GetComponent<ShipMovementData>();
    }

    private void Update()
    {
        MoveForward();
        Debug.Log(currentSpeed);
    }

    private void MoveForward() {
        currentSpeed *= 1 - shipMovementData.resistiveForce * Time.deltaTime;

        transform.position += transform.forward * currentSpeed;
    }

    public void AddShipForce(float _direction) {
        currentSpeed += _direction * shipMovementData.GetShipForce() * Time.deltaTime;

        if (currentSpeed > shipMovementData.maxForwardSpeed)
        {
            currentSpeed = shipMovementData.maxForwardSpeed;
        }
        else if (currentSpeed < -shipMovementData.maxBackSpeed)
        {
            currentSpeed = -shipMovementData.maxBackSpeed;
        }
    }
}
