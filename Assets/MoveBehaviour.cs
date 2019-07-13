using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //获取垂直轴
        float vertical = Input.GetAxis("Vertical");    //获取水平轴 
        Vector3 direction =  new Vector3(horizontal, 0, vertical);

        rb.MovePosition(transform.position + direction.normalized * Time.deltaTime);
    }
}
