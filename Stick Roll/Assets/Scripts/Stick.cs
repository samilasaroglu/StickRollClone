using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private stickCollecter sC;
    private movementScript movScript;
    private float donmeHizi = 5;

    private void Update()
    {
        if (sC.isVerticalStick==false)
        {
            transform.Rotate(0, -donmeHizi, 0);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cutter")
        {
            Cut(other.gameObject.transform);
        }

        if (other.gameObject.tag == "rail")
        {
            if (sC.isVerticalStick)
            {
                sC.character.GetComponent<Rigidbody>().useGravity = true;
                sC.character.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            }
           
        }
        if (other.gameObject.tag == "rail1")
        {
            sC.touch++;
        }
        if (other.gameObject.tag == "rail2")
        {
            sC.touch++;
        }

        if (other.gameObject.tag == "bonus")
        {
            movScript = GetComponent<movementScript>();
            movScript.speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rail1")
        {
            sC.touch--;
            Debug.Log("cikti");

        }
        if (other.gameObject.tag == "rail2")
        {
            sC.touch--;
            Debug.Log("cikti");

        }
    }


    public void Cut(Transform cutter)
    {
        if (cutter.transform.position.x < 0)
        {
          
            float y = transform.localScale.y;
            y -= transform.position.x;
            float dist = y + cutter.position.x;
            sC.height -= dist/2;
            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist / 2, transform.position.y, transform.position.z);
                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(-(y - yeni.transform.localScale.y), transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();

            }

        }
        else
        {
            float y = transform.localScale.y;
            y += transform.position.x;
            float dist = y - cutter.position.x;
            sC.height -= dist/2;
            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;

                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(y - yeni.transform.localScale.y, transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();
            }





        }


    }


 


}
