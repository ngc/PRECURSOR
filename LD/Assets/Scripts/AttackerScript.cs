using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject MGMT;
    private float rotationZ;
    public float movementSpeed = 3f;
    void Start()
    {
        MGMT = GameObject.Find("GameMGMT");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.transform.position - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MGMT.SendMessage("died");
        }
    }

}
