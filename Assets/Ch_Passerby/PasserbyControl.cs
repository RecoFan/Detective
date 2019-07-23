using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasserbyControl : MonoBehaviour
{
    public Animator anim;
    public float MoveSpeed;
    private float MoveDistance = 3400;
    private float moving_dis = 0;
    private int rest_time_remain = 0;
    private int isRotating = 0;
    private int rotateAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking",false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
            anim.SetBool("isWalking", true);
        }
        else {
            anim.SetBool("isWalking", false);
        }*/
        if (rest_time_remain == 0 && isRotating == 0)
        {
            anim.SetBool("isWalking", true);
            transform.Translate(new Vector3(0, 0, MoveSpeed * Time.deltaTime));
            moving_dis = moving_dis + MoveSpeed;
            if (moving_dis > MoveDistance)
            {
                rest_time_remain = 20;
            }
        }
        else if (isRotating == 0)
        {
            anim.SetBool("isWalking", false);
            rest_time_remain--;
            if (rest_time_remain == 0) {
                isRotating = 1;
                moving_dis = 0;
            }
        }
        else {
            anim.SetBool("isWalking", false);
            transform.Rotate(Vector3.up, 10);
            rotateAngle += 10;
            if (rotateAngle == 180) {
                rotateAngle = 0;
                isRotating = 0;
            }
        }
    }
}
