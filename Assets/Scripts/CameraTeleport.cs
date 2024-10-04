using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    public LayerMask teleportMask;
    private Camera cam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            TeleportDestRaycast();
        }
    }

    public void TeleportDestRaycast() {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, teleportMask)) {
            Transform objectHit = hit.transform;
            player.GetComponent<MovementScript>().TeleportTo(hit.transform.position);
        }
    }
}