using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [HideInInspector]
    public GameObject followingObject;

    private Vector3 offset;

    private void Awake()
    {
        followingObject = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        offset = followingObject.transform.position - transform.position;
    }

    private void Update()
    {
        this.transform.position = followingObject.transform.position - offset;
    }
}
