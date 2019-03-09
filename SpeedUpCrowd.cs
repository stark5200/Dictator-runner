using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpCrowd
{
    public int speedUpDelay;
    public float speedUpEffect;
    public float speed;

	public SpeedUpCrowd(int speedUpDelay, float speedUpEffect)
	{
        this.speedUpDelay = speedUpDelay;
        this.speedUpEffect = speedUpEffect;

        void Update()
        {
            if (speedUpDelay == 0)
            {
                speed += speedUpEffect;
            }
            else
            {
                speedUpDelay--;
            }
        }
	}
}
