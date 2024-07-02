using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    private float time = 0.0f;

    private void LateUpdate()
    {
        time += Time.deltaTime;
        if(time >= 1.0f)
        {
            Destroy(this.gameObject);            
        }
    }

    private void ontriggerEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(this.gameObject);
    }
}
