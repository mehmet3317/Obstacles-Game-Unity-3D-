using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class player_Remy : MonoBehaviour
{
    public Rigidbody rb;
    private Animator anim;
    int score = 0;
    float timer = 0.0f;
    int seconds;

    public float gravityScale = 5;

    public float thrust = 20f;

    player_Remy remy;

    bool gameOver = false;

    void Start()
    {
        //Physics.gravity = new Vector3(0, 0, 0); // obstacle yavas yavas yukseliyor.

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        anim = gameObject.GetComponent<Animator>();
        anim.enabled = false;

    }
    void Update()
    {

        if (gameOver == false)
        {
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
            if (Input.touchCount == 1)
            {
                var touch = Input.touches[0];

                if (touch.position.y > Screen.height / 7 && touch.position.y < Screen.height / 4.1 &&  touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6
                    && rb.position.x > 3.5 && rb.position.x < 5.3
                   )
                {
                    anim.enabled = true;
                    anim.SetBool("jump", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Jumping", 0, 0.25f);
                    }
                    // anim.transform.position = new Vector3(5.16f, 0, 5.53f);
                    anim.transform.position = new Vector3(4f, 0, 5.4f);
                    anim.transform.rotation = Quaternion.Euler(0, 200f, 0);
                }
                else if( touch.position.y < Screen.height / 10 && rb.position.x > 3.5 && touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6
                    && rb.position.x < 5
                    )
                {
                    anim.enabled = true;
                    anim.SetBool("bend", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Kneeling Down", 0, 0.25f);
                        // anim.Play("Base Layer.Rifle Side Step", 0, 0.25f);
                    }

                    anim.transform.position = new Vector3(4f, 0, 5.4f);
                    anim.transform.rotation = Quaternion.Euler(0, 200f, 0);
                }
                else if (touch.position.y > Screen.height / 7 && touch.position.y < Screen.height / 4.1 && touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6 && rb.position.x < 3.4
                    && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) //sagda zipla
                {
                    anim.enabled = true;
                    anim.SetBool("jump", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Jumping", 0, 0.25f);
                    }
                    // anim.transform.position = new Vector3(5.16f, 0, 5.53f);
                    anim.transform.position = new Vector3(2.3f, 0, 7.4f);
                    anim.transform.rotation = Quaternion.Euler(0, 220f, 0);
                }
                else if (touch.position.y > Screen.height / 7 && touch.position.y < Screen.height / 4.1 && touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6
                    && rb.position.x > 5.3
                    && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) //solda zipla
                {
                    anim.enabled = true;
                    anim.SetBool("jump", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Jumping", 0, 0.25f);
                    }
                    // anim.transform.position = new Vector3(5.16f, 0, 5.53f);
                    anim.transform.position = new Vector3(5.69f, 0, 3.59f);
                    anim.transform.rotation = Quaternion.Euler(0, 220f, 0);
                }
                //bend
                else if (touch.position.y < Screen.height / 10 && touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6
                    && rb.position.x < 3.2
                    && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) //sagda bend
                {
                    anim.enabled = true;
                    anim.SetBool("jump", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Kneeling Down", 0, 0.25f);
                    }
                    // anim.transform.position = new Vector3(5.16f, 0, 5.53f);
                    anim.transform.position = new Vector3(2.3f, 0, 7.4f);
                    anim.transform.rotation = Quaternion.Euler(0, 220f, 0);
                }
                else if (touch.position.y < Screen.height / 10 && touch.position.x > Screen.width / 2.3
                    && touch.position.x < Screen.width / 1.6
                    && rb.position.x > 5.5
                    && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) //solda bend
                {

                    anim.enabled = true;
                    anim.SetBool("jump", true);
                    score++;
                    anim.transform.position = new Vector3(5.5f, 0, 3.59f);


                    if (anim != null)
                    {
                        anim.Play("Base Layer.Kneeling Down", 0, 0.25f);
                    }
                    // anim.transform.position = new Vector3(5.16f, 0, 5.53f);
                    anim.transform.position = new Vector3(5.69f, 0, 3.59f);
                    anim.transform.rotation = Quaternion.Euler(0, 200f, 0);
                }
                //bend
                else if (touch.position.x < Screen.width / 2.3 && touch.position.y < Screen.height / 7
                    && touch.position.y > Screen.height / 10
                    && rb.position.x > 3.5 && rb.position.x < 5
                    )
                { //remy ortada ise sola basarsa


                    anim.transform.position = new Vector3(4f, 0, 5.4f);

                    anim.enabled = true;
                    // anim.SetBool("Base Layer.Quick Steps (1)", true);
                    score++;


                    if (anim != null)
                    {

                        anim.Play("Base Layer.Quick Steps (1)", 0, 0.25f); // sola orjinal 0.25
                    }
                    anim.transform.rotation = Quaternion.Euler(0, 222f, 0);

                }
                else if (touch.position.x > Screen.width / 1.6 && touch.position.y < Screen.height / 7
                    && touch.position.y > Screen.height / 10
                    && rb.position.x > 3.5 && rb.position.x < 5
                   )
                { //remy ortada ise saga basarsa

                    anim.transform.position = new Vector3(4f, 0, 5.4f);


                    anim.enabled = true;
                    //  anim.SetBool("Base Layer.Quick Steps", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Quick Steps", 0, 0.25f);
                    }
                    //anim.transform.position = new Vector3(2.99f, 0, 6.71f);
                    anim.transform.rotation = Quaternion.Euler(0, 222f, 0);

                }

                else if (touch.position.x < Screen.width / 2.3 && touch.position.y < Screen.height / 7
                    && touch.position.y > Screen.height / 10
                    && rb.position.x < 3.6 &&
                    this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) // remy sagda sola basarsa
                {
                    Debug.Log("sagdaydi rtrtrtrt !");

                    anim.transform.position = new Vector3(2.32f, 0, 7.4f);
                    anim.enabled = true;
                    //  anim.SetBool("Base Layer.Quick Steps (1)", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Quick Steps (1)", 0, 0.25f);
                    }

                    // anim.transform.position = new Vector3(4.3f, 0, 5.21f);
                    anim.transform.rotation = Quaternion.Euler(0, 222f, 0);

                }

                else if (touch.position.x > Screen.width / 1.6
                    && touch.position.y < Screen.height / 7
                    && touch.position.y > Screen.height / 10
                    && rb.position.x > 5.3
                    && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) // remy solda saga basras
                {

                    // rb.transform.position = new Vector3(6.2f, 0, 4.3f);

                    anim.enabled = true;
                    //  anim.SetBool("Base Layer.Quick Steps", true);
                    score++;

                    if (anim != null)
                    {
                        anim.Play("Base Layer.Quick Steps", 0, 0.25f);
                    }

                    // anim.transform.position = new Vector3(4.70f, 0, 5.41f);
                    anim.transform.rotation = Quaternion.Euler(0, 222f, 0);

                }
                }

            }
        }
    //col.gameObject.tag == "pendulum" || col.gameObject.tag == "pendulum2" || col.gameObject.tag == "pendulum3" ||
    // 

    private void OnTriggerEnter(Collider col)
          {
              if (col.gameObject.tag == "pendulum" || col.gameObject.tag == "pendulum2" || col.gameObject.tag == "pendulum3" ||
                   col.gameObject.tag == "obstacle")    
              {
                gameOver = true;
                anim.Play("Base Layer.Falling Down", 0, 0.25f);
                StartCoroutine(NextLevelAfterWait());

              }

          }
            IEnumerator NextLevelAfterWait()
            {
                yield return new WaitForSeconds(2.0f);

                SceneManager.LoadScene("LoseScene");
            }


}


