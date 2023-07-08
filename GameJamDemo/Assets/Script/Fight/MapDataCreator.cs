using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataCreator
{
    public enum Item
    {
        Start,
        End,
        Road,
        Barrier,
    }
    public class FastWayItem
    {
        public int MinCount;    //离终点最短距离
        public MapDataCreator.Item Item;
    }
    //地图数据存储（全局唯一）
    public static FastWayItem[][] FastWayItems;
    //离终点最远距离
    public static int MaxDistance = -1;
    
    // Start is called before the first frame update
    public FastWayItem[][] Generate()
    {
        return null;
    }
}
