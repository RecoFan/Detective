using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBegin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate () {
            Global_Save.Instance.loadName = "FlashBack";
            Application.LoadLevel("LoadingScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
