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
    public bool isHorizontal = true;
    public float speed = 1f;
    private Vector3 startPoint;
    public Vector3 endPoint;
    private Vector3 temp;
    private float lengthofTravel = 0f;
    private float fractionOfJourney;
    private float distCovered;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {

        if (timeatActivation - Time.time <= 0f && timeatActivation - Time.time > -6f)
        {
            distCovered = (Time.time - startTime) * 150f * speed;
            fractionOfJourney = distCovered / lengthofTravel;
            transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);
            startTime2 = Time.time;
        }else if(timeatActivation - Time.time <= -6f && timeatActivation - Time.time > -9f)
        {
            distCovered = (Time.time - startTime2) * 150f * speed;
            Mathf.Clamp(distCovered, 0, Mathf.Infinity);
            lengthofTravel = Vector3.Distance(endPoint, startPoint);
            fractionOfJourney = distCovered / lengthofTravel;
            transform.position = Vector3.Lerp(endPoint, startPoint, fractionOfJourney);
        }else if(timeatActivation - Time.time <= -9f)
        {
            timeatActivation = Time.time + originalTA;
        }
        }

    

    private void FixedUpdate()
    {
        if(timeatActivation - Time.time <= 3 && timeatActivation - Time.time > 0)
        {
            castView.SetActive(true);
            startTime = Time.time;
        }
        else
        {
            castView.SetActive(false);
        }
    }

}
