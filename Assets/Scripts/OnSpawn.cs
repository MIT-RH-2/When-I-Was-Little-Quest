using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawn : MonoBehaviour {

    private Camera _waitCam;
    private Transform _environment;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("wait").GetComponent<Camera>() != null) _waitCam = GameObject.FindGameObjectWithTag("wait").GetComponent<Camera>();
        if (GameObject.FindGameObjectWithTag("env").transform != null) _environment = GameObject.FindGameObjectWithTag("env").transform;
        if (_waitCam != null) _waitCam.gameObject.SetActive(false);
        if (_environment != null) this.gameObject.transform.parent = _environment;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
