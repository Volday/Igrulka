using UnityEngine;

public class ShipMovementData : MonoBehaviour
{
    public float maxForwardSpeed;
    public float maxBackSpeed;

    public float startShipForce;
    private float shipForce;

    [Range(0, 1)]
    public float resistiveForce;

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

    public void SetShipForce(float _shipForace)
    {
        shipForce = _shipForace; //Save to HDD;
    }
    #endregion
}
