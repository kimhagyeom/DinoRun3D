using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float moveSpeedZ; //z축 움직이는 속도 변수
    void Start()
    {
        
    }
    void Update()
    {
        //trnaform.Translate(0,0,moveSpeedZ);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * Time.deltaTime ;
            transform.Translate(0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += Vector3.left * Time.deltaTime;
            transform.Translate(-0.02f, 0, 0);
        }
    }
}
