using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveScript : MonoBehaviour
{
	private bool playerWithinRange = false;
	public Image uiConfirmPrompt;
	public Transform player;
	public GameObject flowerBundle;
	public GameObject flowerMarkers;

	void Start() {
		flowerBundle.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (playerWithinRange && Input.GetKeyDown(KeyCode.Space)) {
			PlayerTrigger();
		}

    }

	bool CanPlaceFlowers() {
		return StateScript.stateMap["tulip"] && StateScript.stateMap["rose"] && StateScript.stateMap["poppy"];
	}

    void PlayerTrigger() {
		StateScript.stateMap["tulip"] = false;
		StateScript.stateMap["poppy"] = false;
		StateScript.stateMap["rose"] = false;
		flowerBundle.SetActive(true);
		flowerMarkers.SetActive(false);
		uiConfirmPrompt.enabled = false;
    }

	void OnTriggerExit(Collider collision) {
		playerWithinRange = false;
		uiConfirmPrompt.enabled = false;
	}

    void OnTriggerEnter(Collider collision) {
		if (CanPlaceFlowers()) {
			playerWithinRange = true;
			uiConfirmPrompt.enabled = true;
		}
    }
}
