using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bar : MonoBehaviour
{
    public float speed;
    Animator ani;
    GameObject t_piano, t_keeper;
    bool can_move;
    // Start is called before the first frame update
    void Start()
    {
        if (Global_Save.Instance.bar_cho == 0)
            transform.position = new Vector3(Global_Save.Instance.Bar_door_x, 0.25f, -0.36f);
        if (Global_Save.Instance.bar_cho == 1)
            transform.position = new Vector3(Global_Save.Instance.Bar_keeper_x, 0.25f, -0.36f);

        ani = this.GetComponent<Animator>();
        speed = 2;
        t_piano = GameObject.Find("UI_piano");
        t_keeper = GameObject.Find("UI_keeper");
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
        if(other.name== "Trigger_Piano")
        {
            t_piano.GetComponent<MeshRenderer>().enabled = true;
        }
        if(other.name == "Trigger_Barkeeper")
        {
            t_keeper.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Trigger_Piano")
        {
            t_piano.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "Trigger_Barkeeper")
        {
            t_keeper.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Trigger_Piano")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_piano_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "Trigger_Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 1;
                Global_Save.Instance.bar_cho = 0;
                Application.LoadLevel("Street");
            }
        }
        if (other.name == "Trigger_Barkeeper")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.bar_cho = 1;
                Application.LoadLevel("Bar_Spot");
            }
        }

    }
    void Can_Move()
    {
        can_move = true;
    }
}
