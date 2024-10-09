using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairClick : MonoBehaviour
{
	public Sprite eyeOpen;
	public Sprite eyeHover;
	public Sprite eyeClosed;
	private Image imageRef;
	public GameObject cameraRef;
	private CameraTeleport camScript;

	void Start() {
		imageRef = GetComponent<Image>();
		camScript = cameraRef.GetComponent<CameraTeleport>();
	}

    void Update()
    {
		if (Input.GetMouseButton(0)) {
			imageRef.sprite = eyeClosed;
		}

		else if (camScript.IsRayCastHit()) {
			imageRef.sprite = eyeHover;
		}

		else { imageRef.sprite = eyeOpen; }
    }
}
