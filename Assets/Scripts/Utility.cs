using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static bool CompareDistance(Vector3 basePosition, Vector3 leftPosition, Vector3 rightPosition)
    {
        float prev = Vector3.Distance(basePosition, leftPosition);
        float next = Vector3.Distance(basePosition, rightPosition);
        return prev > next;
    }

}
