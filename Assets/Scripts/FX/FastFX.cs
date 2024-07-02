using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFX : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject FX;
    public Transform FXTransform;

    private GameObject FXInstance;
    private bool canInstansiate = true;

    void Update()
    {
        Debug.Log(rb.velocity.x);

        if ((rb.velocity.x >= 0.0f ) && canInstansiate)
        {
            FXInstance = Instantiate(FX, FXTransform);
            FXInstance.transform.localPosition = Vector3.zero;
            FX.transform.LookAt(rb.transform);

            canInstansiate = false;
        }

        else
        {
            //if (FXInstance != null)
            //{
            //    Destroy(FXInstance);

            //    canInstansiate = true;
            //}
        }

    }
}
