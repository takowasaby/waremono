using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public Player gamePlayer;

    public override void InstallBindings()
    {
        base.Container.Bind<Player>().FromInstance(this.gamePlayer).AsSingle();
    }
}