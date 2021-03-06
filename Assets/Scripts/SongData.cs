﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData
{
    public static (int, int)[] GetSongData(int songChoice)
    {
        switch (songChoice)
        {
            case 0:
                return Song0;
            case 1:
                return Song1;
            case 2:
                return Song2;
            case 3:
                return Song3;
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

    private static readonly (int, int)[] Song2 = new (int, int)[]
{
        (0, 2),
        (250, 1),
        (500, 0),
        (750, 1),
        (1000, 2),
        (1250, 2),
        (1500, 2),
        (2000, 1),
        (2250, 1),
        (2500, 1),
        (3000, 2),
        (3250, 4),
        (3500, 4),
        (4000, 2),
        (4250, 1),
        (4500, 0),
        (4750, 1),
        (5000, 2),
        (5250, 2),
        (5500, 2),
        (5750, 2),
        (6000, 1),
        (6250, 1),
        (6500, 2),
        (6750, 1),
        (7000, 0),
        (8000, 0),
        (8125, 2),
        (8250, 1),
        (8375, 3),
        (8500, 2),
        (8625, 4),
        (8750, 3),
        (8875, 5),
        (9000, 4),
        (9125, 6),
        (9250, 5),
        (9375, 7),
        (9500, 6),
        (9625, 8),
        (9750, 7),
    };

    private static readonly (int, int)[] Song3 = new (int, int)[]
    {
        (0, 0),
        (500, 1),
        (1000, 2),
        (1500, 3),
        (2000, 4),
        (2500, 5),
        (3000, 6),
        (3500, 7),
        (4000, 7),
        (4500, 6),
        (5000, 5),
        (5500, 4),
        (6000, 3),
        (6500, 2),
        (7000, 1),
        (7500, 0),
        (8000, 0),
        (8500, 1),
        (9000, 2),
        (9500, 3),
        (10000, 4),
        (10500, 5),
        (11000, 6),
        (11500, 7),
        (12000, 7),
        (12500, 6),
        (13000, 5),
        (13500, 4),
        (14000, 3),
        (14500, 2),
        (15000, 1),
        (15500, 0),
        (16000, 0),
        (16000, 2),
        (16000, 4),
        (16000, 7),
    };
}
