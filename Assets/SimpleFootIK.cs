using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.Rendering;

public class SimpleFootIK : MonoBehaviour
{
    Animator animator;

    [Range(0, 1f)]
    public float distanceToGround;

    [Range(0, 1f)]
    public float rotationWeight;

    public LayerMask acceptedLayers;
    public LayerMask obstacleLayer;

    public Vector3 leftFootCheckPoint;
    public Vector3 rightFootCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        ApplyFootIK(AvatarIKGoal.LeftFoot, 1f, rotationWeight, leftFootCheckPoint);
        ApplyFootIK(AvatarIKGoal.RightFoot, 1f, rotationWeight, rightFootCheckPoint);
    }

    private void ApplyFootIK(AvatarIKGoal foot, float positionWeight, float rotationWeight, Vector3 relativeCheckPoint)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(foot, positionWeight);
            animator.SetIKRotationWeight(foot, rotationWeight);

            Physics.Raycast(animator.GetIKPosition(foot) + relativeCheckPoint, Vector3.down, out RaycastHit hit, distanceToGround + 1f, acceptedLayers);

            if (hit.collider != null && hit.collider.CompareTag("Walkable"))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y += distanceToGround;
           
                animator.SetIKPosition(foot, targetPosition);
                animator.SetIKRotation(foot, Quaternion.LookRotation(transform.forward, hit.normal));

                Debug.DrawRay(animator.GetIKPosition(foot) + relativeCheckPoint, Vector3.down);
            }
        }
    }
}
