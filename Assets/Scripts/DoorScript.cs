using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
	private bool playerWithinRange = false;
	public Image uiConfirmPrompt;
	public string sceneToLoadName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (playerWithinRange && Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Loading house");
			SceneManager.LoadScene(sceneToLoadName);
		}

    }

	void OnTriggerExit(Collider collision) {
		playerWithinRange = false;
		uiConfirmPrompt.enabled = false;
	}

    void OnTriggerEnter(Collider collision) {
		playerWithinRange = true;
		uiConfirmPrompt.enabled = true;
    }
}
