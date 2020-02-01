using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float actionTimer = 4f;
    public bool doingAction = false;

    private bool isHoldingItem = false;
    private bool canPickUpItem = false;
    private bool canHealPatient = false;
    private bool actionDone = false;
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
            InputFunction();
        }

        if (Input.GetButtonDown("Fire2")) {
            doingAction = true;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Holding" + isHoldingItem);
            Debug.Log("pickup" + canPickUpItem);
            Debug.Log("heal" + canHealPatient);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "bandaid_collider" && !isHoldingItem) {
            Debug.Log("Pode pegar item");
            canPickUpItem = true;
        }

        if (other.tag == "patient_collider" && isHoldingItem) {
            Debug.Log("Pode curar paciente");
            canHealPatient = true;
        }

        // if (other.tag == "patient_collider" && !canHealPatient) {
        //     Debug.Log("Não pode curar paciente");
        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bandaid_collider") {
            Debug.Log("Não pode mais pegar item");
            canPickUpItem = false;
        }

        if (other.tag == "patient_collider") {
            Debug.Log("Saiu do range de cura");
            canHealPatient = false;
        }
    }   

    void InputFunction(){
        if (isHoldingItem) {
            Debug.Log("Dropou o item");
            isHoldingItem = false;
        }

        if (canPickUpItem) {
            Debug.Log("Pegou item");
            isHoldingItem = true;
        }

        if (canHealPatient) {
            Debug.Log("Curou o maluco");
            isHoldingItem = false;
            canHealPatient = false;
        }
    }

    void CalculateCountdown(){
        actionTimer -= Time.deltaTime;
        if(actionTimer < 0){
            actionDone = true;
            doingAction = false;
            actionTimer = 5f;
        }
        Debug.Log(actionTimer);
        Debug.Log(doingAction);
    }
}
