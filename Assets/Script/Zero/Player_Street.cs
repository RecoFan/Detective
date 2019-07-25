using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Street : MonoBehaviour
{
    public float speed;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
        speed = 2;
        if(Global_Save.Instance.cho==0)
            transform.position = new Vector3(Global_Save.Instance.Street_Office_x, Global_Save.Instance.Street_Office_y, Global_Save.Instance.Street_Office_z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.localEulerAngles = new Vector3(this.transform.rotation.x, -90, transform.rotation.z);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            ani.SetBool("Is_Walking", true);
        }
        else
        {
            ani.SetBool("Is_Walking", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localEulerAngles = new Vector3(this.transform.rotation.x, 90, transform.rotation.z);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            ani.SetBool("Is_Walking", true);
        }
        else if (!Input.GetKey(KeyCode.A))
        {
            ani.SetBool("Is_Walking", false);
        }
    }
}
