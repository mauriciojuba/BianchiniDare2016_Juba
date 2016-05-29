using UnityEngine;
using System.Collections;

public class EnemyRadar : MonoBehaviour {

    public bool onRadar;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player")) onRadar = true;
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player")) onRadar = false;
    }
}
