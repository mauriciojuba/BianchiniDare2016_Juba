using UnityEngine;
using System.Collections;

public class CheckForObstructedView : MonoBehaviour {


    private Camera myCamera;
    private GameObject Player;
    public LayerMask buildings;

    void Start()
    {
        Player = GameObject.Find("Lyla");
        myCamera = Camera.main;
    }
    void Update()
    {
        TestUpperFloor();
    }
    void TestUpperFloor()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(new Ray(myCamera.transform.position, myCamera.transform.forward),myCamera.transform.position.y - Player.transform.position.y,buildings);

        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null) continue;
            MakeTransparent MT = R.GetComponent<MakeTransparent>();
            if (MT == null)
            {
                MT = R.gameObject.AddComponent<MakeTransparent>();
            }
            else
            {
                MT.makeTransparent();
                continue;
            }
        }
    }
}