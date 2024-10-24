using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
	public string pickupID;
	public Vector3 rotation = new Vector3(0f, 200f, 0f);

    // Start is called before the first frame update
    void Awake()
    {
		switch (pickupID) {
			case "key":
				if (StateScript.hasKey) {
					Destroy(this.gameObject);
				}
				break;
			case "poppy":
				if (StateScript.hasPoppy) {
					Destroy(this.gameObject);
				}
				break;
			case "rose":
				if (StateScript.hasRose) {
					Destroy(this.gameObject);
				}
				break;
			case "tulip":
				if (StateScript.hasTulip) {
					Destroy(this.gameObject);
				}
				break;
			default: break;
		}
    }

	void PickupBehaviour() {
		switch (pickupID) {
			case "key":
				StateScript.hasKey = true; break;
			case "poppy":
				StateScript.hasPoppy = true; break;
			case "rose":
				StateScript.hasRose = true; break;
			case "tulip":
				StateScript.hasTulip = true; break;
			default: break;
		}
	}

    // Update is called once per frame
    void Update()
    {
    	transform.Rotate(rotation * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
		PickupBehaviour();
		Destroy(this.gameObject);
    }
}
