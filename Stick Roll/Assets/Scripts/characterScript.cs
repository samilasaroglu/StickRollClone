using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class characterScript : MonoBehaviour
{
    [SerializeField] private movementScript movScript;
    [SerializeField] private stickCollecter sC;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bonus")
        {
            movScript.speed = 0;
            sC.animator.SetBool("hang", false);
            sC.isGround = true;
            sC.animator.SetBool("dance", true);
            transform.DOScale(new Vector3(150, 150, 150), 8);
            sC.gameFinish();
            sC.stick.GetComponent<movementScript>().speed = 0;
            winPanel.SetActive(true);
        }

        if (other.gameObject.tag == "ground")
        {
            sC.isGround = true;
            sC.touch = 0;
        }
        if (other.gameObject.tag == "gameArea")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }
   
}
