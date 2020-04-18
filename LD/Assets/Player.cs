using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
       Vector3 point = transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = -1;
        transform.position = point;

    }



}
