using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

    public float timer;
    void Start()
    {
        Destroy(gameObject, timer);
    }
}
