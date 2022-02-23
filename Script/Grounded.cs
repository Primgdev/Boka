using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    
    public GameObject dust;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Ground"))
        {

            Instantiate(dust, transform.position, dust.transform.rotation);
        }
    }
}
