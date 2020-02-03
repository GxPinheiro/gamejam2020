using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    public GameObject[] bedList;

    public float cooldown;
    public bool enableBed = false;
    private float nextPatient;
    public int[] availableBeds = new int[3];

    private PlayerController playerController;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        availableBeds[0] = 0;
        availableBeds[1] = 0;
        availableBeds[2] = 0;

        GameObject thePlayer = GameObject.Find("player");
        playerController = thePlayer.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimation();
        nextPatient -= Time.deltaTime;
        if (nextPatient < 0) {
            for (var i = 0; i < 3; i++) {
                if (availableBeds[i] == 0) {
                    Debug.Log("ENTROU");
                    Debug.Log("Colocar animacao da cama");
                    animator.SetBool("PersonInBed", true);
                    availableBeds[i] = 1;
                    enableBed = true;
                    break;
                }
            }
            nextPatient = cooldown;
        }
    }

    void ChangeAnimation() {
        if(playerController.healDone){
            animator.SetBool("Healed", true);
            playerController.healDone = false;
            // animator.SetBool("Dead", false);
            // animator.SetBool("PersonInBed", false);
            // animator.SetBool("Healed", false);
            // animator.SetBool("Cleaning", true);
        }
    }

}
