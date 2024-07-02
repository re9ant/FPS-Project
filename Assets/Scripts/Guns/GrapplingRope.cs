using UnityEngine;

public class GrapplingRope : MonoBehaviour
{
    private Spring spring;
    public Vector3 currentGrapplePosition;

    public LineRenderer lr;
    public GrappleGun grappleGun;
    public int subDivision = 4;
    public float damper;
    public float strength;
    public float velocity;
    public float waveCount;
    public float waveHeight;
    public AnimationCurve effectCurve;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        spring = new Spring();
        spring.SetTarget(0);
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void DrawRope()
    {
        if (!grappleGun.isGrappling())
        {
            currentGrapplePosition = grappleGun.gunTip.position;
            spring.Reset();
            if (lr.positionCount > 0)
            {
                lr.positionCount = 0;
            }
            return;
        }

        if (lr.positionCount == 0)
        {
            spring.SetVelocity(velocity);
            lr.positionCount = subDivision + 1;
        }

        spring.SetDamper(damper);
        spring.SetStrength(strength);
        spring.Update(Time.deltaTime);

        Vector3 grapplePoint = grappleGun.GrapplingPoint();
        Vector3 gunTipPosition = grappleGun.gunTip.position;
        var up = Quaternion.LookRotation(grapplePoint - gunTipPosition.normalized) * Vector3.up;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grappleGun.GrapplingPoint(), Time.deltaTime * 12.0f);

        for (int i = 0; i < subDivision + 1; i++)
        {
            var delta = i / subDivision;
            var offSet = up * waveHeight * Mathf.Sin(delta * waveCount * Mathf.PI * spring.Value * effectCurve.Evaluate(delta));

            lr.SetPosition(i, Vector3.Lerp(gunTipPosition, currentGrapplePosition, delta) + offSet);
        }
    }
}
