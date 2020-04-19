using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    private float originalTA;
    public float timeatActivation = 4f;
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
    public AudioSource speaker;
    public AudioSource cast;
    public bool randomMode = false;

    private bool soundPlayed = false;
    private bool soundPlayed2 = false;
    private bool castPlayed = false;

    void Start()
    {
        if (randomMode)
        {
            timeatActivation = Random.Range(0f, 10f);
        }
        speaker = gameObject.GetComponent<AudioSource>();
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
            if (!soundPlayed)
            {
                speaker.Play();
                soundPlayed = true;
            }
        }else if(timeatActivation - Time.timeSinceLevelLoad <= -6f && timeatActivation - Time.timeSinceLevelLoad > -9f)
        {
            if (!soundPlayed2)
            {
                speaker.Play();
                soundPlayed2 = true;
            }
            distCovered = (Time.timeSinceLevelLoad - startTime2) * 150f * speed;
            Mathf.Clamp(distCovered, 0, Mathf.Infinity);
            lengthofTravel = Vector3.Distance(endPoint, startPoint);
            fractionOfJourney = distCovered / lengthofTravel;
            transform.position = Vector3.Lerp(endPoint, startPoint, fractionOfJourney);
        }else if(timeatActivation - Time.timeSinceLevelLoad <= -9f)
        {
            if (randomMode)
            {
                originalTA = Random.Range(0f, 10f);
            }
            timeatActivation = Time.timeSinceLevelLoad + originalTA;
            soundPlayed = false;
            soundPlayed2 = false;
        }
    }

   
    private void FixedUpdate()
    {
        if(timeatActivation - Time.timeSinceLevelLoad <= 5 && timeatActivation - Time.timeSinceLevelLoad > 0)
        {
            castView.SetActive(true);
            if(castPlayed == false)
            {
                Camera.main.gameObject.GetComponent<AudioSource>().Play();
                castPlayed = true;
            }
            startTime = Time.timeSinceLevelLoad;
        }
        else
        {
            castView.SetActive(false);
            castPlayed = false;
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
