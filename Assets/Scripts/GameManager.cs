using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int[,] map;
    public GameObject playerPrefab;
    public GameObject groundPrefab;
    public GameObject boxPrefab;
    public GameObject wallPrefab;
    public GameObject tunnelPrefab;
    public GameObject fishPrefab;
    
    public List<Ground>grounds = new List<Ground>();    
    private enum TileType
    {
        GROUND = 0, 
        BOX = 1, 
        WALL = 2, 
        TUNNEL_01 = 3, 
        TUNNEL_23 = 4,
        TUNNEL_02 = 5,
        TUNNEL_03 = 6,
        TUNNEL_12 = 7,
        TUNNEL_13 = 8,
        TUNNEL_123 = 9,
        TUNNEL_023 = 10,
        TUNNEL_013 = 11,
        TUNNEL_012 = 12,
        TUNNEL_0123 = 13,
        Player = 19,
        FISH = 20
    }
    // Start is called before the first frame update
    void Start()
    {
        InitGround();
        InitMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitGround()
    {
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 18; ++j)
            {
                GameObject go;
                go = CreateGameObject(groundPrefab, i, j);
                go.name = "Ground" + i + "_" + j;
                Ground gr = go.GetComponent<Ground>();
                grounds.Add(gr);
                gr.posY = i;
                gr.posX = j;
            }
            
        }
    }
    
    
    void InitMap()
    {
        map = MapContainer.map1;
        for(int i = 0; i < 9; ++i)
        {
            for(int j = 0; j < 18; ++j)
            {
                GameObject go = null;
                Debug.Log("map = " + map[i,j]);
                switch (map[i,j])
                {
                    case (int)TileType.GROUND:
                        
                        break;
                    case (int)TileType.BOX:
                        go = CreateGameObject(boxPrefab, i, j);
                        go.name = "Box" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.WALL:
                        go = CreateGameObject(wallPrefab, i, j);
                        go.name = "Wall" + i + "_" + j;
                        
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_01:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t01 = go.GetComponent<Tunnel>();
                        t01.InitPassDir(true,true,false,false);
                        go.name = "Tunnel01" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_23:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t23 = go.GetComponent<Tunnel>();
                        t23.InitPassDir(false,false,true,true);
                        go.name = "Tunnel23" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_02:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t02 = go.GetComponent<Tunnel>();
                        t02.InitPassDir(true,false,true,false);
                        go.name = "Tunnel02" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_03:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t03 = go.GetComponent<Tunnel>();
                        t03.InitPassDir(true,false,false,true);
                        go.name = "Tunnel03" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_12:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t12 = go.GetComponent<Tunnel>();
                        t12.InitPassDir(false,true,true,false);
                        go.name = "Tunnel12" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_13:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t13 = go.GetComponent<Tunnel>();
                        t13.InitPassDir(false,true,false,true);
                        go.name = "Tunnel13" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_123:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t123 = go.GetComponent<Tunnel>();
                        t123.InitPassDir(false,true,true,true);
                        go.name = "Tunnel123" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_023:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t023 = go.GetComponent<Tunnel>();
                        t023.InitPassDir(true,false,true,true);
                        go.name = "Tunnel023" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_013:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t013 = go.GetComponent<Tunnel>();
                        t013.InitPassDir(true,true,true,false);
                        go.name = "Tunnel013" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_012:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t012 = go.GetComponent<Tunnel>();
                        t012.InitPassDir(true,true,false,true);
                        go.name = "Tunnel012" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case (int)TileType.TUNNEL_0123:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t0123 = go.GetComponent<Tunnel>();
                        t0123.InitPassDir(true,true,true,true);
                        go.name = "Tunnel0123" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                    case(int)TileType.Player:
                        go = CreateGameObject(playerPrefab, i, j);
                        go.name = "Player" + i + "_" + j;
                        Player player = go.GetComponent<Player>();
                        AddToGround(go,i,j);
                        PlayerController.Instance.player = player;
                        break;
                    case (int)TileType.FISH:
                        go = CreateGameObject(fishPrefab, i, j);
                        go.name = "Fish" + i + "_" + j;
                        AddToGround(go,i,j);
                        break;
                }
            }
        }
    }
    
    GameObject CreateGameObject(GameObject go, int row, int col)
    {
        //注意，pos和实际position的y相反
        return Instantiate(go, new Vector3(col, -row), Quaternion.identity);
    }

    void AddToGround(GameObject go, int posy, int posx)
    {
        Entity en = go.GetComponent<Entity>();
        en.posY = posy;
        en.posX = posx;
        Ground g = GetGround(posx, posy);
        g.entities.Add(go);
    }

    public Ground GetGround(int posX, int posY)
    {
        if (posX < 0 || posX >= 18 || posY < 0 || posY >= 9)
        {
            Debug.Log("该位置posX:" + posX + "posY:" + posY + "越界");
            return null;
        }
        return grounds[posY * 18 + posX];
    }

    public Vector3 GetWorldPosition(int posX, int posY)
    {
        if (posX < 0 || posX >= 18 || posY < 0 || posY >= 9)
        {
            Debug.Log("该位置posX:" + posX + "posY:" + posY + "越界");
            return Vector3.zero;
        }
        Vector3 pos = new Vector3(posX, -posY);
        return pos;
    }
}
