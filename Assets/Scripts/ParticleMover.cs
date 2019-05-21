using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject globalBestPos;
    public Vector3 personalBestPos;
    public Vector3 targetPos;
    public float w = 0.2f;
    public float c1 = 0.5f;
    public float c2 = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
//        rb.AddForce(0,0,1*speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        personalBestPos = CompareVectors(position, personalBestPos);
        globalBestPos.transform.position = CompareVectors(position, globalBestPos.transform.position);
        Vector3 gBestPos = globalBestPos.transform.position;
        // check for pBest and gBest
        float rand1 = Random.Range(0f, 1f);
        float rand2 = Random.Range(0f, 1f);
        var velocity = rb.velocity;
        float xVel = w * velocity.magnitude + c1 * Random.Range(0f, 1f) * (personalBestPos.x - velocity.x) +
                     c2 * Random.Range(0f, 1f) * (gBestPos.x - velocity.x);
        float yVel = w * velocity.magnitude + c1 * Random.Range(0f, 1f) * (personalBestPos.y - velocity.y) +
                     c2 * Random.Range(0f, 1f) * (gBestPos.y - velocity.y); 
        float zVel = w * velocity.magnitude + c1 * Random.Range(0f, 1f) * (personalBestPos.z - velocity.z) +
                     c2 * Random.Range(0f, 1f) * (gBestPos.z - velocity.z); 
        Vector3 newVelocity = new Vector3(xVel, yVel, zVel);
//        rb.velocity = Vector3.zero;
        rb.velocity = newVelocity;
//        rb.AddForce(newVelocity);
        transform.LookAt(newVelocity*1000);

//        float randX = Random.Range(-100, 100);
//        float randX = 1;
//        float randY = Random.Range(-100, 100);
//        float randZ = Random.Range(-100, 100);
//        Vector3 randVec = new Vector3(randX, randY, randZ);
//        transform.LookAt(randVec);
//        rb.AddForce(randVec, ForceMode.VelocityChange);
        Debug.Log(newVelocity);
    }

    public void ForceSetPBest()
    {
        personalBestPos = transform.position;
    }

    public Vector3 CompareVectors(Vector3 position, Vector3 best)
    {
        if (Vector3.Distance(targetPos, position) < Vector3.Distance(targetPos, best))
        {
            return position;
        }
        else
        {
            return best;
        }
    }
}
