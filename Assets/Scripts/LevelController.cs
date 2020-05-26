using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour 
{    
    [SerializeField]
    private ScreenController screenController = null;

    public GameObject[] notePrefabs = new GameObject[5]; // [0 - 4] = [White --> Red] 
    public GameObject hitbar;

    private System.Random random = new System.Random();

	// Use this for initialization
	void Start () {
        InvokeRepeating("AddChord", 3, 0.7f);
    }

    private void AddChord()
    {
        if (!this.isActiveAndEnabled)
        {
            return;
        }

        var position1 = random.Next(1, 10);
        var position2 = random.Next(1,10);
        while (true)
        {
            if (position2 != position1)
            {
                break;
            }

            position2 = random.Next(1,10);
        }

        var position3 = random.Next(1,10);
        while (true)
        {
            if (position3 != position1 && position3 != position2)
            {
                break;
            }

            position3 = random.Next(1,10);
        }


        AddNote(position1);
        AddNote(position2);
        AddNote(position3);
    }

    void AddNote(int position)
    {
        var prefabPosition = position <= 5 ? position - 1 : 9 - position;
        var note = Instantiate(notePrefabs[prefabPosition]);
        note.transform.parent = this.transform;

        var noteController = note.GetComponent<NoteController>();
        noteController.SetPosition(position);
    }

    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            screenController.ShowScreen(GameScreen.SongMenu);
        }
    }
}
