using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public Player gamePlayer;
    public Crack playerCrack;
    public Image fadeImage;
    public GameManager gameManager;

    public override void InstallBindings()
    {
        base.Container.Bind<Player>().FromInstance(this.gamePlayer).AsSingle();
        base.Container.Bind<Crack>().FromInstance(this.playerCrack).AsSingle();
        base.Container.Bind<Image>().FromInstance(this.fadeImage).AsSingle();
        base.Container.Bind<GameManager>().FromInstance(this.gameManager).AsSingle();
    }
}