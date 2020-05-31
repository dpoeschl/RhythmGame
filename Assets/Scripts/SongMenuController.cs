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
}
