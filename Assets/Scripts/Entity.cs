using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int posX;
    public int posY;
    public bool isInTunnel = false;
    public bool canExplode = false;

    public bool readyForExplode = false;
    public enum EntityType
    {
        Box = 1,
        Wall = 2,
        Tunnel = 3,
        Player = 4,
        Fish = 5
    }
    public enum Dir
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3
    }

    public Dir selfDir = Dir.Up;
    protected bool CanBeMoved = false;
    protected bool CanBeDestroyed = true;
    public EntityType entityType;
    public GameManager.TileType tileType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool Move(Dir dir)
    {
        isInTunnel = false;
        int aimX = posX;
        int aimY = posY;
        if (dir == Dir.Up) aimY -= 1;
        else if (dir == Dir.Down) aimY += 1;
        else if (dir == Dir.Right) aimX += 1;
        else if (dir == Dir.Left) aimX -= 1;
        Ground selfGround = GameManager.Instance.GetGround(posX, posY);
        //越界，判断能否切关
        if (aimX < 0 || aimX >= 18 || aimY < 0 || aimY >= 9)
        {
            for (int i = 0; i < selfGround.entities.Count; i++)
            {
                Entity tempEntity = selfGround.entities[i].GetComponent<Entity>();
                if (tempEntity.entityType == EntityType.Tunnel)
                {
                    Tunnel tn = selfGround.entities[i].GetComponent<Tunnel>();
                    if (this.entityType == EntityType.Player && tn.tryOut(dir))
                    {
                        //切换关卡
                        if (GameManager.Instance.SwitchNearLevel(dir))
                        {
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
            
            
        //判断move自身条件
        
        for (int i = 0; i < selfGround.entities.Count; i++)
        {
            Entity tempEntity = selfGround.entities[i].GetComponent<Entity>();
            switch (tempEntity.entityType)
            {
                case (EntityType.Tunnel):
                    Tunnel tn = selfGround.entities[i].GetComponent<Tunnel>();
                    //尝试通过的不是玩家，或者该方向不可通行
                    if (this.entityType != EntityType.Player || !tn.tryOut(dir)) return false;
                    break;
                default:
                    break;
            }
        }

        //判断move目标条件
        Ground aimGround = GameManager.Instance.GetGround(aimX, aimY);
        for (int i = 0; i < aimGround.entities.Count; i++)
        {
            Entity tempEntity = aimGround.entities[i].GetComponent<Entity>();
            switch (tempEntity.entityType)
            {
                case(EntityType.Wall):
                    return false;
                    break;
                case(EntityType.Box):
                    //先让箱子移动，无法移动则均无法移动
                    if(!tempEntity.Move(dir))return false;
                    break;
                case(EntityType.Fish):
                    if (this.entityType == EntityType.Player)
                    {
                        //角色可以吃鱼干
                        tempEntity.gameObject.SetActive(false);
                        int[,] map = MapContainer.Instance.maps[GameManager.Instance.mapID];
                        map[aimY, aimX] = 0;
                        GameManager.Instance.GetFish();
                    }
                    else
                    {
                        //暂定其他物品会阻挡住
                        return false;
                    }
                    break;
                case(EntityType.Tunnel):
                    Tunnel tn = aimGround.entities[i].GetComponent<Tunnel>();
                    //尝试通过的不是玩家，或者该方向不可通行
                    if (this.entityType != EntityType.Player || !tn.tryIn(dir)) return false;
                    else
                    {
                        //目标是隧道且可以通行时，提前改变tag
                        isInTunnel = true;
                        if(canExplode)readyForExplode = true;
                    }
                    break;
                case(EntityType.Player):
                    break;
            }
        }
        /*
        //确定要位移后，保存记录
        SaveDataInScene.Instance.SaveGround(selfGround);
        SaveDataInScene.Instance.SaveGround(aimGround);
        //玩家位移结束，则推入onemove
        if(entityType == EntityType.Player && isInTunnel == false)
            SaveDataInScene.Instance.SaveNextMove();
            */
        
        //更新自身地块
        for (int i = 0; i < selfGround.entities.Count; i++)
        {
            Entity tempEntity = selfGround.entities[i].GetComponent<Entity>();
            switch (tempEntity.entityType)
            {
                case(EntityType.Wall):
                    break;
                case(EntityType.Box):
                    selfGround.entities.RemoveAt(i);
                    break;
                case(EntityType.Fish):
                    break;
                case(EntityType.Tunnel):
                    break;
                case(EntityType.Player):
                    selfGround.entities.RemoveAt(i);
                    break;
            }
        }
        
        //更新目标地块
        aimGround.entities.Add(this.gameObject);
        
        
        //更新自身位置及朝向
        if (dir == Dir.Up)posY -= 1;
        else if (dir == Dir.Down) posY += 1;
        else if (dir == Dir.Right) posX += 1;
        else if (dir == Dir.Left) posX -= 1;
        selfDir = dir;
        //更新实际位置
        UpdatePos();
        return true;
    }


    public void UpdatePos()
    {
        transform.position = GameManager.Instance.GetWorldPosition(posX, posY);
    }

    public Entity.Dir myLeft()
    {
        switch (selfDir)
        {
            case(Dir.Up):
                return Dir.Left;
                break;
            case(Dir.Down):
                return Dir.Right;
                break;
            case(Dir.Right):
                return Dir.Up;
                break;
            case(Dir.Left):
                return Dir.Down;
                break;
            default:
                break;
        }
        Debug.Log("没找到方向，默认为左");
        return Dir.Left;
    }
    
    public Entity.Dir myRight()
    {
        switch (selfDir)
        {
            case(Dir.Up):
                return Dir.Right;
                break;
            case(Dir.Down):
                return Dir.Left;
                break;
            case(Dir.Right):
                return Dir.Down;
                break;
            case(Dir.Left):
                return Dir.Up;
                break;
            default:
                break;
        }
        Debug.Log("没找到方向，默认为右");
        return Dir.Right;
    }
    
    public Entity.Dir myBack()
    {
        switch (selfDir)
        {
            case(Dir.Up):
                return Dir.Down;
                break;
            case(Dir.Down):
                return Dir.Up;
                break;
            case(Dir.Right):
                return Dir.Left;
                break;
            case(Dir.Left):
                return Dir.Right;
                break;
            default:
                break;
        }
        Debug.Log("没找到方向，默认为右");
        return Dir.Right;
    }

    public void dirToPos(Entity.Dir dir,out int tposX, out int tposY)
    {
        tposX = posX;
        tposY = posY;
        switch (dir)
        {
            case(Dir.Up):
                tposY -= 1;
                break;
            case(Dir.Down):
                tposY += 1;
                break;
            case(Dir.Right):
                tposX += 1;
                break;
            case(Dir.Left):
                tposX -= 1;
                break;
            default:
                break;
        }

    }
}
