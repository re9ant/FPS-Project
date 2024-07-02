using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFXDestroyer : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
