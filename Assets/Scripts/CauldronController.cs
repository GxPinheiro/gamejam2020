using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : MonoBehaviour
{
    public float actionTimer = 2f;

    private bool doingAction = false;
    private bool enableAction = false;
    private bool potionReady = false;

    PlayerController playerController;
    public Animator animator;

    void Start() {
        GameObject thePlayer = GameObject.Find("player");
        playerController = thePlayer.GetComponent<PlayerController>();

    }
    void Update()
    {
        enableAction = playerController.isHoldingItem;


        if (doingAction)
        {
            CalculateCountdown();
        }

        if (Input.GetButtonDown("Fire2") && enableAction)
        {
            doingAction = true;
            animator.SetBool("Empty", false);
            animator.SetBool("Cooking", true);
            enableAction = false;
            CalculateCountdown();
        }

        if (Input.GetButtonDown("Fire1"))  //debug sem && enableAction
        {
            animator.SetBool("Empty", true);
            animator.SetBool("Cooking", false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Debug.Log("Pode ativar funcao");
            enableAction  = true;
            return;
        }

        enableAction  = false;
    } 


    void CalculateCountdown(){
        actionTimer -= Time.deltaTime;
        if(actionTimer < 0){
            doingAction = false;
            actionTimer = 5f;
            potionReady = true;
            animator.SetBool("Empty", false);
            animator.SetBool("Cooking", false);
            Debug.Log("Done");
        }
    }
}
