using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class KeyBoardInput : MonoBehaviour
{
    private ShipMovement shipMovement;

    private Camera cam;

    private void Awake()
    {
        shipMovement = GetComponent<ShipMovement>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        shipMovement.AddShipForce(Input.GetAxis("Vertical"));
        shipMovement.AddRotationAngle(Input.GetAxis("Horizontal"));

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) { 
            
        }
    }
}
