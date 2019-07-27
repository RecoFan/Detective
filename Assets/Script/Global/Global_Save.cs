using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Save : MonoBehaviour
{
    public static Global_Save Instance;
    public float Street_Office_x;
    public float Street_Office_y;
    public float Street_Office_z;
    public float Street_Bar_x;
    public float Street_Bar_y;
    public float Street_Bar_z;
    public float Street_Ramen_x;
    public float Street_Ramen_y;
    public float Street_Ramen_z;
    public float Street_Bank_x;
    public float Street_Bank_y;
    public float Street_Bank_z;
    public int cho;
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
        Street_Office_y = 0.03016758f;
        Street_Office_z = -1.496f;
        Street_Bar_x = 20.46f;
        Street_Bar_y = 0.03016758f;
        Street_Bar_z = -1.5f;
        Street_Ramen_x = -6.97f;
        Street_Ramen_y = 0.03016758f;
        Street_Ramen_z = -1.5f;
        Street_Bank_x = 44.56f;
        Street_Bank_y = 0.03016758f;
        Street_Bank_z = -1.5f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
