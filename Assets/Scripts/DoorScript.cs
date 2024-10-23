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
	public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (playerWithinRange && Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene(sceneToLoadName);
			if (player && SceneManager.GetActiveScene().name == "MeadowScene") {
				StateScript.playerMeadowPos = player.position;
			}
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
