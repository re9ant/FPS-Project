using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAble : MonoBehaviour
{
    public int maxHits;

    public GameObject destuctable;

    public GameObject Explode;

    public GameManger gameManger;

    private int i = 0;

    public void TakeDamage()
    {
        i++;

        if (i >= maxHits)
        {
            Instantiate(Explode, transform.position, Quaternion.identity);

            if(gameManger.canSpawnEnemyAgain)
            { Instantiate(destuctable, Vector3.zero, Quaternion.identity); }

            Destroy(destuctable);
        }

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().velocity = transform.forward * -9.0f;
        }

    }
}
