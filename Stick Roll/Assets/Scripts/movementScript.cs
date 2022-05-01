using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    public float speed=5;


    // Update is called once per frame
    void Update()
    {
        transform.position+=(speed * Time.deltaTime * Vector3.forward);

    }
}
