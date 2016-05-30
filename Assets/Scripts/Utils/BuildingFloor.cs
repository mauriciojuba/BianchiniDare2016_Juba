using UnityEngine;
using System.Collections;

public class BuildingFloor : MonoBehaviour {

    public int floor;
	void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            BuildingsHandler.Instance.changeFloor(floor);
        }
    }
}
