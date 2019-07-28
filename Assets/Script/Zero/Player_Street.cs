using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Street : MonoBehaviour
{
    public float speed;
    Animator ani;
    bool can_move;
    GameObject t_black, t_back, t_bank, t_bank2, t_npc1, t_npc2, t_ramen, t_board, t_bar,t_office;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
        speed = 2;
        can_move = true;
        t_black = GameObject.Find("UI_black");
        t_back = GameObject.Find("UI_back");
        t_bank = GameObject.Find("UI_bank");
        t_bank2 = GameObject.Find("UI_bank2");
        t_npc1 = GameObject.Find("UI_npc1");
        t_npc2 = GameObject.Find("UI_npc2");
        t_ramen = GameObject.Find("UI_ramen");
        t_board = GameObject.Find("UI_board");
        t_bar = GameObject.Find("UI_bar");
        t_office = GameObject.Find("UI_office");
        if (Global_Save.Instance.cho==0)
            transform.position = new Vector3(Global_Save.Instance.Street_Office_x, 0.03016758f, -1.5f);
        if (Global_Save.Instance.cho == 1)
            transform.position = new Vector3(Global_Save.Instance.Street_Bar_x, 0.03016758f, -1.5f);
        if (Global_Save.Instance.cho == 2)
            transform.position = new Vector3(Global_Save.Instance.Street_Bank_x, 0.03016758f, -1.5f);
        if (Global_Save.Instance.cho == 3)
            transform.position = new Vector3(Global_Save.Instance.Street_Ramen_x, 0.03016758f, -1.5f);
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
        if (other.name == "trigger_ramen")
        {
            t_ramen.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_npc1")
        {
            t_npc1.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_bar")
        {
            t_bar.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_board")
        {
            t_board.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_black")
        {
            t_black.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_npc2")
        {
            t_npc2.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_back")
        {
            t_back.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_bank1")
        {
            t_bank.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_bank2")
        {
            t_bank2.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.name == "trigger_office")
        {
            t_office.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "trigger_ramen")
        {
            t_ramen.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_npc1")
        {
            t_npc1.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_bar")
        {
            t_bar.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_board")
        {
            t_board.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_black")
        {
            t_black.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_npc2")
        {
            t_npc2.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_back")
        {
            t_back.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_bank1")
        {
            t_bank.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_bank2")
        {
            t_bank2.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name == "trigger_office")
        {
            t_office.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "trigger_bar")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 1;
                Application.LoadLevel("Bar");
            }
        }
        if (other.name == "trigger_bank1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 2;
                Application.LoadLevel("Bank");
            }
        }
        if (other.name == "trigger_ramen")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 3;
                Application.LoadLevel("Ramen");
            }
        }
        if (other.name == "trigger_bank2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_bank2_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_board")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_board_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_npc1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_npc1_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_npc2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_npc2_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
        if (other.name == "trigger_office")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Global_Save.Instance.cho = 0;
                Application.LoadLevel("Office");
            }
        }
        if (other.name == "trigger_black")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("is_black_use");
                can_move = false;
                ani.SetBool("Is_Walking", false);
            }
        }
    }
    void Can_Move()
    {
        can_move = true;
    }

}
