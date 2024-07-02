using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    private Quaternion desiredRotation;
    private float rotationSpeed = 5.0f;

    public GrappleGun grappleGun;


    void Update()
    {
        if(!grappleGun.isGrappling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappleGun.GrapplingPoint() - transform.position);
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
