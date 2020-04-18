using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMGMT : MonoBehaviour
{
    public Text lifeDisplay;
    public GameObject MGMT;
    public float totallife = 10f;
    public float notch = 8f;
    public float lifeSpeed = 1f; 
    public AudioSource speaker;
    public AudioSource GrantSpeaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totallife -= lifeSpeed * Time.deltaTime;
        if(totallife <= 0)
        {
            MGMT.transform.SendMessage("died");
        }else if(totallife <= notch)
        {
                speaker.Play();
                notch -= 1 - (0.1f * (10 - totallife));
            
        }
    }

    void GrantLife(float pickup)
    {
        GrantSpeaker.Play();
        notch += pickup;
        totallife += pickup;
    }

    private void FixedUpdate()
    {
        
        lifeDisplay.text = "LIFE:" + totallife.ToString().Substring(0, 4);
    }

}
