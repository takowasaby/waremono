using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class Abyss : MonoBehaviour
{
    public string playerLayer = "Player";

    private Player player;
    private ObservableCollision2DTrigger targetCollisionTrigger;

    [Inject]
    public void Construct(Player player, ObservableCollision2DTrigger targetCollisionTrigger)
    {
        this.player = player;
        this.targetCollisionTrigger = targetCollisionTrigger;
    }

    private void Start()
    {
        this.targetCollisionTrigger
            .OnTriggerEnter2DAsObservable()
            .Where(this.IsPlayer)
            .Subscribe(_ => this.PlayerEnter());
    }

    private bool IsPlayer(Collider2D collision)
    {
        var layerMask = LayerMask.GetMask(this.playerLayer);
        return ((1 << collision.gameObject.layer) & layerMask) != 0;
    }

    private void PlayerEnter()
    {
        this.player.SetPosition(Vector3.zero);
    }
}
