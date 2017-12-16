using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ToFollow;
    private Rigidbody2D _targetRigid;
    public float yOffset = -2;

    GameManager _manager;

    // Use this for initialization
    void Start()
    {
        _targetRigid = ToFollow.GetComponent<Rigidbody2D>();
        _manager = Hub.Get<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_manager.GameStarted)
        {
            var position = new Vector3(transform.position.x, ToFollow.transform.position.y + yOffset, transform.position.z);
            transform.position = position;
        }
    }
}
