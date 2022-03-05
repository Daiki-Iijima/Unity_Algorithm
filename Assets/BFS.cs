using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS
{
    //  迷路情報から生成したNode群
    public List<Node> NodeList = new List<Node>();

    private Dictionary<Node,Node> outMap = new Dictionary<Node,Node>();

    public BFS(List<GameObject> obj){
        foreach(var o in obj){
            NodeList.Add(new Node(o));
        }

        Queue<Node> q = new Queue<Node>();

        //  Startノードを探す
        foreach(Node n in NodeList){
            if(n.Type == NodeType.Start){
                q.Enqueue(n);
            }
        }

        while(q.Count > 0){
            Node n = q.Dequeue();

            List<Node> adjaccents = n.GetAdjacent(NodeList);

            if(n.Type == NodeType.Goal){
                Debug.Log("ルート見つかり");
                break;
            }

            foreach(Node pos in adjaccents){
                Node parent = null;
                try{
                    parent = outMap[pos];
                }catch{
                }
                if(parent == null){
                    outMap[pos] = n;
                    q.Enqueue(pos);
                }
            }
        }

        Node tmp = null;
        //  Startノードを探す
        foreach(Node n in NodeList){
            if(n.Type == NodeType.Goal){
                tmp = n;
            }
        }

        while(true){
            try{
                tmp = outMap[tmp];
                tmp.ChangeColor(Color.red);
            }catch{
                break;
            }
        }

    }
}
