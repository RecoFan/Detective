using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorProbe : MonoBehaviour {
    public enum Directions {X, Y, Z};

    public Directions orientation;

    public GameObject mirror;
    public GameObject player;

    private float offset;

    private Vector3 probePos;

    void Update () {
        
        if(orientation == Directions.X)
        {
            offset = mirror.transform.position.x - player.transform.position.x;

            probePos.x = mirror.transform.position.x + offset;
            probePos.y = player.transform.position.y;
            probePos.z = player.transform.position.z;
        } else if(orientation == Directions.Y)
        {
            offset = mirror.transform.position.y - player.transform.position.y;

            probePos.y = mirror.transform.position.y + offset;
            probePos.x = player.transform.position.x;
            probePos.z = player.transform.position.z;
        } else if(orientation == Directions.Z){
            offset = mirror.transform.position.z - player.transform.position.z;

            probePos.z = mirror.transform.position.z + offset;
            probePos.y = player.transform.position.y;
            probePos.x = player.transform.position.x;
        }

        transform.position =  probePos;
    }
}