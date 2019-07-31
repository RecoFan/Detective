using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Back : MonoBehaviour
{
    public float speed;
    Animator ani;
    GameObject t_bin, t_dave;
    bool can_move;
    // Start is called before the first frame update
    void Start()
    {
        t_bin = GameObject.Find("UI_bin");
        t_dave = GameObject.Find("UI_dave");
        ani = this.GetComponent<Animator>();
        speed = 2;
        can_move = true;
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "trigger_dave")
        {
            t_dave.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_bin")
        {
            t_bin.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "trigger_dave")
        {
            t_dave.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_bin")
        {
            t_bin.GetComponent<MeshRenderer>().enabled = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "trigger_dave")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_dave_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_bin")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_bin_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 4;
                Global_Save.Instance.loadName = "Street";
                Application.LoadLevel("LoadingScene");
                //Application.LoadLevel("Street");
            }
        }

    }

    void Can_Move()
    {
        can_move = true;
    }
}
