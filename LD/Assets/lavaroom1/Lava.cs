using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject MGMT;
    // Start is called before the first frame update
    public float speed = 1f;
    public bool closeDirUpLeft = true;
    public bool vert = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vert)
        {
            if (closeDirUpLeft)
            {
                transform.Translate(Vector3.up * 0.07f * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * 0.07f * speed * Time.deltaTime);
            }
        }
        else
        {
            if (closeDirUpLeft) {
                transform.Translate(Vector3.left * 0.07f * speed * Time.deltaTime) ;
        }
            else
        {
            transform.Translate(Vector3.right * 0.07f * speed * Time.deltaTime);
        }

    }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MGMT.transform.SendMessage("died");
    }

}
