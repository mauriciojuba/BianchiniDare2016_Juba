using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

    public Material Green;
    public BarrierHandler barreira;
    bool canSwitch, openned;
    Renderer rend;

    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (canSwitch && !openned) openDoor();
        Debug.Log(canSwitch);
	}
    void openDoor()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            rend.sharedMaterial = Green;
            barreira.doorCollider = false;
            openned = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            canSwitch = true;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            canSwitch = false;
        }
    }
}
