using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class KeyBoardInput : MonoBehaviour
{
    private ShipMovement shipMovement;

    private void Awake()
    {
        shipMovement = GetComponent<ShipMovement>();
    }

    void Update()
    {
        shipMovement.AddShipForce(Input.GetAxis("Vertical"));
    }
}
