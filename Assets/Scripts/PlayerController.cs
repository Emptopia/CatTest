using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoSingleton<PlayerController>
{
    public bool isMove = false;
    public float moveTime = 0.2f;
    public float normalTime = 0.2f;
    public float dashTime = 0.05f;
    public float timeSet = 0f;
    public bool isSwitchLevel = false;
    
    
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        
        if (isMove)
        {
            timeSet += Time.deltaTime;
            if (timeSet >= moveTime)
            {
                isMove = false;
                timeSet = 0;
            }
        }

        if (isSwitchLevel)
        {
            timeSet += Time.deltaTime;
            if (timeSet >= moveTime)
            {
                isSwitchLevel = false;
                timeSet = 0;
                player.isInTunnel = true;
                player.selfDir = GameManager.Instance.nextSpawnDir;
            }
        }
        


        if (isMove == false)
        {
            if (player.isInTunnel)
            {
                moveTime = dashTime;
                isMove = true;
                Entity.Dir d = player.selfDir;
                
                //自动移动
                if (!player.Move(player.selfDir))
                {
                    if (!player.Move(player.myLeft()))
                    {
                        if (!player.Move(player.myRight()))
                        {
                            Debug.Log("回头了");
                            //返回原点，待补充
                            player.selfDir = player.myBack();
                            player.Move(player.selfDir);
                        }
                    }
                }
                
            }
            else
            {
                moveTime = normalTime;
                //逃离隧道可以判断引爆
                if (player.readyForExplode == true)
                { 
                    int tposX;
                    int tposY;
                    Entity.Dir d = player.selfDir;
                    //遍历，存在1个无实体则不引爆
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g1 = GameManager.Instance.GetGround(tposX, tposY);
                    d = player.myLeft();
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g2 = GameManager.Instance.GetGround(tposX, tposY);
                    d = player.myRight();
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g3 = GameManager.Instance.GetGround(tposX, tposY);
                    if (g1.entities.Count == 0 || g2.entities.Count == 0 || g3.entities.Count == 0)
                    {
                        //不引爆
                        player.readyForExplode = false;
                        
                    }//尝试推动3个方向
                    else if (!player.Move(player.selfDir))
                    {
                        if (!player.Move(player.myLeft()))
                        {
                            if (!player.Move(player.myRight()))
                            {
                                //都无法推动则引爆
                                Explode(g1, g2, g3);
                            }
                        }
                    }
                }
                else
                {
                    //根据输入尝试移动
                    tryMove();
                }
                
            }
        }
        

        
    }


    void Explode(Ground g1, Ground g2, Ground g3)
    {
        Ground g4, g5;
        //上下时，g1取Y, g2g3取X
        if (player.selfDir == Entity.Dir.Up || player.selfDir == Entity.Dir.Down)
        {
            g4 = GameManager.Instance.GetGround(g2.posX, g1.posY);
            g5 = GameManager.Instance.GetGround(g3.posX, g1.posY);
        }
        else
        {
            g4 = GameManager.Instance.GetGround(g1.posX, g2.posY);
            g5 = GameManager.Instance.GetGround(g1.posX, g3.posY);
        }
        ExplodeSingleGround(g1);
        ExplodeSingleGround(g2);
        ExplodeSingleGround(g3);
        ExplodeSingleGround(g4);
        ExplodeSingleGround(g5);
        
    }

    void ExplodeSingleGround(Ground g)
    {
        for (int i = 0; i < g.entities.Count; i++)
        {
            g.entities[i].SetActive(false);
            //Destroy(g.entities[i]);
        }
        g.entities.Clear();
    }
    
    void tryMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Right);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Left);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Down);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Up);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            GameManager.Instance.Restart();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            /*GameManager.Instance.ReadLastMove();*/
            
        }
    }

}

