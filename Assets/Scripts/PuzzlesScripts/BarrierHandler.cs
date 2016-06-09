using UnityEngine;
using System.Collections;

public class BarrierHandler : MonoBehaviour {

    public Material Green;
    public bool doorCollider;
    Renderer rend;
    bool openned;

	void Start () {
        rend = GetComponent<Renderer>();
        doorCollider = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!doorCollider && !openned)
        {
            Invoke("OpenDoor", 1f);
        }
	}
    public void OpenDoor()
    {
        rend.sharedMaterial = Green;
        this.GetComponent<BoxCollider>().enabled = false;
        openned = true;
    }
}
