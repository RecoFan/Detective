using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Office : MonoBehaviour
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
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Trigger_Book")
        {
            if (Input.GetKeyDown(KeyCode.E))
                Fungus.Flowchart.BroadcastFungusMessage("is_book_use");
        }
        if (other.name == "Trigger_TV")
        {
            if (Input.GetKeyDown(KeyCode.E))
                Fungus.Flowchart.BroadcastFungusMessage("is_tv_use_2");
        }
        if (other.name == "Trigger_Hat")
        {
            if (Input.GetKeyDown(KeyCode.E))
                Fungus.Flowchart.BroadcastFungusMessage("is_hat_use");
        }
        if(other.name =="Trigger_Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 0;
                Application.LoadLevel("Street");
            }
        }
    }
}
