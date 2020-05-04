using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private Transform targetTransform;
    private Move targetMove;
    private Jump targetJump;
    private BoxCollider2D targetBoxCollider2D;
    private Spin targetSpin;
    private CircleCollider2D targetCircleCollider2D;
    private Turn targetTurn;

    [Inject]
    public void Construct(Transform targetTransform, Move targetMove, Jump targetJump, BoxCollider2D targetBoxCollider2D, Spin targetSpin, CircleCollider2D targetCircleCollider2D, Turn targetTurn)
    {
        this.targetTransform = targetTransform;
        this.targetMove = targetMove;
        this.targetJump = targetJump;
        this.targetBoxCollider2D = targetBoxCollider2D;
        this.targetSpin = targetSpin;
        this.targetCircleCollider2D = targetCircleCollider2D;
        this.targetTurn = targetTurn;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
    }

    public Vector2 GetPosition()
    {
        return this.targetTransform.position;
    }

    public Vector2 SetPosition(Vector3 position)
    {
        return this.targetTransform.position = position;
    }

    public void StartBehaviors()
    {
        this.targetMove.enabled = true;
        this.targetJump.enabled = true;
        this.targetBoxCollider2D.enabled = true;
        this.targetSpin.enabled = false;
        this.targetCircleCollider2D.enabled = false;
        this.targetTurn.enabled = true;
    }

    public void StopBehaviors()
    {
        this.targetMove.enabled = false;
        this.targetJump.enabled = false;
        this.targetSpin.enabled = false;
        this.targetTurn.enabled = false;
    }
}
