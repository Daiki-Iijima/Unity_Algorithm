using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject mapPrefab;

    private List<List<int>> map = new List<List<int>>{
        new List<int>{0,0,0,0,0,0,0,0,0,0},
        new List<int>{0,1,0,0,0,0,0,1,1,0},
        new List<int>{0,1,1,1,3,0,0,1,0,0},
        new List<int>{0,1,0,0,0,0,0,1,0,0},
        new List<int>{0,1,0,1,1,0,0,1,0,0},
        new List<int>{0,1,0,1,0,0,0,1,0,0},
        new List<int>{0,1,1,1,1,1,1,1,2,0},
        new List<int>{0,1,0,0,0,1,0,0,0,0},
        new List<int>{0,1,1,1,1,1,1,1,1,0},
        new List<int>{0,0,0,0,0,0,0,0,0,0},
    };

    private BFS bfs;

    void Start()
    {
        List<GameObject> objs = new List<GameObject>();

        int y = 0;
        int x = 0;
        foreach(List<int> m in map){
            foreach(int no in m){
                GameObject obj = Instantiate(mapPrefab,new Vector2(x,-y),Quaternion.identity);
                NodeType type = (NodeType)Enum.ToObject(typeof(NodeType), no);
                obj.name = type.ToString();
                objs.Add(obj);
                x++;
            }
            y++;
            x = 0;
        }

        bfs = new BFS(objs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
