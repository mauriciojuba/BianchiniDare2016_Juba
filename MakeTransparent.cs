using UnityEngine;
using System.Collections;

public class MakeTransparent : MonoBehaviour {

	Material Standard, Transparent_Buildings, Transparent_Enemys;
	float count = 10;
	Color transColor;
	Renderer render;

	void Start () {
		render = GetComponent<Renderer> ();
		Transparent_Buildings = Resources.Load ("Materials/BuildingsTransparent") as Material;
		Transparent_Enemys = Resources.Load ("Materials/EnemysTransparent") as Material;
		Standard = render.sharedMaterial;
		count = 10;
		if(this.CompareTag("Building"))render.sharedMaterial = Transparent_Buildings;
		else if(this.CompareTag("Enemy"))render.sharedMaterial = Transparent_Enemys;

	}
	void Update () {
		transColor.a = Mathf.Abs(count)/10;
		Transparent_Enemys.color = transColor;
		Transparent_Buildings.color = transColor;
	}
	void LateUpdate(){
		count += Time.deltaTime;
		if (transColor.a >= 1) {
			Destroy (this);
		}
	}
	public void makeTransparent(){
		count = 9;
	}
	void OnDestroy(){
		render.sharedMaterial = Standard;
	}
}
