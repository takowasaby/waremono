using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class SoftFloor : MonoBehaviour
{
    public float reductionRatio = 0.1f;
    public string playerLayer = "Player";

    private Crack playerCrack;
    private ObservableCollision2DTrigger targetCollisionTrigger;

    [Inject]
    public void Construct(Crack playerCrack, ObservableCollision2DTrigger targetCollisionTrigger)
    {
        this.playerCrack = playerCrack;
        this.targetCollisionTrigger = targetCollisionTrigger;
    }

    private void Start()
    {
        this.targetCollisionTrigger
            .OnTriggerEnter2DAsObservable()
            .Where(this.IsPlayer)
            .Subscribe(_ => this.PlayerEnter());

        this.targetCollisionTrigger
            .OnTriggerExit2DAsObservable()
            .Where(this.IsPlayer)
            .Subscribe(_ => this.PlayerExit());
    }

    private bool IsPlayer(Collider2D collision)
    {
        var layerMask = LayerMask.GetMask(playerLayer);
        return ((1 << collision.gameObject.layer) & layerMask) != 0;
    }

    private void PlayerEnter()
    {
        this.playerCrack.turnDamageRatio *= this.reductionRatio;
    }

    private void PlayerExit()
    {
        this.playerCrack.turnDamageRatio /= this.reductionRatio;
    }
}
