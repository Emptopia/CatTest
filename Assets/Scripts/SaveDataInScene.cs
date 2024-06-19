/*
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct groundData
{
    //ground位置
    public int posX, posY;
    //public List<Entity.EntityType> entityTypes;
    public List<GameManager.TileType> tileTypes;
    public groundData(Ground g)
    {
        posX = g.posX;
        posY = g.posY;
        tileTypes = new List<GameManager.TileType>();
        for (int i = 0; i < g.entities.Count; i++)
        {
            Entity e = g.entities[i].GetComponent<Entity>();
            tileTypes.Add(e.tileType);
        }
        
        
    }
    //所属entities信息，到时候之间重新创建，记得把player赋值给controller
}
public class SaveDataInScene : MonoSingleton<SaveDataInScene>
{
    // Start is called before the first frame update
    public List<groundData> SaveDataInOneMove;
    public Stack<List<groundData>> SaveDataInOneScene;
    void Start()
    {
        SaveDataInOneScene = new Stack<List<groundData>>();
        SaveDataInOneMove = new List<groundData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGround(Ground g)
    {
        Debug.Log("保存地面");
        groundData gd = new groundData(g);
        SaveDataInOneMove.Add(gd);
    }

    public void SaveGround(int posX, int posY)
    {
        Ground g = GameManager.Instance.GetGround(posX, posY);
        groundData gd = new groundData(g);
        SaveDataInOneMove.Add(gd);
    }
    
    public void SaveNextMove()
    {
        Debug.Log("保存一步");
        //这里push的不是指针吧
        List<groundData> list = new List<groundData>(SaveDataInOneMove.ToArray());
        
        SaveDataInOneScene.Push(list);
        SaveDataInOneMove.Clear();
    }
   
    
}
*/
