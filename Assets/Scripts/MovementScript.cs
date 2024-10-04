using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweens;

public class MovementScript : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed;
	public float groundDrag;

	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool jumpStorage = false;

	[Header("Keybindings")]
	public KeyCode jumpKey = KeyCode.Space;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask whatIsGround;
	public GameObject player;
	bool grounded;

	public Transform orientation;
	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
    }

    void Update() {
		// Get keys pressed
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(jumpKey)) {
			jumpStorage = true;
		}

		// Check if currently grounded and apply drag
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
		rb.drag = (grounded) ? groundDrag : 0;

		// Clamp speed
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		if (flatVel.magnitude > moveSpeed) {
			Vector3 limitedVel = flatVel.normalized * moveSpeed;
			rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		}

		if (jumpStorage && grounded) {
			Jump();
		}
    }

	Vector3 calcMoveDirection() {
		return orientation.forward * verticalInput + orientation.right * horizontalInput;
	}

    void FixedUpdate() {
		// Move player
		moveDirection = this.calcMoveDirection();
		var forceToAdd = moveDirection.normalized * moveSpeed * 10f;
		forceToAdd *= (grounded) ? 1f : airMultiplier;
		rb.AddForce(forceToAdd, ForceMode.Force);

		rb.AddForce(Physics.gravity, ForceMode.Acceleration);

    }

    void Jump() {
    	jumpStorage = false;
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void TeleportTo(Vector3 target) {
		rb.velocity = Vector3.zero;
        var tween = new PositionTween {
            to = target,
            duration = 0.25f
        };
        player.AddTween(tween);
    }
}