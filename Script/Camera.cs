using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Target;
    private Vector3 Offset;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - Target.transform.position;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.transform.position + Offset;
    }
}
