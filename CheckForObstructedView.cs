using UnityEngine;
using System.Collections;

public class CheckForObstructedView : MonoBehaviour {


    private Camera myCamera;
	public Transform PlayerHead,PlayerFoot;
	public LayerMask ignorePlayer;
	public Transform RayCam;

    void Start()
    {
        myCamera = Camera.main;
    }
    void Update()
    {
        TestHeadObstruction();
		TestBodyObstruction ();
    }
	void TestHeadObstruction()
    {
		Ray ray = new Ray (PlayerHead.position, myCamera.transform.position - PlayerHead.position);
        RaycastHit[] hits;
		hits = Physics.RaycastAll(ray,RayCam.position.y,ignorePlayer);
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
	void TestBodyObstruction()
	{
		Ray ray = new Ray (PlayerFoot.position, myCamera.transform.position - PlayerFoot.position);
		RaycastHit[] hits;
		hits = Physics.RaycastAll(ray,RayCam.position.y,ignorePlayer);
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