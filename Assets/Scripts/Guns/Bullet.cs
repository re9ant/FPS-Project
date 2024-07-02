using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    private Rigidbody rb;

    private void Start()
    {
        StartCoroutine(Destroy());
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(target);
        rb.AddForce(transform.forward * 2, ForceMode.VelocityChange);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
