using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }
    
    public void SetPosition(float[] newPos)
    {
        if (newPos.Length == 3)
        {
            transform.position = new Vector3(newPos[0], newPos[2], newPos[1]);
        } else if (newPos.Length == 2)
        {
            transform.position = new Vector3(newPos[0], 0f, newPos[1]);
        }
    }
}
