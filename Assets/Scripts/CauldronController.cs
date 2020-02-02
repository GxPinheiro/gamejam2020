using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : MonoBehaviour
{
    public float actionTimer = 2f;
    public bool potionReady = false;

    private bool doingAction = false;
    private bool enableAction = false;

    PlayerController playerController;
    public Animator animator;

    void Start()
    {
        GameObject thePlayer = GameObject.Find("player");
        playerController = thePlayer.GetComponent<PlayerController>();

    }

    void Update()
    {
        if (doingAction)
        {
            CalculateCountdown();
        }

        if(playerController.caldroonAction){
            if (Input.GetButtonDown("Fire1") && playerController.isHoldingItem)
            {
                doingAction = true;
                animator.SetBool("Empty", false);
                animator.SetBool("Cooking", true);
                enableAction = false;
                CalculateCountdown();
            }
            if (Input.GetButtonDown("Fire1") && !playerController.isHoldingItem && !doingAction)
            {
                animator.SetBool("Empty", true);
                animator.SetBool("Cooking", false);
                playerController.holdingPotion = true;

            }
        }


        // if (Input.GetButtonDown("Fire2"))  //debug sem && enableAction
        // {
        //     animator.SetBool("Empty", true);
        //     animator.SetBool("Cooking", false);
        // }
    }

    void CalculateCountdown()
    {
        actionTimer -= Time.deltaTime;
        if (actionTimer < 0) {
            doingAction = false;
            actionTimer = 5f;
            potionReady = true;
            animator.SetBool("Empty", false);
            animator.SetBool("Cooking", false);
            Debug.Log("Done");
        }
    }
}
