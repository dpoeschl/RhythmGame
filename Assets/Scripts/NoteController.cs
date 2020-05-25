using UnityEngine;
using System.Collections;
using System;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public int position; // 1-9
    private KeyCode keycode;
    private bool hit = false;
    private bool resultPrinted = false;

    private static KeyCode[] keyCodes = 
        {
            default(KeyCode),
            KeyCode.A,
            KeyCode.W,
            KeyCode.S,
            KeyCode.E,
            KeyCode.D,
            KeyCode.R,
            KeyCode.F,
            KeyCode.T,
            KeyCode.G,
        };

    internal void SetPosition(int v)
    {
        position = v;
        keycode = keyCodes[position];

        // set x position
        // set y position (already done, refactor to here)

        float xPosition = 0;
        switch(position)
        {
            case 1: xPosition = -2f; break;
            case 2: xPosition = -1.5f; break;
            case 3: xPosition = -1f; break;
            case 4: xPosition = -0.5f; break;
            case 5: xPosition = -0f; break;
            case 6: xPosition = 0.5f; break;
            case 7: xPosition = 1f; break;
            case 8: xPosition = 1.5f; break;
            case 9: xPosition = 2f; break;
        }

        transform.position = new Vector3(xPosition, GameObject.Find("hitbar").transform.position.y + 9, 0);
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(keycode))
        {
            var targetY = GameObject.Find("hitbar").transform.position.y;
            var myY = transform.position.y;

            var delta = Mathf.Abs(targetY - myY);
            if (delta <= 0.5)
            {
                // HIT!
                var hitName = "BAD";
                if (delta <= 0.4) { hitName = "OK"; }
                if (delta <= 0.3) { hitName = "GOOD"; }
                if (delta <= 0.2) { hitName = "GREAT"; }
                if (delta <= 0.1) { hitName = "PERFECT"; }

                var sign = myY >= targetY ? "+" : "-";
                var printAmount = ((int)(100 * Mathf.Abs(targetY - myY))) / 100f;

                print(hitName + "(" + position + "): " + sign + printAmount);

                Vector3 offScreenPosition = new Vector3(transform.position.x, transform.position.y - 100f, 0.0f);
                GetComponent<Rigidbody2D>().MovePosition(offScreenPosition);
                hit = true;

                switch (position)
                {
                    case 1:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.C6);
                        break;
                    case 2:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.D6);
                        break;
                    case 3:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.E6);
                        break;
                    case 4:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.F6);
                        break;
                    case 5:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.G6);
                        break;
                    case 6:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.A6);
                        break;
                    case 7:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.B6);
                        break;
                    case 8:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.C7);
                        break;
                    case 9:
                        ScaleNotes.Instance.AudioSource.PlayOneShot(ScaleNotes.Instance.D7);
                        break;
                }

                return;
            }
            else
            {
                // print("     MISS(" + position + ")");
            }
        }
    }

    // FixedUpdate is called once per physics timestep
    void FixedUpdate()
    {
        if (hit && transform.position.y > -1000)
        {
            Vector3 nextPosition = new Vector3(transform.position.x, transform.position.y - 2000f, 0.0f);
            GetComponent<Rigidbody2D>().MovePosition(nextPosition);
        }

        if (!hit && transform.position.y > -1000)
        {
            if (transform.position.y < -3)
            {
                // TOTAL MISS;
                if (!resultPrinted)
                {
                    resultPrinted = true;
                    print("MISS(" + position + ")");
                }

                Vector3 nextPosition = new Vector3(transform.position.x, transform.position.y - 2000f, 0.0f);
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);
            }
            else
            {
                Vector3 nextPosition = new Vector3(transform.position.x, transform.position.y - 0.07f, 0.0f);
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);
            }
        }
    }
}
