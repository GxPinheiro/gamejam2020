using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    public GameObject[] bedList;

    public float cooldown;
    private float nextPatient;
    private int[] availableBeds = new int[3];

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        availableBeds[0] = 0;
        availableBeds[1] = 0;
        availableBeds[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nextPatient -= Time.deltaTime;
        if (nextPatient < 0) {
            for (var i = 0; i < 3; i++) {
                if (availableBeds[i] == 0) {
                    Debug.Log("ENTROU");
                    Debug.Log("Colocar animacao da cama");
                    animator.SetBool("PersonInBed", true);
                    availableBeds[i] = 1;
                    break;
                }
            }
            nextPatient = cooldown;
        }
    }
}
