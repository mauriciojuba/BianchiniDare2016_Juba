using UnityEngine;
using System.Collections;

public class DangerUI : MonoBehaviour {

    public static DangerUI Instance;
    public static bool danger;

	void Start () {
        Instance = this;
        gameObject.SetActive(false);
	}
	
	public void onDanger()
    {
        gameObject.SetActive(true);
        danger = true;
    }
    public void NotDanger()
    {
        StartCoroutine("stopDangerSign");
    }
    IEnumerator stopDangerSign()
    {
        yield return new WaitForSeconds(4f);
        danger = false;
        gameObject.SetActive(false);
    }
}
