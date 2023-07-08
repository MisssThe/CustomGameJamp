using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new MapDataCreator().Generate();
        MapDataCreator.FastWayItems = new MapDataCreator.FastWayItem[10][];
        for (int index = 0; index < MapDataCreator.FastWayItems.Length; index++)
        {
            MapDataCreator.FastWayItems[index] = new MapDataCreator.FastWayItem[10];
            for (int offset = 0; offset < MapDataCreator.FastWayItems[index].Length; offset++)
            {
                MapDataCreator.FastWayItems[index][offset] = new MapDataCreator.FastWayItem()
                {
                    Item = MapDataCreator.Item.Road,
                    MinCount = 0,
                };
            }
        }
        FastWayCreator.Generate(new Vector2Int(0, 0), new Vector2Int(9, 9));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
