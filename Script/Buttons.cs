using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    bool pause = false;
    public GameObject paused;
  

    // Start is called before the first frame update
    void Start()
    {
        paused.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

     
    }

    public void Pause()
    {
        if (pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            paused.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
            paused.SetActive(false);
        }
    }

   

}
