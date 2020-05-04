using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class Goal : MonoBehaviour
{
    public string playerLayer = "Player";

    private GameManager gameManager;
    private ObservableCollision2DTrigger targetCollisionTrigger;

    [Inject]
    public void Construct(GameManager gameManager, ObservableCollision2DTrigger targetCollisionTrigger)
    {
        this.gameManager = gameManager;
        this.targetCollisionTrigger = targetCollisionTrigger;
    }

    private void Start()
    {
        this.targetCollisionTrigger
            .OnCollisionEnter2DAsObservable()
            .Where(this.IsPlayer)
            .Subscribe(_ => this.PlayerEnter());
    }

    private bool IsPlayer(Collision2D collision)
    {
        var layerMask = LayerMask.GetMask(this.playerLayer);
        return ((1 << collision.gameObject.layer) & layerMask) != 0;
    }

    private void PlayerEnter()
    {
        this.gameManager.EndGame();
    }
}
