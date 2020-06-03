using UnityEngine;
using System;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections.Generic;

public class Gameplay2Controller : MonoBehaviour
{
    private class Note
    {
        public GameObject GameObject { get; set; }
        public int Button { get; set; }
        public int Time { get; set; }
    }

    List<Note> notes = new List<Note>();

    [SerializeField]
    private AudioClip maryHadFunClip = null;

    [SerializeField]
    private ScreenController screenController = null;

    [SerializeField]
    private GameObject leftWhite = null;

    [SerializeField]
    private GameObject leftYellow = null;

    [SerializeField]
    private GameObject leftGreen = null;

    [SerializeField]
    private GameObject leftBlue = null;

    [SerializeField]
    private GameObject centerRed = null;

    [SerializeField]
    private GameObject rightBlue = null;

    [SerializeField]
    private GameObject rightGreen = null;

    [SerializeField]
    private GameObject rightYellow = null;

    [SerializeField]
    private GameObject rightWhite = null;

    [SerializeField]
    private Text noteStreakText = null;

    [SerializeField]
    private Text scoreText = null;

    private (KeyCode, GameObject, AudioClip)[] keyCodes;
    private bool[] previouslyHit = new bool[9];

    Stopwatch stopwatch;

    int noteStreak = 0;
    double score = 0;

    double greatScore;
    double goodScore;
    private (int, int)[] song;

    void Start()
    {
        keyCodes = new (KeyCode, GameObject, AudioClip)[]
        {
            (KeyCode.JoystickButton0, leftWhite, ScaleNotes.Instance.C6),
            (KeyCode.JoystickButton1, leftYellow, ScaleNotes.Instance.D6),
            (KeyCode.JoystickButton5, leftGreen, ScaleNotes.Instance.E6),
            (KeyCode.JoystickButton2, leftBlue, ScaleNotes.Instance.F6),
            (KeyCode.JoystickButton4, centerRed, ScaleNotes.Instance.G6),
            (KeyCode.JoystickButton3, rightBlue, ScaleNotes.Instance.A6),
            (KeyCode.JoystickButton7, rightGreen, ScaleNotes.Instance.B6),
            (KeyCode.Joystick8Button19, rightYellow, ScaleNotes.Instance.C7), // HACK
            (KeyCode.JoystickButton6, rightWhite, ScaleNotes.Instance.D7)
        };
    }

    float scrollSpeed = 1.0f;

    internal void SetSong(int songIndex)
    {
        song = SongData.GetSongData(songIndex);
        CreateAllNotes();

        greatScore = 100000d / song.Length;
        goodScore = greatScore / 2;

        exited = false;
        started = true;
        stopwatch = Stopwatch.StartNew();

        if (songIndex == 2 || songIndex == 3)
        {
            ScaleNotes.Instance.AudioSource.clip = maryHadFunClip;
            ScaleNotes.Instance.AudioSource.Play();
        }
    }

    void Update()
    {
        if (started && !exited)
        {
            MoveNotes();

            ProcessButtons();

            UpdateText();
        }
    }

    private bool started = false;
    private bool exited = false;

    private void UpdateText()
    {
        noteStreakText.text = noteStreak.ToString();
        scoreText.text = Math.Round(score).ToString();
    }

    private void ProcessButtons()
    {
        if (Input.GetKey(KeyCode.JoystickButton9) && Input.GetKey(KeyCode.JoystickButton8))
        {
            ExitSong();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            scrollSpeed += 1f;
            if (scrollSpeed > 10)
            {
                scrollSpeed = 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            scrollSpeed -= 1f;
            if (scrollSpeed < 1)
            {
                scrollSpeed = 1;
            }
        }

        var millis = stopwatch.ElapsedMilliseconds;

        for (int i = 0; i < 9; i++)
        {
            var (keyCode, column, clip) = keyCodes[i];

            bool pressed;
            if (keyCode == KeyCode.Joystick8Button19)
            {
                pressed = Input.GetAxis("Vertical") == 1;
            }
            else
            {
                pressed = Input.GetKey(keyCode);
            }

            var columnController = column.GetComponent<ColumnController>();
            if (!pressed)
            {
                columnController.Default();
            }

            if (pressed && !previouslyHit[i])
            {
                bool hitANote = false;
                bool great = false;

                foreach (var note in notes)
                {
                    if(i == note.Button && Math.Abs(millis - note.Time) < 150)
                    {
                        hitANote = true;
                        great = Math.Abs(millis - note.Time) < 100;
                        note.Time = -1000000;
                        break;
                    }
                }

                if (hitANote)
                {
                    noteStreak++;

                    if (great)
                    {
                        score += greatScore;
                        columnController.HitGreat();
                    }
                    else
                    {
                        score += goodScore;
                        columnController.HitGood();
                    }
                }
                else
                {
                    columnController.Miss();
                }

                ScaleNotes.Instance.AudioSource.PlayOneShot(clip);
            }

            previouslyHit[i] = pressed;
        }
    }

    private void ExitSong()
    {
        exited = true;
        stopwatch.Stop();
        ScaleNotes.Instance.AudioSource.Stop();
        noteStreak = 0;
        score = 0;
        screenController.ShowScreen(GameScreen.SongMenu);
    }

    private void CreateAllNotes()
    {
        foreach (var (time, column) in song)
        {
            GameObject parent = null;
            Color color = default;
            switch(column)
            {
                case 0:
                    parent = leftWhite;
                    color = Color.white;
                    break;
                case 1:
                    parent = leftYellow;
                    color = Color.yellow;
                    break;
                case 2:
                    parent = leftGreen;
                    color = Color.green;
                    break;
                case 3:
                    parent = leftBlue;
                    color = Color.blue;
                    break;
                case 4:
                    parent = centerRed;
                    color = Color.red;
                    break;
                case 5:
                    parent = rightBlue;
                    color = Color.blue;
                    break;
                case 6:
                    parent = rightGreen;
                    color = Color.green;
                    break;
                case 7:
                    parent = rightYellow;
                    color = Color.yellow;
                    break;
                case 8:
                    parent = rightWhite;
                    color = Color.white;
                    break;
            }


            var notePanel = CreateNotePanel(color);
            notePanel.transform.SetParent(parent.transform, false);

            notes.Add(new Note { GameObject = notePanel, Button = column, Time = time });
        }
    }

    private GameObject CreateNotePanel(Color color)
    {
        GameObject notePanel = new GameObject("Panel");
        notePanel.AddComponent<CanvasRenderer>();
        RectTransform notePanelRectTransform = notePanel.AddComponent<RectTransform>();
        notePanelRectTransform.offsetMin = Vector2.zero;
        notePanelRectTransform.offsetMax = Vector2.zero;

        Image noteImage = notePanel.AddComponent<Image>();
        noteImage.color = color;

        GameObject centerPanel = new GameObject("Panel");
        centerPanel.AddComponent<CanvasRenderer>();
        RectTransform centerPanelRectTransform = centerPanel.AddComponent<RectTransform>();
        centerPanelRectTransform.offsetMin = Vector2.zero;
        centerPanelRectTransform.offsetMax = Vector2.zero;
        centerPanelRectTransform.anchorMin = new Vector2(0, 1/3f);
        centerPanelRectTransform.anchorMax = new Vector2(1, 2/3f);

        Image centerImage = centerPanel.AddComponent<Image>();
        centerImage.color = Color.white;

        centerPanel.transform.SetParent(notePanel.transform, false);

        return notePanel;
    }

    private void MoveNotes()
    {
        var millis = stopwatch.ElapsedMilliseconds;

        foreach (var note in notes)
        {
            if (note.Time != -1000000 &&  millis > (note.Time + 151))
            {
                note.Time = -1000000;
                noteStreak = 0;
            }

            RectTransform rectTransform = note.GameObject.GetComponent<RectTransform>();
            rectTransform.anchorMax = new Vector2(1,0.13f + ((note.Time - millis) / 4000f) * scrollSpeed);
            rectTransform.anchorMin = new Vector2(0,0.07f + ((note.Time - millis) / 4000f) * scrollSpeed);
        }
    }
}
