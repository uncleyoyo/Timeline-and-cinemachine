using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField]  float rotSpeed;
    [SerializeField]  float moveSpeed;
    [SerializeField]  float currentSpeed;
    float vertical;
    float horizontal;
    [SerializeField]  float maxRotate;
    [SerializeField]  GameObject shipModel;
    [SerializeField] Transform cockpitPOV;
    [SerializeField] Transform camerasparent;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentSpeed++;
            if (currentSpeed > 4)
            {
                currentSpeed = 4;
            }
        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            currentSpeed--;
            if (currentSpeed < 1)
            {
                currentSpeed = 1;
            }
        }//decrease speed

        Vector3 rotateH = new Vector3(0, horizontal, 0);
        transform.Rotate(rotateH * rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(vertical, 0, 0);
        transform.Rotate(rotateV * rotSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, -horizontal * 0.2f), Space.Self);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        // trying to get the angles to maintained and keep the model of the cockpit in the center.
        Vector3 cockpitRotation = new Vector3(0, transform.eulerAngles.y, 0);
        cockpitPOV.eulerAngles = cockpitRotation - new Vector3(0,0,camerasparent.eulerAngles.z);
    }
}
