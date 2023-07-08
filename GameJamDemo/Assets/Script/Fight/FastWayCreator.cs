using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FastWayCreator
{

    private static Vector2Int _size;
    public static void Generate(Vector2Int begin, Vector2Int end)
    {
        //从终点往外遍历
        if (MapDataCreator.FastWayItems == null || MapDataCreator.FastWayItems.Length < 1)
        {
            return;
        }
        _size = new Vector2Int(MapDataCreator.FastWayItems.Length, MapDataCreator.FastWayItems[0].Length);
        MapDataCreator.FastWayItems[end.x][end.y].MinCount = 1;
        UpdateWay(end);
    }

    private static void UpdateWay(Vector2Int point)
    {
        if (MapDataCreator.FastWayItems[point.x][point.y].Item != MapDataCreator.Item.Road)
        {
            return;
        }
        int distance = MapDataCreator.FastWayItems[point.x][point.y].MinCount;

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

    private static void RealUpdateWay(Vector2Int point,int distance)
    {
        if (IsSafeIndex(point))
        {
            int minCount = MapDataCreator.FastWayItems[point.x][point.y].MinCount;
            if (minCount > 0 && minCount <= distance)
            {
                return;
            }
            MapDataCreator.FastWayItems[point.x][point.y].MinCount = distance;
            UpdateWay(point);
        }
    }
    private static bool IsSafeIndex(Vector2Int point)
    {
        if (point.x < _size.x && point.y < _size.y && point.x >= 0 && point.y >= 0)
        {
            return true;
        }
        return false;
    }
}
