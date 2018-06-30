using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(GetComponent<Rigidbody>().gameObject.name);
        var rigid = GetComponent<Rigidbody>();

        Debug.Log(collision.collider.transform.position);
        if (collision.gameObject.name == "Rico")
            rigid.AddForce((rigid.position - collision.collider.transform.position) * 15f, ForceMode.Impulse);
    }
}
