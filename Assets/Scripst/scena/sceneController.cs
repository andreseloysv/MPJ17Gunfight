using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {
	List<string> scenes = new List<string>();
	string currentScene = "";
	int currentSceneIndex;
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
		loadScenes();
		currentSceneIndex = 0;
		currentScene = scenes[currentSceneIndex];
    }

	void Update()
	{
		if(currentSceneIndex == 0){
			if (Input.GetButtonDown("Submit")){
				currentSceneIndex++;
				SceneManager.LoadScene (scenes[currentSceneIndex], LoadSceneMode.Single);
			}
		}
		
	}
	void loadScenes(){
		scenes.Add("welcome");
		scenes.Add("level1");	
	}
}