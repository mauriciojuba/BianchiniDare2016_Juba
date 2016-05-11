using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public Color laserColor = Color.green;
	public int laserDistance = 50;
	public float initialWidth = 0.02f, finalWidth = 0.1f;
	private GameObject collisionLight;
	private Vector3 lightPosition;
	public LayerMask ignoreBullet;


	// Use this for initialization
	void Start () {
		collisionLight = new GameObject ();
		collisionLight.AddComponent<Light> ();
		collisionLight.GetComponent<Light> ().intensity = 8;
		collisionLight.GetComponent<Light> ().bounceIntensity = 8;
		collisionLight.GetComponent<Light> ().range = finalWidth * 2;
		collisionLight.GetComponent<Light> ().color = laserColor;
		lightPosition = new Vector3 (0, 0, finalWidth);
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer> ();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors (laserColor, laserColor);
		lineRenderer.SetWidth (initialWidth, finalWidth);
		lineRenderer.SetVertexCount (2);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 finalPoint = transform.position + transform.forward * laserDistance;
		RaycastHit collisionPoint;
		if (Physics.Raycast (transform.position, transform.forward, out collisionPoint,laserDistance, ignoreBullet)) {
			GetComponent<LineRenderer> ().SetPosition (0, transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, collisionPoint.point);
			collisionLight.transform.position = (collisionPoint.point - lightPosition);
		} else {
			GetComponent<LineRenderer> ().SetPosition (0, transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, finalPoint);
			collisionLight.transform.position = finalPoint;
		
		}
	}
}
