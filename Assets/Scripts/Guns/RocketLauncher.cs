using System.Collections;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public bool canCamShake = false;

    public GameObject bullet, blastFX, empty;

    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rbController;

    [HideInInspector] public GameObject emptyInstance;
    public Transform cam;
    public CameraShake camShake;
    public float range = 300;

    private bool canFire = true;
    private GameObject bulletInstance;
    private GameObject balstFXInstance;

    private void Update()
    {
        if (balstFXInstance != null)
        {
            Destroy(balstFXInstance, 3.0f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (canFire)
            {
                RaycastHit hit;
                if (!Physics.Raycast(cam.position, cam.forward, out hit, range))
                {
                    return;
                }
                emptyInstance = Instantiate(empty, hit.point, Quaternion.identity);
                bulletInstance = Instantiate(bullet);
                balstFXInstance = Instantiate(blastFX);
                balstFXInstance.transform.position = hit.point;

                bulletInstance.transform.SetParent(emptyInstance.transform);
                bulletInstance.transform.Translate(emptyInstance.transform.position);

                Collider[] rigidBodies = Physics.OverlapSphere(hit.point, 30.0f);
                foreach (Collider rb in rigidBodies)
                {
                    if (rb.GetComponent<Rigidbody>())
                    {
                        if (rb.gameObject.CompareTag("Player"))
                        {
                            rbController.jumpNow = true;
                            StartCoroutine(waitForNoJump());
                        }
                        rb.GetComponent<Rigidbody>().AddExplosionForce(50000.0f, hit.point, 300.0f);
                    }
                }

            }
        }
    }

    IEnumerator CanFire()
    {
        yield return new WaitForSeconds(0.3f);
        canFire = true;
    }

    IEnumerator waitForNoJump()
    {
        yield return new WaitForSeconds(0.2f);
        rbController.jumpNow = false;
    }

}
