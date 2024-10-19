using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSScript : MonoBehaviour
{
	public float sensX;
	public float sensY;

	public Transform orientation;

	private float camRotX;
	private float camRotY;

	private Camera cam;

	public float startingFOV;
	public float FOVChangeRate = 0.1f;
	private float targetFov;

    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		startingFOV = GetComponent<Camera>().fieldOfView;
		targetFov = startingFOV;
		cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
		float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

		camRotY += mouseX;
		camRotX -= mouseY;
		camRotX = Mathf.Clamp(camRotX, -90f, 90f);

		transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);
		orientation.rotation = Quaternion.Euler(0, camRotY, 0);

		if (Input.GetMouseButton(1)) {
			SetTargetFOV(startingFOV/2);
		}

		else {
			SetTargetFOV(startingFOV);
		}

		cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, targetFov, FOVChangeRate * Time.deltaTime);

    }

	public void SetTargetFOV(float target) {
		targetFov = target;
	}
}
