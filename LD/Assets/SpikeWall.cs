using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    private float originalTA;
    public float timeatActivation = 6f;
    private float startTime = 0f;
    private float startTime2;
    public GameObject castView;
    public GameObject MGMT;
    public bool isHorizontal = true;
    public float speed = 1f;
    private Vector3 startPoint;
    public Vector3 endPoint;
    private Vector3 temp;
    private float lengthofTravel = 0f;
    private float fractionOfJourney;
    private float distCovered;
    private float timeOffset;

    void Start()
    {
        timeOffset = Time.timeSinceLevelLoad;
        MGMT = GameObject.Find("GameMGMT");
        originalTA = timeatActivation;
        castView = transform.GetChild(1).gameObject;
        startPoint = transform.position;
        if (isHorizontal)
        {
            endPoint.y = startPoint.y;
        }
        else
        {
            endPoint.x = startPoint.x;
        }
        lengthofTravel = Vector3.Distance(startPoint, endPoint);
    }

    void Update()
    {

        if (timeatActivation - Time.timeSinceLevelLoad <= 0f && timeatActivation - Time.timeSinceLevelLoad > -6f)
        {
            distCovered = (Time.timeSinceLevelLoad - startTime) * 150f * speed;
            fractionOfJourney = distCovered / lengthofTravel;
            transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);
            startTime2 = Time.timeSinceLevelLoad;
        }else if(timeatActivation - Time.timeSinceLevelLoad <= -6f && timeatActivation - Time.timeSinceLevelLoad > -9f)
        {
            distCovered = (Time.timeSinceLevelLoad - startTime2) * 150f * speed;
            Mathf.Clamp(distCovered, 0, Mathf.Infinity);
            lengthofTravel = Vector3.Distance(endPoint, startPoint);
            fractionOfJourney = distCovered / lengthofTravel;
            transform.position = Vector3.Lerp(endPoint, startPoint, fractionOfJourney);
        }else if(timeatActivation - Time.timeSinceLevelLoad <= -9f)
        {
            timeatActivation = Time.timeSinceLevelLoad + originalTA;
        }
    }

   
    private void FixedUpdate()
    {
        if(timeatActivation - Time.timeSinceLevelLoad <= 3 && timeatActivation - Time.timeSinceLevelLoad > 0)
        {
            castView.SetActive(true);
            startTime = Time.timeSinceLevelLoad;
        }
        else
        {
            castView.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MGMT.transform.SendMessage("died");
        }
    }

}
