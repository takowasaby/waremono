using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public Player gamePlayer;
    public Crack playerCrack;

    public override void InstallBindings()
    {
        base.Container.Bind<Player>().FromInstance(this.gamePlayer).AsSingle();
        base.Container.Bind<Crack>().FromInstance(this.playerCrack).AsSingle();
    }
}