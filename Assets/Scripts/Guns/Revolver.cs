using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform firePos;
    public float maxFireDistance;

    [SerializeField] Animator gunObject;

    public GameObject projectileFX;

    private GameObject projectileFXInstance;

    public bool isRealoading = false;

    private int reloadHash;

    private void Start()
    {
        reloadHash = Animator.StringToHash("Reload");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (isRealoading)
                return;

            projectileFXInstance = Instantiate(projectileFX, firePos.position, Quaternion.identity) as GameObject;
            projectileFXInstance.transform.forward = firePos.forward;
            projectileFXInstance.GetComponent<ProjectileFX>().speed = 50;

            isRealoading = true;
            gunObject.SetTrigger(reloadHash);

            if (Physics.Raycast(firePos.position, firePos.forward, out RaycastHit hitInfo, maxFireDistance, layerMask))
            {
                projectileFXInstance.transform.LookAt(hitInfo.point);
                projectileFXInstance.GetComponent<ProjectileFX>().targetPos = hitInfo.point;
                projectileFXInstance.GetComponent<ProjectileFX>().targetNormal = hitInfo.point;
            }
        }
    }
}
