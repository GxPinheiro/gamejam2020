using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public int speed;
    private bool isHoldingItem = false;
    private bool canPickUpItem = false;
    private bool canHealPatient = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForMovement();

        if (isHoldingItem == true && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Dropou o item");
            isHoldingItem = false;
        }

        if (canPickUpItem && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Pegou item");
            isHoldingItem = true;
        }

        if (canHealPatient && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Curou o maluco");
            isHoldingItem = false;
            canHealPatient = false;
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

    private void checkForMovement() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
