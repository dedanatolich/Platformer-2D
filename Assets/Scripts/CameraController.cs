using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, -10);
    }
}
