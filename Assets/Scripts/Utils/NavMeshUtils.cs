using UnityEngine;
using UnityEngine.AI;

public class NavMeshUtils
{
    public static bool TryGetPath(Vector3 sourcePos, Vector3 targetPos, NavMeshQueryFilter filter, NavMeshPath path)
    {
        if (NavMesh.CalculatePath(sourcePos, targetPos, filter, path) && path.status != NavMeshPathStatus.PathInvalid)
        {
            return true;
        }

        return false;
    }

    public static bool TryGetPath(Vector3 sourcePos, Vector3 targetPos, int areaIndex, NavMeshPath path)
    {
        if (NavMesh.CalculatePath(sourcePos, targetPos, areaIndex, path) && path.status != NavMeshPathStatus.PathInvalid)
        {
            return true;
        }

        return false;
    }

    public static float GetPathLength(NavMeshPath path)
    {
        float pathLength = 0;

        if (path.corners.Length > 1)
            for (int i = 1; i < path.corners.Length; i++)
                pathLength += Vector3.Distance(path.corners[i - 1], path.corners[i]);

        return pathLength;
    }
}
