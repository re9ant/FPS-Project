using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    private Vector3 grapplePoint;
    private bool canApplyForce = true;
    private float maxGrappleDistance = 100.0f;
    private SpringJoint joint;
    private Rigidbody rb;
    private GameObject hitFXInstance;

    public LayerMask grappleLayer;
    public Transform gunTip, cam, player;
    public GameObject hitFX;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (joint != null)
            {
                Destroy(joint);
                Destroy(hitFXInstance);
            }
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        if (isGrappling() && canApplyForce)
        {
            rb.AddForce(player.forward * 20, ForceMode.Acceleration);
        }
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, grappleLayer))
        {
            hitFXInstance = Instantiate(hitFX, hit.point, Quaternion.identity);

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 55.5f;
            joint.damper = 75.0f;
            joint.massScale = 4.5f;
        }
    }

    private void StopGrapple()
    {
        if (hitFXInstance != null)
        {
            Destroy(hitFXInstance);
        }
        Destroy(joint);
    }

    public bool isGrappling()
    {
        return joint != null;
    }

    public Vector3 GrapplingPoint()
    {
        return grapplePoint;
    }

}
