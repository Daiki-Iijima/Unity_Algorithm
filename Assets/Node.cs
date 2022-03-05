using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum NodeType{
    Wall,
    Rode,
    Start,
    Goal,
}

//  各マスの情報を保存するクラス
public class Node
{
    //  ゲームオブジェクト本体
    private GameObject Obj {get;}

    //  マスの座標
    public Vector2 Pos{get;}

    public NodeType Type{get;}

    //  コンストラクタ
    public Node(GameObject _obj){
        Obj = _obj;
        Pos = _obj.transform.position;

        Type = (NodeType)Enum.Parse(typeof(NodeType), Obj.name);

        //  マスの色を変化させる
        if(Type == NodeType.Rode){
            ChangeColor(Color.green);
        }

        if(Type == NodeType.Start){
            ChangeColor(Color.yellow);
        }

        if(Type == NodeType.Goal){
            ChangeColor(Color.blue);
        }
    }

    //  色を変える
    public void ChangeColor(Color setValue){
        Obj.GetComponent<MeshRenderer>().material.color = setValue;
    }

    //  隣接するノードの座標を取得
    public List<Node> GetAdjacent(List<Node> maps){
        List<Vector2> checkPosList = new List<Vector2>{
            new Vector2(Pos.x,Pos.y + 1),
            new Vector2(Pos.x,Pos.y - 1),
            new Vector2(Pos.x + 1,Pos.y),
            new Vector2(Pos.x - 1,Pos.y),
        };

        List<Node> retList = new List<Node>();

        foreach(Vector2 check in checkPosList){
            foreach(Node mapNode in maps){
                //  存在するか
                if(check == mapNode.Pos){
                    if(mapNode.Type == NodeType.Rode || mapNode.Type == NodeType.Goal){
                        retList.Add(mapNode);
                    }
                }
            }
        }

        return retList;
    }



}
