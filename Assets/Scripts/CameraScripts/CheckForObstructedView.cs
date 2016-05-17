using UnityEngine;
using System.Collections;

public class CheckForObstructedView : MonoBehaviour
{


    private Camera myCamera;
    public Transform Player;
    public LayerMask ignorePlayer;
    public Transform RayCam;
    public float radiusSphere = 3;

    void Start()
    {
        myCamera = Camera.main;
    }
    void Update()
    {
        TestObstruction();
    }
    void TestObstruction()
    {
        Ray ray = new Ray(Player.position, myCamera.transform.position - Player.position);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(ray,radiusSphere, RayCam.position.y, ignorePlayer);
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null) continue;
            if (hit.collider.GetComponent<MakeTransparent>() == null)
            {
                hit.collider.gameObject.AddComponent<MakeTransparent>();
            }
            else
            {
                hit.collider.GetComponent<MakeTransparent>().makeTransparent();
            }
        }
    }
   

}