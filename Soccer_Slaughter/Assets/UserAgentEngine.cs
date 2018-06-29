using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAgentEngine : MonoBehaviour {

    public Transform _target;
    public float _speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(_target);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}
}
