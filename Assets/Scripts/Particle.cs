using System;

namespace PSO_Console
{
    public class Particle
    {
        private string id;
        private float[] pos;
        private float[] vel;
        private float[] pBest;

        public Particle(int dimensions, float dimensionRange)
        {
            id = Guid.NewGuid().ToString();
            pos = new float[dimensions];
            vel = new float[dimensions];
            
            Random rand = new Random();
            for (int i = 0; i < dimensions; i++)
            {
                pos[i] = Utility.GetRandom(0, dimensionRange);
                vel[i] = Utility.GetRandom(0, dimensionRange);
            }

            pBest = pos;
        }

        public void UpdateVelocity(float[] gBest, float w, float c1, float c2)
        {
            // todo: make this scalable
            Random random = new Random();
            float rand1 = Utility.GetRandom(0, 1);
            float rand2 = Utility.GetRandom(0, 1);
            float nX = w * vel[0] + c1 * rand1 * (pBest[0] - pos[0]) + c2 * rand2 * (gBest[0] - pos[0]);
            float nY = w * vel[1] + c1 * rand1 * (pBest[1] - pos[1]) + c2 * rand2 * (gBest[1] - pos[1]);
            float nZ = w * vel[2] + c1 * rand1 * (pBest[2] - pos[2]) + c2 * rand2 * (gBest[2] - pos[2]);
            
            vel[0] = nX;
            vel[1] = nY;
            vel[2] = nZ;
        }

        public float[] UpdatePosition()
        {
            float[] newPosition = new float[pos.Length];
            for (int i = 0; i < pos.Length; i++)
            {
                newPosition[i] = pos[i] + vel[i];
            }

            pos = newPosition;
            return newPosition;
        }

        public void UpdatePBest(float[] target)
        {
             // Could save comp time by storing distance.
            var bestToTarget = Utility.ArrDistance(pBest, target);
            var posToTarget = Utility.ArrDistance(pos, target);
            if (posToTarget < bestToTarget)
            {
                pBest = pos;
            }
        }

        public float[] GetPosition()
        {
            return pos;
        }
    }
    
}