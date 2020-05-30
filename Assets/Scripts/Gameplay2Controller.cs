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

    private (KeyCode, GameObject)[] keyCodes;

    void Start()
    {
        keyCodes = new (KeyCode, GameObject)[]
        {
            (KeyCode.JoystickButton0, leftWhite),
            (KeyCode.JoystickButton1, leftYellow),
            (KeyCode.JoystickButton5, leftGreen),
            (KeyCode.JoystickButton2, leftBlue),
            (KeyCode.JoystickButton4, centerRed),
            (KeyCode.JoystickButton3, rightBlue),
            (KeyCode.JoystickButton7, rightGreen),
            (KeyCode.Joystick8Button19, rightYellow), // HACK
            (KeyCode.JoystickButton6, rightWhite),
        };
    }

    void Update()
    {
        foreach (var (keyCode, column) in keyCodes)
        {
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
                columnController.Miss();
            }
            else
            {
                columnController.Default();
            }
        }
    }
}
