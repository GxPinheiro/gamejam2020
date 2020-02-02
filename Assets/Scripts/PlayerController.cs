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

    private bool canPickUpItem = false;
    private bool canHealPatient = false;
    private bool actionDone = false;
    private bool caldroonAction = false;
    // Start is called before the first frame update

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doingAction) {
            CalculateCountdown();
        }

        if (Input.GetButtonDown("Fire1")) {
            InputFire1Function();
        }

        if (Input.GetButtonDown("Fire2")) {
            InputFire2Function();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Holding" + isHoldingItem);
            Debug.Log("pickup" + canPickUpItem);
            Debug.Log("heal" + canHealPatient);
        }

        if (isHoldingItem) {
            animator.SetBool("PurpleThingFlag", true);
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
            Debug.Log("Pode usar calderao");
            caldroonAction = true;
        }

        if (other.tag == "bandaid_collision") {
            Debug.Log("Bateu no bandaid");
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
    }

    void InputFire1Function()
    {
        if (canHealPatient && isHoldingItem) {
            Debug.Log("Curou o maluco");
            Debug.Log("Voltar o sprite que não está segurando o item");
            isHoldingItem = false;
            canHealPatient = false;
            return;
        }

        if (isHoldingItem) {
            Debug.Log("Dropou o item");
            Debug.Log("Voltar sprite que nao esta segurando o item e deixa o item no chao");
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
            doingAction = true;
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
            actionDone = true;
            doingAction = false;
            actionTimer = 5f;
        }

        Debug.Log(actionTimer);
        Debug.Log(doingAction);
    }
}
