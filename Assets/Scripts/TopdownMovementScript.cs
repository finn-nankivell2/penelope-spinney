using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownMovementScript : MonoBehaviour
{
	[Header("Movement")]
	public float speed = 100f;
	public float runSpeed = 100f;
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

	[Header("SlopeHandling")]
	public float playerHeight = 2f;
	public float maxSlopeAngle = 80;
	private RaycastHit slopeHit;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		modelAnimation = model.GetComponent<Animation>();
    }

	private Vector3 GetMoveDirection() {
		return new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal")).normalized;
	}

	private float GetSpeed() {
		return (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : speed;
	}

	private bool IsOnSlope() {
		if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) {
			float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
			return angle < maxSlopeAngle && angle != 0;
		}
		return false;
	}

	void FixedUpdate() {
		rb.drag = groundDrag;
		Vector3 moveDir = GetMoveDirection();
		Vector3 forceToAdd = moveDir * GetSpeed();

		if (IsOnSlope()) {
			Vector3 slopeMoveDir = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);
			rb.AddForce(slopeMoveDir * GetSpeed(), ForceMode.Force);
		}

		else {
			rb.AddForce(forceToAdd, ForceMode.Force);
		}

		lastMoveDir = (moveDir.magnitude > 0.0f) ? moveDir : lastMoveDir;
	}

    // Update is called once per frame
    void Update()
    {
		cam.position = transform.position + cameraOffset;
		modelTransform.forward = lastMoveDir;

		if (GetMoveDirection().magnitude <= walkAnimationTransitionLength) {
			modelAnimation.Play("reset");
		}

		else if (Input.GetKey(KeyCode.LeftShift)) {
			modelAnimation.Play("run_cycle");
		}

		else {
			modelAnimation.Play("walk_cycle");
		}
    }
}
