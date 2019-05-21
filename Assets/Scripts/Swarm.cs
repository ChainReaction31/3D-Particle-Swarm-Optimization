using System;

namespace PSO_Console
{
    public class Swarm
    {
        int numParticles = 50;
        public int numDimensions = 2;
        float dimensionSize = 500000;
        public Particle[] particles;
        float[] gBest;
        float[] targetPos = {250f, 250f};
        float c1 = 0.5f;
        float c2 = 0.5f;
        float w = 0.8f;
        float marginOfError = 0.00001f;

        public Swarm(int numParticles, int dimensions, float dimensionSize, float[] targetPos)
        {
            this.numParticles = numParticles;
            this.dimensionSize = dimensionSize;
            numDimensions = dimensions;
            this.targetPos = targetPos;
            particles = new Particle[numParticles];
            for (int i = 0; i < numParticles; i++)
            {
                particles[i] = new Particle(numDimensions, dimensionSize);
                if (i == 0)
                {
                    gBest = particles[i].GetPosition();
                }
                else
                {
                    CheckGBest(particles[i].GetPosition());
                }
            }
        }

        public void Simulate()
        {
            while (Utility.ArrDistance(gBest, targetPos) > marginOfError)
            {
                foreach (var particle in particles)
                {
                    particle.UpdateVelocity(gBest, w, c1, c2);
                    var pos = particle.UpdatePosition();
                    particle.UpdatePBest(targetPos);
                    CheckGBest(pos);
                }
            }
            Console.WriteLine("Position Optimized");
        }

        public void SimulateStep()
        {
            foreach (var particle in particles)
            {
                particle.UpdateVelocity(gBest, w, c1, c2);
                var pos = particle.UpdatePosition();
                particle.UpdatePBest(targetPos);
                CheckGBest(pos);
            }
        }

        public void CheckGBest(float[] position)
        {
            // Could save comp time by storing distance.
            var bestToTarget = Utility.ArrDistance(gBest, targetPos);
            var posToTarget = Utility.ArrDistance(position, targetPos);
            if (posToTarget < bestToTarget)
            {
                gBest = position;
            }
        }

        public float[] GetParticlePos(int index)
        {
            return particles[index].GetPosition();
        }
    }
}