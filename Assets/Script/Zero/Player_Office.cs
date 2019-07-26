using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Office : MonoBehaviour
{
    public float speed;
    Animator ani;
    bool can_move;
    GameObject t_TV, t_BOOK, t_HAT;
    void Start()
    {
        ani = this.GetComponent<Animator>();
        speed = 2;
        can_move = false;
        t_TV = GameObject.Find("UI_tv");
        t_BOOK = GameObject.Find("UI_book");
        t_HAT = GameObject.Find("UI_hat");
    }

    void Update()
    {
        if (can_move)
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
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Trigger_Book")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_book_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "Trigger_TV")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_tv_use_2");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "Trigger_Hat")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_hat_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger_Book")
        {
            t_BOOK.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "Trigger_TV")
        {
            t_TV.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "Trigger_Hat")
        {
            t_HAT.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Trigger_Book")
        {
            t_BOOK.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "Trigger_TV")
        {
            t_TV.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "Trigger_Hat")
        {
            t_HAT.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void Can_Move()
    {
        can_move = true;
    }
}
