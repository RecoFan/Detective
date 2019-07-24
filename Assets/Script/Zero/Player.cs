using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Animator ani;
    void Start()
    {
        ani = this.GetComponent<Animator>();
        speed = 2;
    }

    void Update()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.localEulerAngles= new Vector3(this.transform.rotation.x, -90,  transform.rotation.z);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            ani.SetBool("Is_Walking", true);
        }
        else
        {
            ani.SetBool("Is_Walking", false);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.localEulerAngles = new Vector3(this.transform.rotation.x, 90, transform.rotation.z);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            ani.SetBool("Is_Walking", true);
        }
        else if(!Input.GetKey(KeyCode.A))
        {
            ani.SetBool("Is_Walking", false);
        }
        
    }


}
