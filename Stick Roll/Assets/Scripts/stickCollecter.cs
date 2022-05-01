using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stickCollecter : MonoBehaviour
{
    public GameObject stick;
    [SerializeField] private GameObject Ground;
    [SerializeField] private GameObject diamondEfect;
    public GameObject character;
    public float height;
    public bool isVerticalStick;
    public bool isGround;
    public int touch;
    public Animator animator;
    float y;

    private void Start()
    {
        animator = character.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

            transform.position = stick.transform.position;
            transform.localScale = stick.transform.localScale;
            transform.rotation = stick.transform.rotation;
        

        if (isGround)
        {
            character.GetComponent<Rigidbody>().useGravity = false;
            character.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            stick.GetComponent<Rigidbody>().useGravity = false;
            stick.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            animator.SetBool("hang", false);

        }
        else
        {
            if (touch != 2)
            {
                character.GetComponent<Rigidbody>().useGravity = true;
                character.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                stick.GetComponent<Rigidbody>().useGravity = true;
                stick.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
          else if (touch == 2)
            {
                character.GetComponent<Rigidbody>().useGravity = false;
                character.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                stick.GetComponent<Rigidbody>().useGravity = false;
                stick.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (isGround)
            {
                stick.transform.rotation = Quaternion.Euler(0, 0, 0);
                y = stick.transform.position.y;
            }
         
        }
        if (Input.GetMouseButton(0))
        {
            if (isGround)
            {
                isVerticalStick = true;
                stick.transform.position = new Vector3(0, y + height, stick.transform.position.z);
                character.transform.DOMoveY(stick.transform.position.y + stick.transform.localScale.y - 1, 1);
                // character.transform.position = new Vector3(character.transform.position.x, stick.transform.position.y + stick.transform.localScale.y - 1, character.transform.position.z);
                animator.SetBool("climb", true);

            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isGround)
            {
                isVerticalStick = false;
                stick.transform.rotation = Quaternion.Euler(0, 0, 90);
                stick.transform.position = new Vector3(0, y , stick.transform.position.z);
                character.transform.DOMoveY(stick.transform.position.y - 0.5f, 1);
                // character.transform.position = new Vector3(character.transform.position.x, 3.5f, character.transform.position.z);
                animator.SetBool("climb", false);


            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectableStick")
        {
            height += 0.5f;
          //  stick.transform.DOScaleY(stick.transform.localScale.y+0.5f,1);
            stick.transform.localScale += new Vector3(0, 0.5f, 0);

            Destroy(other.gameObject) ;
        }
     /*   if (other.gameObject.tag == "ground")
        {
            touch = 0;
            isGround = true;
        } */

        if (other.gameObject.tag == "rail")
        {
            isGround = false;
            touch = 0;
            animator.SetBool("hang", true);
        }
        if (other.gameObject.tag == "turner")
        {
            Ground.transform.DORotate(new Vector3(0, 90, 0), 1);
        }
        if (other.gameObject.tag == "diamond")
        {
            other.gameObject.transform.DOScale(new Vector3(0, 0, 0), .5f);
            Destroy(other.gameObject, 3);
            Instantiate(diamondEfect, other.transform.position, Quaternion.identity);
        }
     
    }
    public void gameFinish()
    {

    }
}
