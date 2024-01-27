using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    [SerializeField, Range(0f, 1f)] public float currentIntensity = 1.0f;
    private float[] startIntensities = new float[0];
    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f; 
    [SerializeField] private ParticleSystem[] fireParticleSystem = new ParticleSystem[0];
    private bool isLit = true;
    // Start is called before the first frame update
    private void Start()
    {
        startIntensities = new float[fireParticleSystem.Length];

        for (int i = 0; i < fireParticleSystem.Length; i++)
        {
            startIntensities[i] = fireParticleSystem[i].emission.rateOverTime.constant;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(isLit && currentIntensity <1.0f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            changeIntensity();
        }
    }
    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;
        currentIntensity -= amount;
        changeIntensity();
        if(currentIntensity <=0)
        {
            isLit = false;
            return false;
        }
        return false; //fire is lit
    }
    private void changeIntensity()
    {
        for (int i = 0; i < fireParticleSystem.Length; i++)
        {
            var emission = fireParticleSystem[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
