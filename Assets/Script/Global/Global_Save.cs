using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Save : MonoBehaviour
{
    public static Global_Save Instance;
    public float Street_Office_x;
    public float Street_Bar_x;
    public float Street_Ramen_x;
    public float Street_Bank_x;
    public float Street_Back_x;
    public bool office_move_state;
    public int cho;
    public int bar_cho;
    public float Bar_door_x;
    public float Bar_keeper_x;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
        Street_Office_x = 2.676593f;
        Street_Bar_x = 20.46f;
        Street_Ramen_x = -6.97f;
        Street_Bank_x = 44.56f;
        Street_Back_x = 42.26f;
        Bar_door_x = 3.48f;
        Bar_keeper_x = -0.38f;
        office_move_state = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
