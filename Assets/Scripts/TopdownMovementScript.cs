using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownMovementScript : MonoBehaviour
{
	[Header("Movement")]
	public float speed = 100f;
	public float groundDrag = 7f;

	private Vector3 lastMoveDir = Vector3.back;

	[Header("Animation")]
	public float walkAnimationTransitionLength = 0.2f;

	public Transform modelTransform;
	public GameObject model;
	private Animation modelAnimation;

	[Header("Camera")]
	public Vector3 cameraOffset = Vector3.zero;
	public Transform cam;

	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		modelAnimation = model.GetComponent<Animation>();
    }

	private Vector3 GetMoveDirection() {
		return new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal")).normalized;
	}

	void FixedUpdate() {
		rb.drag = groundDrag;
		Vector3 moveDir = GetMoveDirection();
		Vector3 forceToAdd = moveDir * speed;
		rb.AddForce(forceToAdd, ForceMode.Force);

		lastMoveDir = (moveDir.magnitude > 0.0f) ? moveDir : lastMoveDir;
	}

    // Update is called once per frame
    void Update()
    {
		cam.position = transform.position + cameraOffset;
		modelTransform.forward = lastMoveDir;

		if (GetMoveDirection().magnitude <= walkAnimationTransitionLength) {
			modelAnimation.Play("idle");
		}

		else {
			modelAnimation.Play("walk_cycle");
		}
    }
}
