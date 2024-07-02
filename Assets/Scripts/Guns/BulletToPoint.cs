using UnityEngine;

public class BulletToPoint : MonoBehaviour
{
    public GameObject hook;
    public GrapplingRope grapplingRope;
    public GrappleGun grappleGun;

    void LateUpdate()
    {
        if (grappleGun.isGrappling())
        {
            hook.transform.position = grapplingRope.currentGrapplePosition;
        }
        else
        {
            hook.transform.position = hook.transform.parent.position;
        }
    }
}
