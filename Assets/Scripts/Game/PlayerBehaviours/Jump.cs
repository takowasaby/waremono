using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using UniRx;

public class Jump : MonoBehaviour
{
    public string[] landingLayers = new string[] { "Ground" };
    public Vector2 jumpForce = new Vector2(0f, 100f);

    private bool isJump;

    private SoundHolder soundHolder;
    private Transform targetTransform;
    private Rigidbody2D targetRigidBody;
    private ObservableCollision2DTrigger targetCollisionTrigger;

    [Inject]
    public void Construct(SoundHolder soundHolder, Transform targetTransform, Rigidbody2D targetRigidBody, ObservableCollision2DTrigger targetCollisionTrigger)
    {
        this.isJump = true;

        this.soundHolder = soundHolder;
        this.targetTransform = targetTransform;
        this.targetRigidBody = targetRigidBody;
        this.targetCollisionTrigger = targetCollisionTrigger;
    }

    public bool IsJumping()
    {
        return this.isJump;
    }

    private void Start()
    {
        this.targetCollisionTrigger
            .OnCollisionEnter2DAsObservable()
            .Subscribe(this.Landing);
    }

    private void Update()
    {
        if (this.isJump == true)
        {
            return;
        }

        if (Input.GetAxis("Jump") != 0f)
        {
            this.StartJump();
        }
    }

    private void StartJump()
    {
        this.isJump = true;
        // var force = this.jumpForce.x * this.targetTransform.right + this.jumpForce.y * this.targetTransform.up;
        this.targetRigidBody.AddForce(this.jumpForce);
        this.soundHolder.jump.Play();
    }

    private void Landing(Collision2D collision)
    {
        var layerMask = LayerMask.GetMask(this.landingLayers);

        if (((1 << collision.gameObject.layer) & layerMask) == 0)
        {
            return;
        }

        this.isJump = false;
    }
}
