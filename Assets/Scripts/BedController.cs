using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    public GameObject[] bedList;

    public float cooldown;
    private float nextPatient;
    private int[] availableBeds = new int[3];
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
            // pode spawnar:
            // verificar se existe cama vazia
            // pegar o nome do objeto (_0, _1 ou _2)
            // mudar o sprite da cama
            // setar a cama como ocupada
            // resetar cooldown
            for (var i = 0; i < 3; i++) {
                if (availableBeds[i] == 0) {
                    Debug.Log("ENTROU");
                    Debug.Log("Colocar animacao da cama");
                    availableBeds[i] = 1;
                    break;
                }
            }
            nextPatient = cooldown;
        }
    }
}
