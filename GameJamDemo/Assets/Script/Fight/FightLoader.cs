using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLoader : MonoBehaviour
{
    private MapDataCreator.FastWayItem[][] _fastWayItems;

    // Start is called before the first frame update
    void Start()
    {
        this._fastWayItems = new MapDataCreator().Generate();
        this._fastWayItems = new MapDataCreator.FastWayItem[10][];
        for (int index = 0; index < this._fastWayItems.Length; index++)
        {
            this._fastWayItems[index] = new MapDataCreator.FastWayItem[10];
            for (int offset = 0; offset < this._fastWayItems[index].Length; offset++)
            {
                this._fastWayItems[index][offset] = new MapDataCreator.FastWayItem()
                {
                    Item = MapDataCreator.Item.Road,
                    MinCount = 0,
                };
            }
        }
        new FastWayCreator().Generate(new Vector2Int(0, 0), new Vector2Int(9, 9), this._fastWayItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
