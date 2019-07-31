using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene() {
        //Debug.Log(Global_Save.Instance.loadNameIndex);
        //AsyncOperation async = Application.LoadLevelAsync(Global_Loading.GetInstance().loadName);
        AsyncOperation async = Application.LoadLevelAsync(Global_Save.Instance.loadName);
        yield return async;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
