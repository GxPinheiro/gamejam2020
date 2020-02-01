using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        // mousePosition.x = mousePosition.x - player.position.x;
        // mousePosition.y = mousePosition.y - player.position.y;

        float angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));

        checkForMovement();
        checkForShoot();
    }

    private void checkForShoot() {
        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("TESTE");
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
