using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class gamecontroller : MonoBehaviour
{
    fire obj;
    public GameObject startpanel;
    public Button continuebut;
    public GameObject controlpanel;
    public Button startbutt;
    public GameObject alarmpanel;
    public Button trigger;
    public Material indi;
    public GameObject wildfireing;
    public AudioSource alarmsound;
    public GameObject maincamera;
    public GameObject wheel;
    public GameObject endscreen;
    public GameObject passscreen;
    public int A = 1;
    public float delay = 2;
    float delay2 = 5;
    float timer;
    float timer2;
    float timer3;
    int b = 1;
    int pass = 0;
    // Start is called before the first frame update
    void Start()
    {
        obj= GameObject.Find("WildFire").GetComponent<fire>(); 
        passscreen.SetActive(false);
        controlpanel.SetActive(false);
        alarmpanel.SetActive(false);
        wildfireing.SetActive(false);
        alarmsound.enabled = false;
        maincamera.transform.position = new Vector3(-1.27409196f, -0.274999976f, 3.68000007f);
        indi.color = Color.red;
        endscreen.SetActive(false);
    }
    void onstrat()
    {
        wildfireing.SetActive(true);
        startpanel.SetActive(false);
        controlpanel.SetActive(true);

    }
    void oncontrol()
    {
        controlpanel.SetActive(false);
        alarmpanel.SetActive(true);
        maincamera.transform.position = new Vector3(3.66000009f, -0.274999976f, 1.30999994f);
        timer2 = 0;
    }
    void onalrm()
    {
        alarmpanel.SetActive(false);
        alarmsound.enabled = true;
        maincamera.transform.position = new Vector3(2.1500001f, -0.274999976f, 1.08099997f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(obj.currentIntensity);
        if(obj.currentIntensity<=0) 
        {
            pass = 1;
            timer3 += Time.deltaTime;
        }
        if(timer3>delay2&&b==1)
        {
            passscreen.SetActive(true);
            maincamera.transform.position = new Vector3(-1.27409196f, -0.274999976f, 3.68000007f);
            b = 0;
        }
        timer2 += Time.deltaTime;
        if(timer2 > 60&&b==1&&pass==0&&b==1)
        {
            endscreen.SetActive(true);
            maincamera.transform.position = new Vector3(-1.27409196f, -0.274999976f, 3.68000007f);
            b = 0;
        }
        continuebut.onClick.AddListener(onstrat);
        startbutt.onClick.AddListener(oncontrol);
        trigger.onClick.AddListener(onalrm);
        if(wheel.transform.rotation== new Quaternion(0, 0, -1, 1.74732833e-07f)&&A==1)
        {
            indi.color = Color.green;
            timer += Time.deltaTime;
        }
        if(timer>delay&&A==1)
        {
            maincamera.transform.position = new Vector3(-0.990999997f, -0.274999976f, 1.08099997f);
            A = 0;
        }
    }
}
