using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ToFollow;
    private Rigidbody2D _targetRigid;
    public float yOffset = -2;
    public float SpeedVariety = 2;

    GameManager _manager;
    PlayerMovement2 _playerMovement;

    // Use this for initialization
    void Start()
    {
        _targetRigid = ToFollow.GetComponent<Rigidbody2D>();
        _manager = Hub.Get<GameManager>();
        _playerMovement = Hub.Get<PlayerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_manager.GameStarted)
        {
            var effectiveOffset = yOffset;
            effectiveOffset -= (-_playerMovement.CurrentVerticalSpeed - _playerMovement.vSpeedDefault) / _playerMovement.vDownSpeedMax * SpeedVariety;
            var position = new Vector3(transform.position.x, ToFollow.transform.position.y + effectiveOffset, transform.position.z);
            transform.position = position;
        }
    }
}
