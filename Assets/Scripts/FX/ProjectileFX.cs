using UnityEngine;

public class ProjectileFX : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPos;
    [HideInInspector] public float speed;

    [SerializeField] ParticleSystem[] particles;

    [SerializeField] GameObject hitFX;

    [HideInInspector] public Vector3 targetNormal;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

        foreach(ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    void Update()
    {
        if (targetPos == null)
        {
            return;
        }

        transform.position += transform.forward * (speed * Time.deltaTime);

        if(Vector3.Distance(startPos, transform.position) >= 300.0f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitFXInstance = Instantiate(hitFX, transform.position, Quaternion.identity);
        hitFXInstance.transform.forward = targetNormal;

        if (other.GetComponent<DamageAble>())
        {
            other.GetComponent<DamageAble>().TakeDamage();
        }

        Destroy(this.gameObject, 0.3f);
    }
}
