using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;

    public void camShake(int n)
    {
        if (n == 0)
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                camAnim.SetTrigger("diagShake");
            }
            else if (rand == 1)
            {
                camAnim.SetTrigger("horzShake");
            }
            else if (rand == 2)
            {
                camAnim.SetTrigger("vertShake");
            }
        } else if (n == 1)
        {
            camAnim.SetTrigger("vertShake");
        }
    }
}
