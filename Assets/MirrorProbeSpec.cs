using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorProbeSpec : MonoBehaviour {

    public GameObject player;

    private float offset;

    private Vector3 probePos;

    void Update () {
        

        offset = -2.55f - player.transform.position.x;

        probePos.x = -2.55f + offset;
        probePos.y = player.transform.position.y;
        probePos.z = player.transform.position.z;

        transform.position =  probePos;
    }
}