using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMenuController : MonoBehaviour
{
    [SerializeField]
    private ScreenController screenController = null;

    public void OnButtonClicked()
    {
        screenController.ShowScreen(GameScreen.Gameplay);
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
