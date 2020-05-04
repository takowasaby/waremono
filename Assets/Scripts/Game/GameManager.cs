using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Crack playerCrack;
    private Image fadeImage;

    [Inject]
    public void Construct(Player player, Crack playerCrack, Image fadeImage)
    {
        this.player = player;
        this.playerCrack = playerCrack;
        this.fadeImage = fadeImage;
    }

    private void Start()
    {
        this.StartGame();
    }

    public void StartGame()
    {
        base.StartCoroutine("StartGameRoutine");
    }

    public void EndGame()
    {
        base.StartCoroutine("EndGameRoutine");
    }

    private IEnumerator StartGameRoutine()
    {
        this.player.SetPosition(Vector3.zero);
        while (this.fadeImage.color.a > 0f)
        {
            var col = this.fadeImage.color;
            this.fadeImage.color = new Color(col.r, col.g, col.b, col.a - 0.02f);
            yield return null;
        }
        this.player.StartBehaviors();
    }

    private IEnumerator EndGameRoutine()
    {
        this.player.StopBehaviors();
        while (this.fadeImage.color.a < 1f)
        {
            var col = this.fadeImage.color;
            this.fadeImage.color = new Color(col.r, col.g, col.b, col.a + 0.02f);
            yield return null;
        }
        // TODO Result画面へ遷移
        SceneManager.LoadScene("Scenes/Game", LoadSceneMode.Single);
    }
}
