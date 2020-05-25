using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameScreen
{
    MainMenu,
    SongMenu,
    Gameplay,
    Results,
    ConfigureController
}

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuScreen = null;

    [SerializeField]
    private GameObject songMenuScreen = null;

    [SerializeField]
    private GameObject gameplayScreen = null;

    [SerializeField]
    private GameObject resultsScreen = null;

    [SerializeField]
    private GameObject configureControllerScreen = null;

    public void ShowScreen(GameScreen screen)
    {
        mainMenuScreen.SetActive(screen == GameScreen.MainMenu);
        songMenuScreen.SetActive(screen == GameScreen.SongMenu);
        gameplayScreen.SetActive(screen == GameScreen.Gameplay);
        resultsScreen.SetActive(screen == GameScreen.Results);
        configureControllerScreen.SetActive(screen == GameScreen.ConfigureController);
    }
}
