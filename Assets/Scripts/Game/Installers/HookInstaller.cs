using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class HookInstaller : MonoInstaller
{
    public Transform connectionTransform;
    public Rigidbody2D panRigidBody;
    public ObservableCollision2DTrigger searchAreaTrigger;

    public override void InstallBindings()
    {
        base.Container.Bind<Transform>().FromInstance(this.connectionTransform).AsSingle();
        base.Container.Bind<Rigidbody2D>().FromInstance(this.panRigidBody).AsSingle();
        base.Container.Bind<ObservableCollision2DTrigger>().FromInstance(this.searchAreaTrigger).AsSingle();
    }
}