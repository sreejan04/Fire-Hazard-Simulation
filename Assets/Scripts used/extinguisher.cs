using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extinguisher : MonoBehaviour
{
    public GameObject nozle;
    // Start is called before the first frame update
    [SerializeField] private float amountExtinguishedPerSecond = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(nozle.transform.position, nozle.transform.forward, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out fire fire))
            fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            
    }
}
