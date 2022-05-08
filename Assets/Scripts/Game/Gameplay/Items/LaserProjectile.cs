using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MFlight.Demo;

public class LaserProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.transform.root.CompareTag("Player")) other.transform.root.GetComponentInChildren<MFlight.Demo.Plane>().StopPlane(3);
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
