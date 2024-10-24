using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
	public string pickupID;
	public Vector3 rotation = new Vector3(0f, 200f, 0f);
	public Image uiIndicator;

    // Start is called before the first frame update
    void Start()
    {
		if (StateScript.stateMap[pickupID]) {
			Destroy(this.gameObject);

			if (uiIndicator) {
				uiIndicator.enabled = true;
			}
		}

		else {
			if (uiIndicator) {
				uiIndicator.enabled = false;
			}
		}
    }

	void PickupBehaviour() {
		StateScript.stateMap[pickupID] = true;

		if (uiIndicator) {
			uiIndicator.enabled = true;
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
