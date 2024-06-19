using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoSingleton<GameManager>
{
    private int[,] existMap;
    public GameObject playerPrefab;
    public GameObject groundPrefab;
    public GameObject boxPrefab;
    public GameObject wallPrefab;
    public GameObject tunnelPrefab;
    public GameObject fishPrefab;
    public List<Ground>grounds = new List<Ground>();
    public int mapID;
    public int nextSpawnPosX = 0;
    public int nextSpawnPosY = 0;
    public Entity.Dir nextSpawnDir = Entity.Dir.Up;
    public bool isStartLevel = true;
    public Text fishText;
    public Text stageText;
    public int fishNum = 0;
    public int allFishNum = 54;

    public bool isSwitching = false;
    //public Stack<SaveDataInScene> saveStack;
    
    public enum TileType
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
        InitMapID(10);
        fishText.text = "Fish:" + fishNum + "/" + allFishNum;

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

    public bool InitMapID(int id)
    {
        if (id < 0 || id >= MapContainer.Instance.maps.Count)
        {
            Debug.Log("没找到地图");
            return false;
        }

        existMap = MapContainer.Instance.maps[id];
        this.mapID = id;
        InitMap(existMap);
        if (isStartLevel == false)
        {
            //生成玩家位置
            CreateGoInMap(TileType.Player, nextSpawnPosX, nextSpawnPosY);
            //PlayerController.Instance.isSwitchLevel = true;
        }
        isStartLevel = false;
        ShowStageText();
        return true;
    }
    
    public void InitMap(int[,] map)
    {
        ClearMap();
        for(int i = 0; i < 9; ++i)
        {
            for(int j = 0; j < 18; ++j)
            {
                TileType type = (TileType)map[i, j];
                //不重复出生
                if(type == TileType.Player && isStartLevel == false)continue;    
                CreateGoInMap(type, j, i);
                
            }
        }
    }

    public void ClearMap()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            for (int j = 0; j < grounds[i].entities.Count; j++)
            {
                Destroy(grounds[i].entities[j]);
            }
            grounds[i].entities.Clear();
        }
    }
    public bool SwitchNearLevel(Entity.Dir dir)
    {
        int id = 0;
        switch (dir)
        {
            case(Entity.Dir.Up):
                id = existMap[9, 0];
                nextSpawnPosX = PlayerController.Instance.player.posX;
                nextSpawnPosY = 8;
                nextSpawnDir = Entity.Dir.Up;
                break;
            case(Entity.Dir.Down):
                id = existMap[9, 1];
                nextSpawnPosX = PlayerController.Instance.player.posX;
                nextSpawnPosY = 0;
                nextSpawnDir = Entity.Dir.Down;
                break;
            case(Entity.Dir.Right):
                id = existMap[9, 2];
                nextSpawnPosX = 0;
                nextSpawnPosY = PlayerController.Instance.player.posY;
                nextSpawnDir = Entity.Dir.Right;
                break;
            case(Entity.Dir.Left):
                id = existMap[9, 3];
                nextSpawnPosX = 17;
                nextSpawnPosY = PlayerController.Instance.player.posY;
                nextSpawnDir = Entity.Dir.Left;
                break;
            
        }
        Debug.Log(nextSpawnPosX + nextSpawnPosY);
        bool res = InitMapID(id);
        if (res)
        {
            PlayerController.Instance.isSwitchLevel = true;
            PlayerController.Instance.isMove = false;
        }
        return res;
    }

    public void Restart()
    {
        InitMapID(mapID);
    }
    
    public void CreateGoInMap(TileType type, int posX, int posY)
    {
        int i = posY;
        int j = posX;
        GameObject go = null;
        /*Debug.Log("map = " + map[i,j]);*/
        switch (type)
                {
                    case TileType.GROUND:
                        
                        break;
                    case TileType.BOX:
                        go = CreateGameObject(boxPrefab, i, j);
                        go.name = "Box" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.WALL:
                        go = CreateGameObject(wallPrefab, i, j);
                        go.name = "Wall" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_01:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t01 = go.GetComponent<Tunnel>();
                        t01.InitPassDir(true,true,false,false);
                        go.name = "Tunnel01" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_23:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t23 = go.GetComponent<Tunnel>();
                        t23.InitPassDir(false,false,true,true);
                        go.name = "Tunnel23" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_02:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t02 = go.GetComponent<Tunnel>();
                        t02.InitPassDir(true,false,true,false);
                        go.name = "Tunnel02" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_03:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t03 = go.GetComponent<Tunnel>();
                        t03.InitPassDir(true,false,false,true);
                        go.name = "Tunnel03" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_12:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t12 = go.GetComponent<Tunnel>();
                        t12.InitPassDir(false,true,true,false);
                        go.name = "Tunnel12" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_13:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t13 = go.GetComponent<Tunnel>();
                        t13.InitPassDir(false,true,false,true);
                        go.name = "Tunnel13" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_123:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t123 = go.GetComponent<Tunnel>();
                        t123.InitPassDir(false,true,true,true);
                        go.name = "Tunnel123" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_023:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t023 = go.GetComponent<Tunnel>();
                        t023.InitPassDir(true,false,true,true);
                        go.name = "Tunnel023" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_013:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t013 = go.GetComponent<Tunnel>();
                        t013.InitPassDir(true,true,true,false);
                        go.name = "Tunnel013" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_012:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t012 = go.GetComponent<Tunnel>();
                        t012.InitPassDir(true,true,false,true);
                        go.name = "Tunnel012" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.TUNNEL_0123:
                        go = CreateGameObject(tunnelPrefab, i, j);
                        Tunnel t0123 = go.GetComponent<Tunnel>();
                        t0123.InitPassDir(true,true,true,true);
                        go.name = "Tunnel0123" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                    case TileType.Player:
                        go = CreateGameObject(playerPrefab, i, j);
                        go.name = "Player" + i + "_" + j;
                        Player player = go.GetComponent<Player>();
                        AddToGround(go, i, j, type);
                        PlayerController.Instance.player = player;
                        if (isStartLevel)
                        {
                            nextSpawnPosX = player.posX;
                            nextSpawnPosY = player.posY;
                            nextSpawnDir = Entity.Dir.Up;
                        }
                        break;
                    case TileType.FISH:
                        go = CreateGameObject(fishPrefab, i, j);
                        go.name = "Fish" + i + "_" + j;
                        AddToGround(go, i, j, type);
                        break;
                }
    }

    public void GetFish()
    {
        fishNum++;
        fishText.text = "Fish:" + fishNum + "/" + allFishNum;
    }

    public void ShowStageText()
    {
        stageText.text = "Stage " + mapID;
    }
    GameObject CreateGameObject(GameObject go, int row, int col)
    {
        //注意，pos和实际position的y相反
        return Instantiate(go, new Vector3(col, -row), Quaternion.identity);
    }

    void AddToGround(GameObject go, int posy, int posx, TileType tileType)
    {
        Entity en = go.GetComponent<Entity>();
        en.tileType = tileType;
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

    /*
    public void ReadLastMove()
    {
        SaveDataInScene savedata = SaveDataInScene.Instance;
            //弹出最近的移动
            if (savedata.SaveDataInOneScene.Count == 0)
            {
                Debug.Log("已经没有上一步");
                return;
            }
            List<groundData> list = savedata.SaveDataInOneScene.Pop();
            for (int i = 0; i < list.Count; i++)
            {
                ReadGround(list[i]);
            }
            list.Clear();
        
            Debug.Log("回退结束");
        
    }
    
    public void ReadGround(groundData gd)
    {
        Debug.Log("读取改变地面");
        Ground g = GetGround(gd.posX, gd.posY);
        for (int i = 0; i < g.entities.Count;i++)
        {
            Debug.Log("摧毁");
            Destroy(g.entities[i]);
        }
        g.entities.Clear();
        for (int i = 0; i < gd.tileTypes.Count; i++)
        {
            Debug.Log("创建");
            CreateGoInMap(gd.tileTypes[i], gd.posX, gd.posY);
        }
    }
    */
    
}
