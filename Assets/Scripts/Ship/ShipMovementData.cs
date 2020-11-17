using UnityEngine;

public class ShipMovementData : MonoBehaviour
{
    public float maxForwardSpeed;
    public float maxBackSpeed;

    public float startShipForce;
    private float shipForce;

    [Range(0, 1)]
    public float resistiveForce;

    public float maxRotationSpeed;
    public float rudderSpeed;


    /// <summary>
    /// Decreasing speed for every degree per second
    /// </summary>
    [Range(0, 1)]
    public float additionalResistiveForceWhileRotate;

    private void Awake()
    {
        LoadShipForceData();
    }

    #region ShipForce
    private void LoadShipForceData()
    {
        shipForce = startShipForce; //Load from HDD;
    }

    public float GetShipForce()
    {
        return shipForce;
    }

    public void SetShipForce(float shipForce)
    {
        this.shipForce = shipForce; //Save to HDD;
    }
    #endregion
}
