using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public Move playerMove;
    public Jump playerJump;
    public BoxCollider2D playerBoxCollider2D;
    public Spin playerSpin;
    public CircleCollider2D playerCircleCollider2D;
    public Animator playerAnimator;
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public ObservableCollision2DTrigger playerCollisionTrigger;

    public override void InstallBindings()
    {
        base.Container.Bind<Move>().FromInstance(this.playerMove).AsSingle();
        base.Container.Bind<Jump>().FromInstance(this.playerJump).AsSingle();
        base.Container.Bind<BoxCollider2D>().FromInstance(this.playerBoxCollider2D).AsSingle();
        base.Container.Bind<Spin>().FromInstance(this.playerSpin).AsSingle();
        base.Container.Bind<CircleCollider2D>().FromInstance(this.playerCircleCollider2D).AsSingle();
        base.Container.Bind<Animator>().FromInstance(this.playerAnimator).AsSingle();
        base.Container.Bind<Transform>().FromInstance(this.playerTransform).AsSingle();
        base.Container.Bind<Rigidbody2D>().FromInstance(this.playerRigidbody).AsSingle();
        base.Container.Bind<ObservableCollision2DTrigger>().FromInstance(this.playerCollisionTrigger).AsSingle();
    }
}