using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyDestoyer : MonoBehaviour
{
    private float time = 0.0f;

    private void LateUpdate()
    {
        time += Time.deltaTime;
        if(time >= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

}
