using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawn : MonoBehaviour
{
    public float threshold;
    void FixedUpdate()
    {

        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0f,0f,0f);
        }
        
    }
}
