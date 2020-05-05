using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using UniRx;

public enum CrackStage
{
    NoCrack,
    Cracked,
}

public class Crack : MonoBehaviour
{
    public string[] ignoreLayers = new string[] { "InvisibleWall" };
    public float crackDurabilityMax = 100f;
    public float breakCountMax = 2;
    public float turnDamageRatio = 5f;

    public GameObject[] pieces;

    private float crackDurability;
    private CrackStage crackStage;
    private int breakCount;

    private Turn targetTurn;
    private Transform targetTransform;
    private ObservableCollision2DTrigger targetCollisionTrigger;
    private Animator targetAnimator;

    [Inject]
    public void Construct(Turn targetTurn, Transform targetTransform, ObservableCollision2DTrigger targetCollisionTrigger, Animator targetAnimator)
    {
        this.crackDurability = this.crackDurabilityMax;
        this.crackStage = CrackStage.NoCrack;
        this.breakCount = 0;

        this.targetTurn = targetTurn;
        this.targetTransform = targetTransform;
        this.targetCollisionTrigger = targetCollisionTrigger;
        this.targetAnimator = targetAnimator;
    }

    private void Start()
    {
        this.targetTurn
            .OnTurningAsObservable()
            .Subscribe(_ => this.OnTurn());

        this.targetCollisionTrigger
            .OnCollisionEnter2DAsObservable()
            .Subscribe(this.OnCollision);
    }

    private void Update()
    {
        // Debug.Log(this.crackDurability);

        if (this.crackDurability <= 0f && this.breakCount < this.breakCountMax)
        {
            this.TransitionCrackStage();
            this.crackDurability = this.crackDurabilityMax;
        }
    }

    private void TransitionCrackStage()
    {
        switch (this.crackStage)
        {
            case CrackStage.NoCrack:
                this.crackStage = CrackStage.Cracked;
                this.targetAnimator.SetInteger("CrackStage", 1);
                break;
            case CrackStage.Cracked:
                this.Break();
                this.crackStage = CrackStage.NoCrack;
                this.targetAnimator.SetInteger("CrackStage", 0);
                break;
        }
        this.targetAnimator.SetTrigger("Crack");
    }

    private void Break()
    {
        if (this.breakCount < this.pieces.Length)
        {
            var piece = this.pieces[this.breakCount];
            GameObject.Instantiate(piece, this.targetTransform.position + this.targetTransform.TransformDirection(piece.transform.position), this.targetTransform.rotation);
        }
        this.breakCount++;
        this.targetAnimator.SetInteger("BreakCount", this.breakCount);
    }

    private void OnTurn()
    {
        var cosAngle = Vector3.Dot(Vector3.right, this.targetTransform.up);
        if (Mathf.Abs(Mathf.Abs(cosAngle) - 1f) < 1e-4f)
        {
            return;
        }
        var turnAngle = Mathf.Acos(cosAngle);
        this.crackDurability -= turnAngle * this.turnDamageRatio;
    }

    private void OnCollision(Collision2D collision)
    {
        var layerMask = LayerMask.GetMask(this.ignoreLayers);

        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            return;
        }

        this.crackDurability -= collision.relativeVelocity.magnitude;
    }
}
