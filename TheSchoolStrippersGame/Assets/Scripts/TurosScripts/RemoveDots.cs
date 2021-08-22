using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDots : MonoBehaviour
{

    private void Update()
    {
        DotIsClicked();
    }

    public void DotIsClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDot"))
            {
                
                Destroy(this.gameObject);
            }
        }
    }
}
