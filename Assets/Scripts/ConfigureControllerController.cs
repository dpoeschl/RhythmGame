using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureControllerController : MonoBehaviour
{
    [SerializeField]
    private ScreenController screenController = null;

    public void OnBackButtonClicked()
    {
        screenController.ShowScreen(GameScreen.MainMenu);
    }
}
