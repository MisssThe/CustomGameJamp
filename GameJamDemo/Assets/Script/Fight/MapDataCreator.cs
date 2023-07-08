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
    public static FastWayItem[][] FastWayItems;
    // Start is called before the first frame update
    public FastWayItem[][] Generate()
    {
        return null;
    }
}
