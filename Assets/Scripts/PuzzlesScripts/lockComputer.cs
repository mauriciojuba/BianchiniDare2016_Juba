using UnityEngine;
using System.Collections;

public class lockComputer : MonoBehaviour {
    float vel = 0.01f;
    Vector3 Unlocked;
    public Transform Locked;
    void Start()
    {
        Unlocked = transform.localPosition;
    }
	void Update()
    {
        if (DangerUI.danger)
        {
            transform.position = Vector3.MoveTowards(transform.position, Locked.position, vel);
        }
        if (!DangerUI.danger)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Unlocked, vel);
        }
    }

}
