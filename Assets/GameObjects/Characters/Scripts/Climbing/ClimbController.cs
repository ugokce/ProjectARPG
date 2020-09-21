using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public enum MoveState
{
    Obstacle,
    CanMove,
    NoGround
}

public class ClimbController : MonoBehaviour
{
    public Transform bottomChecker;
    public Transform frontChecker;
    public Transform headChecker;

    public Transform middleHelper;

    Rigidbody characterRigidbody;

    public MoveState frontState = MoveState.CanMove;
    public MoveState bottomState = MoveState.CanMove;
    public MoveState upState = MoveState.CanMove;

    public float raycastLength = 1f;
    public float surfaceDistance = 1f;
    public float positionLerping = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.getInstance().playerEvents.onPlayerMove.AddListener(OnMove);
       // characterRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        frontState = checkMoveState(frontChecker, frontChecker.forward, raycastLength, out RaycastHit hit);

        if (frontState == MoveState.CanMove)
        {
            Vector3 pos = hit.point + hit.normal.normalized * surfaceDistance;
            middleHelper.position = pos;

            pos.y = transform.position.y;
         
          //  characterRigidbody.isKinematic = true;
            transform.position = Vector3.Lerp(transform.position, pos, positionLerping);
            lookToNormal(-hit.normal.normalized);
        }
        else
        {
            StopClimbing();
        }
    }

    void lookToNormal(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    private void StopClimbing()
    {
        //characterRigidbody.isKinematic = false;
    }

    private void OnMove(Vector3 direction)
    {

    }

    private MoveState checkMoveState(Transform point, Vector3 direction, float distance, out RaycastHit hit)
    {
        if(Physics.Raycast(point.position, direction, out hit, distance))
        {
            if(hit.collider.tag == "Climbable")
            {
                return MoveState.CanMove;
            }

            return MoveState.Obstacle;
        }

        return MoveState.NoGround;
    }
}
