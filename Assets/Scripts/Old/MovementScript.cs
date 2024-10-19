using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed;
	public float groundDrag;

	[Header("Jumping")]
	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	float jumpStorage = 0;
	
	[Range(0, 100)]
	public float jumpStorageAmt = 100f;

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
			jumpStorage = jumpStorageAmt;
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

		if (jumpStorage > 0.0) {
			jumpStorage -= 100f * Time.deltaTime;
			
			if (grounded) {
				Jump();
			}
		}
    }

	Vector3 calcMoveDirection() {
		return orientation.forward * verticalInput + orientation.right * horizontalInput;
	}

    void FixedUpdate() {
		// Move player
		moveDirection = this.calcMoveDirection();
		Vector3 forceToAdd;
		forceToAdd = moveDirection.normalized * moveSpeed * 10f;
		rb.AddForce(forceToAdd, ForceMode.Force);
		rb.AddForce(Physics.gravity*1.5f, ForceMode.Acceleration);

    }

    void Jump() {
    	jumpStorage = 0.0f;
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void TeleportTo(Vector3 target) {
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    	transform.position = new Vector3(target.x, target.y, target.z);
    }
}
