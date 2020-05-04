using UnityEngine;
using UniRx.Triggers;
using Zenject;

public class GimmickInstaller : MonoInstaller
{
    public ObservableCollision2DTrigger gimmickCollisionTrigger;

    public override void InstallBindings()
    {
        base.Container.Bind<ObservableCollision2DTrigger>().FromInstance(this.gimmickCollisionTrigger).AsSingle();
    }
}