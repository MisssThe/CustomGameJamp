using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FastWayCreator
{

    public static void Generate(Vector2Int begin, Vector2Int end)
    {
        //从终点往外遍历
        if (MapDataCreator.FastWayItems == null || MapDataCreator.FastWayItems.Length < 1)
        {
            return;
        }
        MapDataCreator.FastWayItems[end.x][end.y].MinCount = 1;
        UpdateWay(end);
        //记录最远距离
        foreach (var fastWayItems in MapDataCreator.FastWayItems)
        {
            foreach (var fastWayItem in fastWayItems)
            {
                if (MapDataCreator.MaxDistance < fastWayItem.MinCount)
                {
                    MapDataCreator.MaxDistance = fastWayItem.MinCount;
                }
            }
        }
    }

    private static void UpdateWay(Vector2Int point)
    {
        //避免over stack
        // List<Vector2Int> targets = new List<Vector2Int> { point };
        Queue<Vector2Int> targets = new Queue<Vector2Int>();
        targets.Enqueue(point);
        while (targets.Count > 0)
        {
            int size = targets.Count;
            for (int index = 0; index < size; index++)
            {
                var tempPoint = targets.Dequeue();
                if (MapDataCreator.FastWayItems[tempPoint.x][tempPoint.y].Item != MapDataCreator.Item.Road)
                {
                    return;
                }

                int distance = MapDataCreator.FastWayItems[tempPoint.x][tempPoint.y].MinCount;

                distance++;
                //判断周围路径是否可达
                Vector2Int up = tempPoint + new Vector2Int(0, 1);
                Vector2Int bottom = tempPoint + new Vector2Int(0, -1);
                Vector2Int left = tempPoint + new Vector2Int(-1, 0);
                Vector2Int right = tempPoint + new Vector2Int(1, 0);
                RealUpdateWay(up, distance, targets);
                RealUpdateWay(bottom, distance, targets);
                RealUpdateWay(left, distance, targets);
                RealUpdateWay(right, distance, targets);
            }
        }

        var temp = MapDataCreator.FastWayItems;
    }

    private static void RealUpdateWay(Vector2Int point,int distance,Queue<Vector2Int> targets)
    {
        if (!IsSafeIndex(point))
        {
            return;
        }
        int minCount = MapDataCreator.FastWayItems[point.x][point.y].MinCount;
        if (minCount > 0 && minCount <= distance)
        {
            return;
        }
            
        MapDataCreator.FastWayItems[point.x][point.y].MinCount = distance;
        targets.Enqueue(point);
    }
    private static bool IsSafeIndex(Vector2Int point)
    {
        if (point.x < MapDataCreator.FastWayItems.Length && point.y < MapDataCreator.FastWayItems[0].Length && point.x >= 0 && point.y >= 0)
        {
            return true;
        }
        return false;
    }
}
