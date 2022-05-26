using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObstacleMovement : MonoBehaviour
{
    public Rigidbody rb2;
    public ObstacleMovement myObject;
    public GameObject target;

    float timer = 0.0f;
    int seconds;
    void Start()
    {
        // Thread.Sleep(2000);

    }

    float degreesPerSecond = 120;

    private void Update()
    {
        if (rb2.isKinematic != true)
        {
             timer += Time.deltaTime;
             seconds = (int)timer % 60;
            // transform.Rotate(new Vector3(40, degreesPerSecond, 0) * Time.deltaTime);
            // transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);

            if (seconds > 15)
            {
                transform.RotateAround(target.transform.position, Vector3.up, 90 * Time.deltaTime);
            }
           // transform.Rotate(Vector3.right * Time.deltaTime);
        }

    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "playerr")
        {
            rb2.isKinematic = true;
            Debug.Log("ENTERED !");
            SceneManager.LoadScene("LoseScene");
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "playerr")
        {
        //    Thread.Sleep(1000);
        //    SceneManager.LoadScene("LoseScene");
        }

    }

}



