using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class HomingMissile : MonoBehaviour
{
    Transform nearestPlayer;
    [SerializeField] float scanAngle;
    [SerializeField] float scanDistance;
    [SerializeField] float maxCorrection;
    [SerializeField] float step = 0.25f;
    [SerializeField] float looseFocusAt = 1.3f;

    private void Update()
    {
        ScanForPlayers();
    }

    void FixedUpdate()
    {
        
        CorrectTrajectory();
    }

    void CorrectTrajectory()
    {
        if (nearestPlayer != null)
        {
            Vector3 correction = Vector3.RotateTowards(transform.forward, nearestPlayer.position-transform.position, maxCorrection*Mathf.Deg2Rad, 0.0f);
            Debug.Log(correction);
            transform.rotation = Quaternion.LookRotation(correction);
            if (Vector3.Distance(transform.position, nearestPlayer.position) < looseFocusAt)
            {
                nearestPlayer = null;
            }
        }
    }

    void ScanForPlayers()
    {
        if (nearestPlayer != null)
        {
            //return;
        }
        float angle = 0;
        while(angle <= scanAngle)
        {
            RaycastHit hit;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            Vector3 raycastDirection = rotation * transform.forward;
            if (Physics.Raycast(transform.position, raycastDirection, out hit, scanDistance))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    if (!hit.transform.GetComponent<PlayerWeapon>().isOwner(GetComponent<Projectile>().getOwnerID()))
                    {
                        if (nearestPlayer == null)
                        {
                            nearestPlayer = hit.transform;
                            return;
                        }
                    }
                }
               
            }

            if (angle < 1)
            {
                angle = Mathf.Abs(angle) + step;
            }
            else
            {
                angle = (-1* Mathf.Abs(angle) - step);
            }
        }
        nearestPlayer = null;
    }
}
