using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAgentEngine : MonoBehaviour {

    public Transform _target;
    public float smoothTime = 10.0F;
    public float _speed;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(_target);
        Debug.Log(Vector3.Distance(_target.position, transform.position));
            //transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref velocity, smoothTime);
    }

}
