using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureControllerController : MonoBehaviour
{
    [SerializeField]
    private ScreenController screenController = null;

    [SerializeField]
    private Text currentInputsText = null;

    public void OnBackButtonClicked()
    {
        screenController.ShowScreen(GameScreen.MainMenu);
    }

    private void Update()
    {
        string result = string.Empty;

        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(keyCode))
            {
                result += $"{keyCode.ToString()};";
            }
        }

        currentInputsText.text = result;
    }
}
