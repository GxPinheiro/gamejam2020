using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator animator;

    public float actionTimer = 4f;
    public bool doingAction = false;
    public bool isHoldingItem = false;
    public bool healDone = false;
    public bool caldroonAction = false;

    private bool canPickUpItem = false;
    private bool canHealPatient = false;
    private bool holdingPotion = false; 
    // private bool actionDone = false;
    private bool potionReady = false;

    private CauldronController cauldronController;

    void Start()
    {
        GameObject theCauldron = GameObject.Find("Cauldron");
        cauldronController = theCauldron.GetComponent<CauldronController>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        potionReady = cauldronController.potionReady;

        if (doingAction) {
            CalculateCountdown();
        }

        if (Input.GetButtonDown("Fire1")) {
            InputFire1Function();
        }

        // if (Input.GetButtonDown("Fire2")) {
        //     InputFire2Function();
        // }

        if (isHoldingItem) {
            animator.SetBool("PurpleThingFlag", true);
            return;
        }
        if (holdingPotion) {
            // gflag holding potion
            return;
        }
        animator.SetBool("PurpleThingFlag", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bandaid_spawner_collider" && !isHoldingItem) {
            Debug.Log("Pode pegar item");
            canPickUpItem = true;
        }

        if (other.tag == "patient_collider" && isHoldingItem) {
            Debug.Log("Pode curar paciente");
            canHealPatient = true;
        }

        if (other.tag == "cauldron_collider" && isHoldingItem) {
            caldroonAction = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bandaid_spawner_collider") {
            Debug.Log("Não pode mais pegar item");
            canPickUpItem = false;
        }

        if (other.tag == "patient_collider") {
            Debug.Log("Saiu do range de cura");
            canHealPatient = false;
        }

        if (other.tag == "cauldron_collider") {
            caldroonAction = false;
        }

    }

    void InputFire1Function()
    {
        if (canHealPatient && isHoldingItem && holdingPotion) {
            Debug.Log("Curou o maluco");
            isHoldingItem = false;
            canHealPatient = false;
            return;
        }

        if (isHoldingItem) {
            Debug.Log("Dropou o item");
            isHoldingItem = false;
            return;
        }

        if (canPickUpItem) {
            Debug.Log("Pegou item");
            isHoldingItem = true;
        }
    }

    void InputFire2Function()
    {
        if (!caldroonAction) {
            // doingAction = true;
        }

        if (caldroonAction) {
            Debug.Log("Dropou o item 2");
            isHoldingItem = false;
        }
    }

    void CalculateCountdown()
    {
        actionTimer -= Time.deltaTime;
        if (actionTimer < 0) {
            // actionDone = true;
            doingAction = false;
            actionTimer = 5f;
        }
    }
}
