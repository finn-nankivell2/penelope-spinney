using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitEffects : MonoBehaviour
{
	private RectTransform rtransform;
	private Vector3 startPos;
	public float jitter = 10f;
	public float repeatRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
		rtransform = GetComponent<RectTransform>();
		startPos = rtransform.position;
		InvokeRepeating(nameof(this.RandJitter), 0f, repeatRate);
    }

	void RandJitter() {
		Vector3 randOffset = new Vector3(Random.Range(-jitter, jitter), Random.Range(-jitter, jitter), 0f);
		rtransform.position = startPos + randOffset;
	}
}
