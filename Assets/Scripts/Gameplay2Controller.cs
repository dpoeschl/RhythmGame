using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections.Generic;

public class Gameplay2Controller : MonoBehaviour
{
    (int, int)[] song = new (int, int)[]
    {
        (0, 0),
        (500, 1),
        (1000, 2),
        (1500, 3),
        (2000, 4),
        (2500, 5),
        (3000, 6),
        (3500, 7),
        (4000, 8),
        (4250, 7),
        (4500, 6),
        (4750, 5),
        (5000, 4),
        (5250, 3),
        (5500, 2),
        (5750, 1),
        (6000, 0),
        (7000, 0),
        (7000, 2),
        (8000, 1),
        (8000, 3),
        (9000, 2),
        (9000, 4),
        (10000, 1),
        (10000, 3),
        (11000, 0),
        (11000, 2),
    };

    List<(GameObject, int)> notes = new List<(GameObject, int)>();

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

    private (KeyCode, GameObject, AudioClip)[] keyCodes;
    private bool[] previouslyHit = new bool[9];

    Stopwatch stopwatch;

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

        CreateAllNotes();

        stopwatch = Stopwatch.StartNew();
    }

    void Update()
    {
        MoveNotes();

        ProcessButtons();
    }

    private void ProcessButtons()
    {
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
            if (pressed)
            {
                columnController.Hit();
            }
            else
            {
                columnController.Default();
            }

            if (pressed && !previouslyHit[i])
            {
                ScaleNotes.Instance.AudioSource.PlayOneShot(clip);
            }

            previouslyHit[i] = pressed;
        }
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

            switch (column)
            {
                default:
                    GameObject panel = new GameObject("Panel");
                    panel.AddComponent<CanvasRenderer>();

                    RectTransform rectTransform = panel.AddComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0, 0.09f + time/2000f);
                    rectTransform.anchorMax = new Vector2(1, 0.11f + time/2000f);

                    rectTransform.offsetMin = Vector2.zero;
                    rectTransform.offsetMax = Vector2.zero;

                    Image i = panel.AddComponent<Image>();
                    i.color = color;

                    panel.transform.SetParent(parent.transform, false);

                    notes.Add((panel, time));

                    break;
            }
        }
    }

    private void MoveNotes()
    {
        var millis = stopwatch.ElapsedMilliseconds;

        foreach (var (gameObject, time) in notes)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0,0.09f + (time - millis) / 2000f);
            rectTransform.anchorMax = new Vector2(1,0.11f + (time - millis) / 2000f);
        }
    }
}
