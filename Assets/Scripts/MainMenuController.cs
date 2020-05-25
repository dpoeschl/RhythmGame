using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private ScreenController screenController = null;

    public void OnConfigureButtonClicked()
    {
        screenController.ShowScreen(GameScreen.ConfigureController);
    }

    public void OnSongListButtonClicked()
    {
        screenController.ShowScreen(GameScreen.SongMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
