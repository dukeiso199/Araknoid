using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Game_Controller.instance.Scored();
        // Destroy the whole Block
        Destroy(gameObject,2);

    }
}

