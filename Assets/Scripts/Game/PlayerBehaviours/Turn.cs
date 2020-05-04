using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Turn : MonoBehaviour
{
    public float inputToSpinRatio = 10f;

    private bool turnInput;
    private bool isTurned;
    private Transform targetTransform;
    private Move targetMove;
    private Jump targetJump;
    private BoxCollider2D targetBoxCollider2D;
    private Spin targetSpin;
    private CircleCollider2D targetCircleCollider2D;
    private Animator targetAnimator;

    [Inject]
    public void Construct(Transform targetTransform, Move targetMove, Jump targetJump, BoxCollider2D targetBoxCollider2D, Spin targetSpin, CircleCollider2D targetCircleCollider2D, Animator targetAnimator)
    {
        this.turnInput = false;
        this.isTurned = false;
        this.targetTransform = targetTransform;
        this.targetMove = targetMove;
        this.targetJump = targetJump;
        this.targetBoxCollider2D = targetBoxCollider2D;
        this.targetSpin = targetSpin;
        this.targetCircleCollider2D = targetCircleCollider2D;
        this.targetAnimator = targetAnimator;
    }

    private void Update()
    {
        var turnInput = false;

        if (Input.GetAxis("Fire1") > 0.5f)
        {
            turnInput = true;
        }

        if (this.turnInput != false || turnInput != true)
        {
            this.turnInput = turnInput;
            return;
        }

        if (this.isTurned)
        {
            this.isTurned = false;

            this.targetTransform.rotation = Quaternion.Euler(Vector3.zero);

            this.targetMove.enabled = true;
            this.targetJump.enabled = true;
            this.targetBoxCollider2D.enabled = true;

            this.targetSpin.enabled = false;
            this.targetCircleCollider2D.enabled = false;

            this.targetAnimator.SetTrigger("StandUp");
        }
        else
        {
            if (this.targetMove.IsMoving())
            {
                return;
            }

            this.isTurned = true;

            this.targetMove.enabled = false;
            this.targetJump.enabled = false;
            this.targetBoxCollider2D.enabled = false;

            this.targetSpin.enabled = true;
            this.targetCircleCollider2D.enabled = true;

            this.targetAnimator.SetTrigger("Turn");
        }

        this.turnInput = turnInput;
    }
}
