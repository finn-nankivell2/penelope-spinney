using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairClick : MonoBehaviour
{
	public Sprite eyeOpen;
	public Sprite eyeClosed;
	private Image imageRef;

	void Start() {
		imageRef = GetComponent<Image>();
	}

    void Update()
    {
		if (Input.GetMouseButton(0)) {
			imageRef.sprite = eyeClosed;
		}

		else { imageRef.sprite = eyeOpen; }
    }
}
