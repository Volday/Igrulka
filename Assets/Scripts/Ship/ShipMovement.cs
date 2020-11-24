using UnityEngine;

[RequireComponent(typeof(ShipMovementData))]
public class ShipMovement : MonoBehaviour
{
    public bool autoSteeringWheelReturn;
    private bool hasRotationInput;
    
    private float currentSpeed = 0;
    private float rotationAngle = 0;

    private ShipMovementData shipMovementData;

    private void Awake()
    {
        shipMovementData = GetComponent<ShipMovementData>();
    }

    private void Update()
    {
        Rotate();
        MoveForward();
    }

    private void MoveForward() 
    {
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        currentSpeed *= 1 - (shipMovementData.resistiveForce 
            + shipMovementData.additionalResistiveForceWhileRotate * Mathf.Abs(rotationAngle)) * Time.deltaTime;
    }

    private void Rotate()
    {
        float maxPotentialSpeed = shipMovementData.GetShipForce() / shipMovementData.resistiveForce;
        float angleToRotate = rotationAngle * (currentSpeed / maxPotentialSpeed) * Time.deltaTime;

        transform.RotateAround(transform.position + transform.forward * shipMovementData.shipLength / 2, 
            new Vector3(0, 1, 0), angleToRotate);

        if (autoSteeringWheelReturn && !hasRotationInput)
        {
            rotationAngle -= angleToRotate;
        }

        hasRotationInput = false;
    }

    /// <summary>
    /// Accelerates the ship
    /// </summary>
    /// <param name="direction">Accelerates in positive direction, and decelerates in negative direction</param>
    public void AddShipForce(float direction) 
    {
        currentSpeed += direction * shipMovementData.GetShipForce() * Time.deltaTime;

        if (currentSpeed > shipMovementData.maxForwardSpeed)
        {
            currentSpeed = shipMovementData.maxForwardSpeed;
        }
        else if (currentSpeed < -shipMovementData.maxBackSpeed)
        {
            currentSpeed = -shipMovementData.maxBackSpeed;
        }
    }


    /// <summary>
    /// Shift the rudder of a ship
    /// </summary>
    /// <param name="direction">Increase the angle in positive direction, and decrease in negative direction</param>
    public void AddRotationAngle(float direction) 
    {
        rotationAngle += direction * shipMovementData.rudderSpeed * Time.deltaTime;

        if (rotationAngle > shipMovementData.maxRotationSpeed)
        {
            rotationAngle = shipMovementData.maxRotationSpeed;
        }
        else if (rotationAngle < -shipMovementData.maxRotationSpeed)
        {
            rotationAngle = -shipMovementData.maxRotationSpeed;
        }

        hasRotationInput = direction != 0 ? true : false;
    }
}
