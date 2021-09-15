using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysicsScript : MonoBehaviour
{
   
    [SerializeField]
    float  waterDrag = 10;

    Rigidbody2D rb;

    [SerializeField]
    bool removeFromParent = true;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

        if (removeFromParent)
        {
            this.gameObject.transform.parent = null;
        }
        

    }
    private void Update()
    {
        if (this.transform.position.y < 0)
        {
            rb.drag = waterDrag;

            if (this.transform.position.y < -6)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
