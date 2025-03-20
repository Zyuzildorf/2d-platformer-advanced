using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointsArray;
    
    public Transform[] WaypointsArray => _waypointsArray.ToArray();
    
    [ContextMenu("GetWaypoints")]
    private void GetWaypoints()
    {
        _waypointsArray = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _waypointsArray[i] = transform.GetChild(i);
        }
    }
}