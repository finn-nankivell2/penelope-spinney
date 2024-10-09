using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    public LayerMask teleportMask;
    private Camera cam;
    public GameObject player;

    private bool queueTeleportRequest = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            queueTeleportRequest = true;
        }
    }

    void FixedUpdate(){
        if (queueTeleportRequest)
        {
            TeleportDestRaycast();
            queueTeleportRequest = false;
        }

    }

    public bool IsRayCastHit() {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        return Physics.Raycast(ray, out hit, 10000f, teleportMask, QueryTriggerInteraction.Collide);
    }

    public void TeleportDestRaycast() {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, 10000f, teleportMask, QueryTriggerInteraction.Collide)) {
            var pos = hit.transform.position;
            Debug.Log("Pos: " + pos);
            player.GetComponent<MovementScript>().TeleportTo(pos);

            // Destroy(hit.transform.gameObject);
        }
    }
}
