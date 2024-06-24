using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapContainer :  MonoSingleton<MapContainer>
{
    //最后一行前4位表示 上，下，右，左 相邻的房间编号
    private int[,] map0 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 19, 0, 0, 0, 2, 2, 0, 20, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map1 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 0, 0, 2, 2, 2 },
        { 2, 0, 19, 0, 0, 0, 1, 0, 0, 20, 0, 0, 1, 0, 0, 0, 0, 4 },
        { 4, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map2 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 4, 4, 4, 4, 4, 4, 4 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 0, 19, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 20, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 1, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 2, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map3 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 1, 0, 0, 4, 4, 4, 4 },
        { 2, 0, 0, 0, 0, 0, 1, 20, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 1, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 4, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map4 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 2 },
        { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 4, 4 },
        { 2, 19, 0, 0, 0, 2, 1, 1, 1, 2, 2, 0, 2, 2, 2, 0, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 0, 20, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map5 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 4, 4, 4, 4, 4, 4, 0, 1, 0, 4, 4, 0, 1, 20, 2 },
        { 4, 19, 0, 2, 2, 2, 2, 2, 2, 1, 0, 0, 2, 0, 1, 0, 0, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 4 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map6 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 1, 0, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2 },
        { 2, 19, 0, 0, 0, 0, 1, 4, 4, 4, 4, 4, 4, 1, 0, 0, 20, 2 },
        { 2, 0, 0, 0, 0, 0, 1, 0, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2 },
        { 4, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, 7, -1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map7 =
    {
        { 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 19, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 7, 1, 1, 0, 0, 20, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 3, 0, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 3, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 2, 0, 1, 1, 1, 1, 0, 0, 0, 6, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 2, 0, 20, 2, 0, 2, 0, 0, 4, 4, 4, 4, 4, 4, 4 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 6, -1, 8, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map8 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 20, 1, 2, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 3, 2, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 3, 2, 0, 0, 0, 0, 0, 0, 2 },
        { 4, 19, 0, 0, 0, 0, 2, 2, 2, 5, 4, 1, 0, 0, 0, 0, 0, 2 },
        { 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 5, 4, 4, 4, 4, 6, 2 },
        { -1, 9, -1, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map9 =
    {
        { 4, 8, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 19, 2, 2, 0, 0, 0, 4, 4, 4, 4, 8, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 0, 0, 0, 8, 2, 2, 2, 3, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 8, -1, -1, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map10 =
    {
        { 2, 2, 7, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 2, 0, 19, 2, 2, 0, 0, 0, 4, 4, 4, 4, 4, 8, 2, 2, 2, 2 },
        { 4, 0, 0, 2, 2, 0, 0, 0, 4, 4, 8, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 20, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 9, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map11 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 0, 0, 19, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 2, 7, 4, 8, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 4, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 4, 0, 0, 2, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 2 },
        { 2, 0, 4, 4, 4, 1, 1, 1, 4, 4, 4, 4, 4, 4, 4, 4, 0, 2 },
        { 2, 2, 2, 2, 2, 20, 0, 20, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 10, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map12 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 20, 2, 0, 0, 0, 0, 0, 2, 7, 4, 4, 4, 4, 0, 0, 2 },
        { 4, 0, 2, 1, 0, 0, 0, 0, 0, 2, 3, 2, 2, 2, 2, 2, 0, 2 },
        { 2, 2, 0, 1, 4, 4, 4, 0, 0, 2, 3, 2, 2, 2, 2, 2, 0, 2 },
        { 2, 2, 2, 1, 0, 0, 0, 0, 0, 2, 3, 2, 2, 2, 2, 2, 19, 4 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 2, 20, 2, 2, 2, 0, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 11, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map13 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 8, 2, 2, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, 2, 2, 2, 0, 0, 19, 4 },
        { 2, 0, 0, 0, 0, 0, 0, 3, 2, 1, 1, 0, 4, 4, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 2, 0, 0, 2, 3, 2, 2, 2, 2, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 2, 2, 5, 4, 6, 2, 2, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 20, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2 },
        { 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, 14, 12, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map14 =
    {
        { 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 19, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 3, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 3, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 4, 4, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 20, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 13, 15, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map15 =
    {
        { 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2 },
        { 2, 0, 0, 19, 0, 2, 2, 2, 2, 0, 4, 4, 4, 0, 2, 20, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0, 3, 2, 2, 2, 2 },
        { 2, 0, 0, 4, 4, 1, 0, 0, 2, 2, 2, 2, 0, 3, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 3, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2 },
        { 14, 16, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map16 =
    {
        { 2, 2, 2, 2, 7, 4, 8, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 3, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 0, 1, 2, 0, 2, 3, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2 },
        { 2, 2, 3, 2, 0, 0, 0, 0, 0, 19, 0, 0, 0, 0, 0, 0, 0, 4 },
        { 2, 2, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2 },
        { 2, 2, 20, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2 },
        { 2, 2, 0, 2, 0, 4, 4, 4, 4, 4, 1, 4, 4, 4, 0, 2, 20, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 15, -1, 17, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map17 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 0, 4, 4, 4, 4, 4, 4, 4, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2 },
        { 4, 19, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 0, 4 },
        { 2, 0, 0, 0, 0, 0, 2, 20, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 5, 4, 4, 0, 2, 0, 0, 4, 4, 0, 2, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 0, 0, 0, 20, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 18, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map18 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 20, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2 },
        { 2, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 2 },
        { 4, 19, 0, 0, 4, 4, 4, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 2 },
        { 2, 2, 0, 0, 2, 2, 2, 2, 2, 3, 0, 0, 0, 0, 0, 3, 0, 2 },
        { 2, 2, 2, 0, 0, 0, 2, 2, 20, 3, 0, 0, 0, 0, 0, 3, 0, 2 },
        { 2, 2, 2, 1, 1, 0, 2, 2, 2, 3, 0, 0, 0, 0, 0, 0, 0, 4 },
        { 2, 2, 2, 5, 4, 4, 4, 4, 4, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 19, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map19 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 4, 8, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 20, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 1, 2, 2, 2, 0, 0, 0, 2, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 0, 2, 20, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 3, 2, 2, 2, 0, 4, 4, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 3, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 4, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 20, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map20 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 3, 2, 0, 0, 0, 4, 4, 4, 0, 2, 0, 0, 20, 2 },
        { 2, 2, 2, 2, 3, 2, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 3, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2 },
        { 2, 0, 0, 2, 0, 2, 0, 0, 0, 4, 4, 4, 0, 2, 20, 2, 0, 2 },
        { 2, 0, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2 },
        { 4, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2 },
        { -1, 21, -1, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map21 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 20, 2 },
        { 2, 0, 1, 2, 1, 2, 1, 2, 1, 2, 0, 0, 4, 4, 0, 0, 2, 2 },
        { 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 2, 2, 2, 0, 2, 2 },
        { 2, 2, 2, 2, 3, 2, 3, 2, 3, 2, 0, 0, 0, 0, 0, 0, 2, 2 },
        { 2, 0, 2, 2, 3, 2, 3, 2, 3, 2, 0, 0, 0, 2, 2, 3, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 2, 0, 0, 2 },
        { 2, 19, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 20, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 20, 22, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map22 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 4, 4, 4, 4, 4, 8, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 20, 2, 0, 0, 0, 0, 0, 19, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 0, 4, 4, 4, 4, 13, 4, 4, 4, 4, 4, 0, 2, 20, 2 },
        { 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 2, 2, 2 },
        { 2, 2, 2, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 2, 2, 2 },
        { 21, -1, -1, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map23 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 4, 4, 4, 4, 4, 4, 4, 4, 8, 2, 7, 4, 4, 4, 4, 4, 4 },
        { 2, 2, 2, 2, 20, 2, 2, 2, 2, 3, 2, 3, 2, 7, 4, 8, 2, 2 },
        { 2, 2, 2, 0, 2, 2, 2, 0, 19, 0, 0, 0, 0, 0, 0, 1, 2, 2 },
        { 2, 2, 7, 0, 0, 0, 0, 0, 8, 2, 2, 0, 0, 0, 0, 0, 2, 2 },
        { 2, 2, 3, 1, 2, 3, 2, 1, 3, 2, 2, 0, 4, 4, 4, 0, 0, 2 },
        { 2, 2, 3, 1, 2, 3, 2, 1, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 3, 0, 0, 0, 0, 0, 3, 2, 2, 2, 2, 2, 2, 2, 20, 2 },
        { 2, 2, 5, 6, 2, 2, 2, 5, 6, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 22, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map24 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 4 },
        { 2, 2, 2, 2, 20, 2, 2, 0, 0, 0, 2, 2, 7, 4, 4, 8, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 1, 1, 0, 0, 0, 0, 2, 2 },
        { 2, 7, 0, 0, 0, 0, 0, 0, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 3, 1, 2, 3, 2, 2, 1, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 3, 1, 2, 3, 2, 2, 0, 6, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 3, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 5, 6, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 25, -1, 23, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map25 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 20, 0, 2, 2, 20, 2 },
        { 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 2, 2 },
        { 2, 2, 0, 4, 4, 0, 0, 0, 0, 4, 4, 0, 2, 0, 4, 0, 2, 2 },
        { 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2 },
        { 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 2 },
        { 2, 2, 1, 0, 0, 0, 0, 0, 1, 19, 2, 2, 2, 5, 4, 6, 2, 2 },
        { 2, 2, 5, 4, 4, 4, 4, 4, 6, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, 24, -1, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map26 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 7, 4, 4, 4, 4, 4, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 19, 4 },
        { 3, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 6, 0, 20, 0, 2, 2, 0, 7, 4, 4, 1, 0, 0, 0, 0, 0, 2, 2 },
        { 2, 0, 0, 0, 2, 2, 0, 0, 2, 1, 1, 0, 0, 0, 0, 1, 2, 2 },
        { 2, 2, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 20, 0, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 25, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map27 =
    {
        { 7, 4, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 3, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 20, 2 },
        { 3, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 0, 2, 2, 2 },
        { 3, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 4 },
        { 3, 2, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 2 },
        { 3, 7, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 1, 3, 2 },
        { 3, 5, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 3, 3, 2 },
        { 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 8, 2, 2, 2, 20, 3, 3, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5, 4, 4, 4, 4, 6, 3, 2 },
        { -1, 28, 26, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map28 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 4, 4, 4, 4, 4, 6, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 0, 0, 1, 8, 2, 2 },
        { 2, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 2, 3, 2, 2 },
        { 2, 0, 0, 0, 0, 1, 4, 4, 1, 0, 0, 0, 0, 0, 2, 3, 2, 2 },
        { 7, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 4, 4, 4, 0, 3, 20, 2 },
        { 3, 1, 2, 3, 20, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 3, 2, 2 },
        { 3, 0, 2, 3, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 1, 6, 2, 2 },
        { 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2 },
        { 5, 6, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 27, 29, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map29 =
    {
        { 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 19, 0, 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2 },
        { 2, 2, 0, 0, 4, 4, 0, 2, 2, 2, 0, 4, 4, 0, 2, 0, 20, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 0, 0, 0, 2, 2, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2 },
        { 28, 30, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map30 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 2, 2, 20, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 2, 1, 0, 0, 0, 7, 4, 4, 0, 0, 1, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 2, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 3, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
        { 2, 2, 2, 20, 2, 2, 2, 2, 0, 5, 4, 4, 4, 6, 2, 3, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 5, 4, 4, 4, 4, 4, 4, 6, 2, 2 },
        { 29, -1, 31, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map31 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 20, 0, 2, 2, 0, 20, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 1, 0, 2, 2, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 4, 4, 4, 0, 1, 1, 4, 4, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 1, 3, 2, 2, 0, 0, 2, 2 },
        { 4, 19, 0, 0, 0, 0, 2, 2, 2, 2, 0, 3, 2, 2, 0, 0, 0, 4 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5, 4, 4, 4, 4, 6, 2, 2 },
        { -1, -1, 32, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map32 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 19, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 4 },
        { 2, 0, 0, 0, 2, 2, 2, 0, 4, 4, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 4, 0, 0, 0, 2, 20, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2 },
        { 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 20, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, 33, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] map33 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 20, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 2, 2, 2, 2, 2 },
        { 4, 4, 19, 0, 0, 0, 4, 4, 4, 4, 0, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 5, 4, 4, 4, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 0, 1, 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 20, 0, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { -1, -1, -1, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };
    public int[,] tempMap;

    public List<int[,]> maps = new List<int[,]>();
    
    // Start is called before the first frame update
    void Awake()
    {
        tempMap = map0;
        maps.Add(map0);
        maps.Add(map1);
        maps.Add(map2);
        maps.Add(map3);
        maps.Add(map4);
        maps.Add(map5);
        maps.Add(map6);
        maps.Add(map7);
        maps.Add(map8);
        maps.Add(map9);
        maps.Add(map10);
        maps.Add(map11);
        maps.Add(map12);
        maps.Add(map13);
        maps.Add(map14);
        maps.Add(map15);
        maps.Add(map16);
        maps.Add(map17);
        maps.Add(map18);
        maps.Add(map19);
        maps.Add(map20);
        maps.Add(map21);
        maps.Add(map22);
        maps.Add(map23);
        maps.Add(map24);
        maps.Add(map25);
        maps.Add(map26);
        maps.Add(map27);
        maps.Add(map28);
        maps.Add(map29);
        maps.Add(map30);
        maps.Add(map31);
        maps.Add(map32);
        maps.Add(map33);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
