using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public Animator anim;
    public GameObject finished;
    public Player py;

    void Start()
    {
        finished.SetActive(false);
        // anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            anim.SetTrigger("EndFlag");
            finished.SetActive(true);
            print("triggered????");
            py.GameOver();
        }
    }
}
