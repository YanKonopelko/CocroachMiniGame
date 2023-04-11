using UnityEngine;

public class FloorChecker : MonoBehaviour
{
    public static bool CheckFloor(Vector3 point)
    {
        int layerMask = LayerMask.NameToLayer("Floor");

        RaycastHit hit;
        return Physics.Raycast(point, Vector3.down, out hit, 1);
    }
}
