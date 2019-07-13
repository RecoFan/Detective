using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Trigger : MonoBehaviour
{
   void OnTriggerEnter () {
       Debug.Log("Enter Area!");
   }

   void OnTriggerExit () {
       Debug.Log("Leave Area!");
   }
}
