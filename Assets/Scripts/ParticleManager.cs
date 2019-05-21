using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PSO_Console;
//using Debug = System.Diagnostics.Debug;

public class ParticleManager : MonoBehaviour
{
    public int numParticles = 100;
    public Vector3 targetPosition;
//    public ParticleMover particle;
    public Vector3 availableArea = new Vector3(50, 50, 50);
    public GameObject globalBestPos; 
    
//    private List<ParticleMover> particles;
    public ParticleGO protoParticle;
//    private List<ParticleGO> particles;
    private ParticleGO[] particles;
    public GameObject Target;

    private Swarm swarm;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Target.transform.position;
        float[] targetPos = {targetPosition.x, targetPosition.z, targetPosition.y};    
        swarm = new Swarm(numParticles, 3, 1000, targetPos);
        particles = new ParticleGO[numParticles];

        for (int i = 0; i < numParticles; i++)
        {
            ParticleGO newP = Instantiate(protoParticle);
            newP.SetPosition(swarm.GetParticlePos(i));
            particles[i] = newP;
        }

        Debug.Log(particles);



        // Generate Particles
//        for (int i = 0; i < numParticles; i++)
//        {
//            ParticleMover newParticle = Instantiate<ParticleMover>(particle);
//            // Assign the randomized initial values to the Particle
//            Vector3 initPos = new Vector3(Random.Range(-(availableArea.x/2), availableArea.x/2),Random.Range(-(availableArea.y/2), availableArea.y/2),Random.Range(-(availableArea.z/2), availableArea.z/2));
//            newParticle.transform.position = initPos;
//            newParticle.targetPos = targetPosition;
//            newParticle.personalBestPos = initPos;
//            if (i == 0)
//            {
//                globalBestPos.transform.position = initPos;
//                newParticle.globalBestPos = globalBestPos;
//            }
//            else
//            {
//                globalBestPos.transform.position = newParticle.CompareVectors(initPos, globalBestPos.transform.position);
//                newParticle.globalBestPos = globalBestPos;
//            }
//            particles.Add(newParticle);
//        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        swarm.SimulateStep();
        for (int i = 0; i < numParticles; i++)
        {
            particles[i].SetPosition(swarm.GetParticlePos(i));
        }
    }

    void updateParticle(ParticleMover particle)
    {
        
    }
}
