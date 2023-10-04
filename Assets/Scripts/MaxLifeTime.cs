using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLifeTime : MonoBehaviour
{
    public float Time;
    void Start()
    {
        Destroy(this.gameObject, Time);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            this.gameObject.SetActive(false);

        }
    }
}
