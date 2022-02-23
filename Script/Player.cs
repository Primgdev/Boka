using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed;
    public float jumpForce;
    Animator anim;
    public GameObject apple;
    public GameObject banana;
    public GameObject kiwi;
    public GameObject strawberry;
    public GameObject ash;
    public GameObject blood;
    public GameObject pickup;
    public GameObject life1;
    public GameObject life2;
    public AudioSource walk;
    public Rigidbody2D rb2d;
    public float timeRemaining;
    public bool timer ;
    public Text timeText;
    public bool IsGrounded;
    public int health;
    public bool moveLeft = false;
    public bool moveRight = false;
    public GameObject failed;
 

    // Start is called before the first frame update
    public void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            print("you are dead-");
            timer = false;
            failed.SetActive(true);
            life1.SetActive(false);
            life2.SetActive(false);
        }
       
        else if(health == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }
        else if(health == 2)
        {
            life1.SetActive(true);
            life2.SetActive(true);
        }

        


       
       

        if(timeRemaining < 5)
        {
            timeText.color = Color.red;
        }

        if (Input.GetKey(KeyCode.A) && health > 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
            walk.Play();
            anim.SetTrigger("run");
        }
        if (Input.GetKey(KeyCode.D) && health > 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            walk.Play();
            anim.SetTrigger("run");
        }
        if (Input.GetKey(KeyCode.Space) && IsGrounded == true)
        {
            rb2d.AddForce(Vector3.up * jumpForce);

            //anim.SetTrigger("jump");
        }

        if (moveLeft && health > 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetTrigger("run");
        }

        if (moveRight && health > 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetTrigger("run");
        }


        if (timer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

          

            else
            {

                Debug.Log("Time has run out!");
                failed.SetActive(true);
                
                timeRemaining = 0;
                timer = false;
            }
        }


      

       

    }

    public void Left()
    {
        if (health > 0)
        {
            moveLeft = true;
            anim.SetTrigger("run");
        }
    }

    public void Right()
    {
        if (health > 0)
        {
            moveRight = true;
            anim.SetTrigger("run");
        }
    }

    public void Jump ()
    {
        if (IsGrounded == true && health > 0)
        {
            rb2d.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("jump");
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spikes")
        {
            health -= 1;
            
            print("thats spike");
            Instantiate(blood, transform.position, blood.transform.rotation);
            anim.SetTrigger("hit");
        }
        else if(col.gameObject.tag == "Fire")
        {
            health -= 1;
            Instantiate(ash, transform.position, ash.transform.rotation);
            anim.SetTrigger("hit");
            print("its fire");
        }
        else if(col.gameObject.tag == "Apple")
        {
           
            Instantiate(pickup, transform.position, pickup.transform.rotation);
            apple.SetActive(true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Strawberry")
        {
           
            Instantiate(pickup, transform.position, pickup.transform.rotation);
            strawberry.SetActive(true);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "Kiwi")
        {
           
            Instantiate(pickup, transform.position, pickup.transform.rotation);
            kiwi.SetActive(true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Banana")
        {
          
            Instantiate(pickup, transform.position, pickup.transform.rotation);
            banana.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            print("is grounded");
        }
        else
        {
            IsGrounded = false;
        }

    }

    
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            IsGrounded = false;
            print("is not grounded");
        }
    }


    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb2d.velocity = Vector3.zero;
        
    }


    public void GameOver()
    {
        speed = 0;
        jumpForce = 0;
        timer = false;
    }

}
