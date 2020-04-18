using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 BeginPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        BeginPos.Set(0f, -4f, 0);
        transform.position = BeginPos;
    }

    void OnLevelWasLoaded()
    {
        transform.position = BeginPos;
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
