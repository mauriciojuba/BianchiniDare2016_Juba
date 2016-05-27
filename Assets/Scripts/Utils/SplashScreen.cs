using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class SplashScreen : MonoBehaviour {

	float cont =0f;


	void Update(){
		cont+=Time.deltaTime;
		if(cont >=5f){
			EditorSceneManager.LoadScene("test");
		}
	}
}
