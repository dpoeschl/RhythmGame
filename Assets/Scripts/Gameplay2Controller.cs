using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Gameplay2Controller : MonoBehaviour
{
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

    void Update()
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
}
