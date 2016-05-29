using UnityEngine;
using System.Collections;

public class DangerUI : MonoBehaviour {

    public static DangerUI Instance;
	void Start () {
        Instance = this;
        gameObject.SetActive(false);
	}
	
	public void onDanger()
    {
        gameObject.SetActive(true);
    }
    public void NotDanger()
    {
        gameObject.SetActive(false);
    }
}
