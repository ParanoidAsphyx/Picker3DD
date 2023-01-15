using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public MovementData MovementData;
        public ScaleData ScaleData;
    }

    [Serializable]
    public struct MovementData
    {
        public float ForwardSpeed;
        public float SidewaysSpeed;
        public float ForwardForceCounter;
        public float SpeedUpData;

        public MovementData(float forwardSpeed, float sidewaysSpeed, float forwardForceCounter, float speedUpData)
        {
            ForwardSpeed = forwardSpeed;
            SidewaysSpeed = sidewaysSpeed;
            ForwardForceCounter = forwardForceCounter;
            SpeedUpData = speedUpData;
        }
    }

    [Serializable]
    public struct ScaleData
    {
        public float ScaleCounter;

        public ScaleData(float scaleCounter)
        {
            ScaleCounter = scaleCounter;
        }
    }
}