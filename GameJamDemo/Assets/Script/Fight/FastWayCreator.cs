using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FastWayCreator
{

    private Vector2Int _size;
    private MapDataCreator.FastWayItem[][] _fastWayItems;
    public void Generate(Vector2Int begin, Vector2Int end, MapDataCreator.FastWayItem[][] fastWayItems)
    {
        //从终点往外遍历
        if (fastWayItems == null || fastWayItems.Length < 1)
        {
            return;
        }
        this._fastWayItems = fastWayItems;
        this._size = new Vector2Int(this._fastWayItems.Length, this._fastWayItems[0].Length);
        this._fastWayItems[end.x][end.y].MinCount = 1;
        this.UpdateWay(end);
        this._fastWayItems = null;
    }

    private void UpdateWay(Vector2Int point)
    {
        if (this._fastWayItems[point.x][point.y].Item != MapDataCreator.Item.Road)
        {
            return;
        }
        int distance = this._fastWayItems[point.x][point.y].MinCount;

        distance++;
        //判断周围路径是否可达
        Vector2Int up = point + new Vector2Int(0, 1);
        Vector2Int bottom = point + new Vector2Int(0, -1);
        Vector2Int left = point + new Vector2Int(-1, 0);
        Vector2Int right = point + new Vector2Int(1, 0);
        RealUpdateWay(up, distance);
        RealUpdateWay(bottom, distance);
        RealUpdateWay(left, distance);
        RealUpdateWay(right, distance);
    }

    private void RealUpdateWay(Vector2Int point,int distance)
    {
        if (IsSafeIndex(point))
        {
            int minCount = this._fastWayItems[point.x][point.y].MinCount;
            if (minCount > 0 && minCount <= distance)
            {
                return;
            }
            this._fastWayItems[point.x][point.y].MinCount = distance;
            UpdateWay(point);
        }
    }
    private bool IsSafeIndex(Vector2Int point)
    {
        if (point.x < _size.x && point.y < _size.y && point.x >= 0 && point.y >= 0)
        {
            return true;
        }
        return false;
    }
}
