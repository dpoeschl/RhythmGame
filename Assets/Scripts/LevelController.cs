using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour {
    public GameObject[] notePrefabs = new GameObject[5]; // [0 - 4] = [White --> Red] 
    public GameObject hitbar;

    private System.Random random = new System.Random();

	// Use this for initialization
	void Start () {
        InvokeRepeating("AddNote", 3, 0.2f);
    }

    private void AddNote()
    {
        var position = random.Next(1, 10);
        var prefabPosition = position <= 5 ? position - 1 : 9 - position;
        var note = Instantiate(notePrefabs[prefabPosition]);
        note.transform.parent = this.transform;

        var noteController = note.GetComponent<NoteController>();
        noteController.SetPosition(position);
    }

    // Update is called once per frame
    void Update () {               
    }
}
