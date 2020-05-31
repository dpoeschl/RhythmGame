using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMenuController : MonoBehaviour
{
    [SerializeField]
    private ScreenController screenController = null;

    public void OnButton0Clicked()
    {
        screenController.ShowGameScreen(0);
    }

    public void OnButton1Clicked()
    {
        screenController.ShowGameScreen(1);
    }

    public void OnButton2Clicked()
    {
        screenController.ShowGameScreen(2);
    }

    public void OnButton3Clicked()
    {
        screenController.ShowGameScreen(3);
    }
}
