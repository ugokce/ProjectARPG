using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHandIK : MonoBehaviour
{
    Animator animator;

    [Range(0f, 1f)]
    public float raycastRange;

    public Transform handBone;

    public LayerMask acceptedLayers;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        ApplyHandIK(AvatarIKGoal.RightHand, 1f, 1f, Vector3.zero);
    }

    Vector3 lastTruePos = Vector3.zero;
    Quaternion lastTrueRotation = Quaternion.identity;
    void ApplyHandIK(AvatarIKGoal hand, float positionWeight, float rotationWeight, Vector3 relativeCheckPoint)
    {
        if(animator)
        {
            animator.SetIKPositionWeight(hand, positionWeight);
            animator.SetIKRotationWeight(hand, rotationWeight);

            Debug.DrawRay(handBone.position, -handBone.forward, Color.blue);
            Physics.Raycast(handBone.position + relativeCheckPoint, -handBone.forward, out RaycastHit hit, raycastRange + 1f, acceptedLayers);

            if(hit.collider)
            {
                Debug.Log("kestiiiiiiii");
                Debug.DrawLine(handBone.position, hit.point, Color.red);
                
                lastTruePos += (transform.position - hit.point) * .5f;
                animator.SetIKPosition(hand,  Vector3.Lerp(animator.GetIKPosition(hand), lastTruePos, 0.1f));
                animator.SetIKRotation(hand, Quaternion.Lerp(animator.GetIKRotation(hand), lastTrueRotation, 0.1f));
            }
            else
            {
                lastTruePos = animator.GetIKPosition(hand);
                lastTrueRotation = animator.GetIKRotation(hand);
            }
        }
    }
}
