using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    private bool reseting;

    private SoundHolder soundHolder;
    private Player player;
    private Crack playerCrack;
    private Image fadeImage;

    [Inject]
    public void Construct(SoundHolder soundHolder, Player player, Crack playerCrack, Image fadeImage)
    {
        this.reseting = false;

        this.soundHolder = soundHolder;
        this.player = player;
        this.playerCrack = playerCrack;
        this.fadeImage = fadeImage;
    }

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        this.StartGame();
    }

    private void Update()
    {
        if (Input.GetAxis("Fire2") != 0f && this.reseting == false)
        {
            this.reseting = true;
            base.StartCoroutine("ResetGameRoutine");
        }
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
        this.soundHolder.bgm.Play();
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
        this.soundHolder.bgm.Stop();
        this.player.StopBehaviors();
        while (this.fadeImage.color.a < 1f)
        {
            var col = this.fadeImage.color;
            this.fadeImage.color = new Color(col.r, col.g, col.b, col.a + 0.02f);
            yield return null;
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                SceneManager.LoadScene("Scenes/GameTest0", LoadSceneMode.Single);
                break;
            case "GameTest0":
                SceneManager.LoadScene("Scenes/GameTest1", LoadSceneMode.Single);
                break;
            case "GameTest1":
                SceneManager.LoadScene("Scenes/Game", LoadSceneMode.Single);
                break;
        }
    }

    private IEnumerator ResetGameRoutine()
    {
        this.soundHolder.bgm.Stop();
        this.player.StopBehaviors();
        while (this.fadeImage.color.a < 1f)
        {
            var col = this.fadeImage.color;
            this.fadeImage.color = new Color(col.r, col.g, col.b, col.a + 0.02f);
            yield return null;
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                SceneManager.LoadScene("Scenes/Game", LoadSceneMode.Single);
                break;
            case "GameTest0":
                SceneManager.LoadScene("Scenes/GameTest0", LoadSceneMode.Single);
                break;
            case "GameTest1":
                SceneManager.LoadScene("Scenes/GameTest1", LoadSceneMode.Single);
                break;
        }
    }
}
