using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class PendulumMovement : MonoBehaviour
{
    private Animator anim;
    float timer = 0.0f;
    int seconds;
    Quaternion _start, _end;

    [SerializeField, Range(0.0f, 360.0f)]
    private float _angle = 90.0f;

    [SerializeField, Range(0.0f, 5.0f)]
    private float _speed = 2.0f;

    [SerializeField, Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        _start = PendulumRotation(-_angle);
        _end = PendulumRotation(_angle);
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
       if (seconds > 2) { 
            _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI/2)+1.0f)/2.9f);
        }
    }

    void resetTimer()
    {

        _startTime = 0.0f;
        seconds = 0;
    }
   Quaternion PendulumRotation(float angle )

    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > 180)
            angleZ -= 360;
        else if (angleZ < -180)
            angleZ += 360;

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);

        return pendulumRotation;

    }
   private void OnTriggerEnter(Collider col)
   {

       if (col.gameObject.tag == "playerr")
        {


            //anim.Play("Base Layer.Falling Down", 0, 0.25f);
            //Thread.Sleep(1000);

           


           //SceneManager.LoadScene("LoseScene");


        }



    }
    
}
