using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject PausePainel;
	public static bool paused;

	void Start () {
		PausePainel.SetActive(false);
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			PauseGame();
		}
	}
	void PauseGame(){
		if(paused){
			PausePainel.SetActive(false);
			Time.timeScale = 0f;
			paused = false;
		}
		else{
			PausePainel.SetActive(true);
			Time.timeScale = 1f;
			paused = true;
		}
	}
}
