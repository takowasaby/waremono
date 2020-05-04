using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class SoftFloorInstaller : MonoInstaller
{
    public ObservableCollision2DTrigger softFloorCollisionTrigger;

    public override void InstallBindings()
    {
        base.Container.Bind<ObservableCollision2DTrigger>().FromInstance(this.softFloorCollisionTrigger).AsSingle();
    }
}