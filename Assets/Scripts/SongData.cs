using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData : MonoBehaviour
{
    public static (int, int)[] GetSongData(int songChoice)
    {
        switch (songChoice)
        {
            case 0:
                return Song0;
            case 1:
                return Song1;
            default:
                return null;
        }
    }

    private static readonly (int, int)[] Song0 = new (int, int)[]
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
        (11000, 2)
    };

    private static readonly (int, int)[] Song1 = new (int, int)[]
    {
        (0, 0),
        (500, 8),
        (1000, 1),
        (1500, 7),
        (2000, 2),
        (2500, 6),
        (3000, 3),
        (3500, 5),
        (4000, 4),
        (4250, 5),
        (4500, 3),
        (4750, 6),
        (5000, 2),
        (5250, 7),
        (5500, 1),
        (5750, 8),
        (6000, 0),
        (7000, 0),
        (7000, 2),
        (7000, 4),
        (8000, 1),
        (8000, 3),
        (8000, 5),
        (9000, 2),
        (9000, 4),
        (9000, 6),
        (10000, 1),
        (10000, 3),
        (10000, 5),
        (11000, 0),
        (11000, 2),
        (11000, 4)
    };
}
