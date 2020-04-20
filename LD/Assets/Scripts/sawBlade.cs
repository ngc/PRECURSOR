using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawBlade : MonoBehaviour
{
    public bool Activated = false;
    private bool soundPlayed = false;


    private void Start()
    {
        gameObject.GetComponent<Lava>().enabled = false;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (Activated)
        {
            transform.Rotate(Vector3.back * 300 * Time.deltaTime);
            gameObject.GetComponent<Lava>().bladeActive = true;
            
        }
        else
        {
            soundPlayed = false;
            gameObject.GetComponent<Lava>().bladeActive = false;
        }
        

    }

}
