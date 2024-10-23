using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
	public static Vector3 playerMeadowPos = Vector3.zero;
	public static bool playerMeadowPosHasBeenSet = false;

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
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
