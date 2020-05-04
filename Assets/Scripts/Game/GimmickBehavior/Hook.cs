using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class Hook : MonoBehaviour
{
    public string playerLayer = "Player";

    private bool isReleased;

    private Transform connectionTransform;
    private Rigidbody2D panRigidBody;
    private ObservableCollision2DTrigger searchAreaTrigger;

    [Inject]
    public void Construct(Transform connectionTransform, Rigidbody2D panRigidBody, ObservableCollision2DTrigger searchAreaTrigger)
    {
        this.isReleased = false;

        this.connectionTransform = connectionTransform;
        this.panRigidBody = panRigidBody;
        this.searchAreaTrigger = searchAreaTrigger;
    }

    private void Start()
    {
        this.panRigidBody.isKinematic = true;

        this.searchAreaTrigger
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
        this.panRigidBody.isKinematic = false;
        this.panRigidBody.AddForce(new Vector3(0f, -100f, 0f));
    }
}
