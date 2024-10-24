using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
	public static Vector3 playerMeadowPos = Vector3.zero;
	public static bool playerMeadowPosHasBeenSet = false;

	public static Dictionary<string, bool> stateMap;

	private static bool hasSetup = false;
	public static bool playerCollectedItem = false;

	void Awake() {
		DontDestroyOnLoad(this.gameObject);

		if (!hasSetup) {
			SetupOnce();
			hasSetup = true;
		}
	}

	void SetupOnce() {
		stateMap = new Dictionary<string, bool>();
		stateMap["key"] = false;
		stateMap["rose"] = false;
		stateMap["tulip"] = false;
		stateMap["poppy"] = false;
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
