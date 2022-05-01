using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutterScript : MonoBehaviour
{
    private float donmeHizi = 40;
    void Update()
    {
        transform.Rotate(0, 0, donmeHizi);
    }
}
