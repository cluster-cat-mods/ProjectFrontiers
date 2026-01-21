using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class MovingPlatform : MonoBehaviour
{
    private enum moveTypes
    {
        Cycle,
        PingPong
    }
    [SerializeField] private moveTypes moveType;
    [SerializeField] private List<MovePoint> movePoints;
    [SerializeField] private float sensitivity;

    private int listPos = 0;
    private bool cycleDirectionBool = true;

    private void MoveToPoint(MovePoint movePointP)
    {
        Vector3 offset = movePointP.point.transform.position - transform.position;
        transform.Translate(offset * movePointP.speed * Time.deltaTime);
    }

    private void ListCycle()
    {
        if (moveType == moveTypes.PingPong)
        {
            if (listPos >= movePoints.Count - 1 || listPos <= 0)
            {
                cycleDirectionBool = !cycleDirectionBool;
            }
            if (cycleDirectionBool)
            {
                listPos++;
            }
            else
            {
                listPos--;
            }
        }
        if (moveType == moveTypes.Cycle)
        {
            if (listPos >= movePoints.Count - 1)
            {
                listPos = 0;
            }
            else
            {
                listPos++;
            }
        }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, movePoints[listPos].point.transform.position) <= sensitivity)
        {
            ListCycle();
        }
        MoveToPoint(movePoints[listPos]);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawCube(transform.position, transform.localScale * 0.8f);
    }

}

[Serializable]
public class MovePoint
{
    public GameObject point;
    public float speed;

}
