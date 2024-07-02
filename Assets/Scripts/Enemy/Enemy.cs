using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float thrust = 1000.0f;
    public Transform bulletsFrom;
    public GameObject player;
    public GameObject bullet;
    public MeshRenderer screen;
    public Material greenMaterial;

    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public bool canMakePath = true;
    [HideInInspector] public bool isUsingVelocity = true;

    private float currFireRate = 0f;
    private GameObject bulletInstance;
    private bool canFire = true;
    private Material redMaterial;

    [HideInInspector] public Vector3 force = Vector3.zero;

    [HideInInspector] public bool canChase = true;

    private ForceMode forceMode = ForceMode.Acceleration;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        redMaterial = screen.material;
    }

    void Update()
    {
        if (!canChase)
            return;

        if(isUsingVelocity)
        {
            rb.velocity = transform.forward * 9.0f;
        }

        canMakePath = (Vector3.Distance(transform.position, player.transform.position) > 3.0f);

        if (Vector3.Distance(transform.position, player.transform.position) <= 25.0f)
        { Fire(); }

        transform.LookAt(player.transform);
        Vector3 targetLocation = player.transform.position - transform.position;

        float distance = targetLocation.magnitude;

        force = transform.forward * Mathf.Clamp((distance - 3) / 100, 0.0f, 1.0f) * thrust;

        if(!isUsingVelocity)
        {
            rb.AddRelativeForce(force, ForceMode.Acceleration);
        }
    }

    private void Fire()
    {
        if(canFire)
        {
            bulletInstance = Instantiate(bullet, bulletsFrom.position, bullet.transform.rotation);
            bulletInstance.GetComponent<Bullet>().target = player.transform;
        }
    }
}
