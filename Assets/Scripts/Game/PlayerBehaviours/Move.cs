using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Move : MonoBehaviour
{
    public float inputToMoveRatio = 10f;

    private bool isMoving;
    private Transform targetTransform;
    private Rigidbody2D targetRigidBody;
    private Animator targetAnimator;

    [Inject]
    public void Construct(Transform targetTransform, Rigidbody2D targetRigidBody, Animator targetAnimator)
    {
        this.isMoving = false;
        this.targetTransform = targetTransform;
        this.targetRigidBody = targetRigidBody;
        this.targetAnimator = targetAnimator;
    }

    public bool IsMoving()
    {
        return this.isMoving;
    }

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");

        if (inputX != 0f)
        {
            this.isMoving = true;
            this.MoveTarget(inputX);
        }
        else
        {
            this.isMoving = false;
        }
    }

    private void MoveTarget(float inputX)
    {
        var moveX = inputX * this.inputToMoveRatio * Time.deltaTime;
        var moveVec = new Vector3(moveX, 0f, 0f); // this.targetTransform.right * moveX;

        this.targetRigidBody.AddForce(moveVec * 50f);
        // this.targetTransform.position = this.targetTransform.position + moveVec;

        this.targetAnimator.SetFloat("MoveX", Mathf.Abs(Vector3.Dot(this.targetTransform.right, moveVec)));
    }
}
