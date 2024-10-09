using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    public float opacityAmt = 0.5f;
    public bool isCharged = true;
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var col = myRenderer.material.color;
        float amt = (isCharged) ? 1.0f : opacityAmt;
        myRenderer.material.color = new Color(col.r, col.g, col.b, amt);

        transform.Rotate(new Vector3(0f, 150f * Time.deltaTime, 0f ));
    }
}
