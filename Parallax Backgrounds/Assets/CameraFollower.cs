using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject _toFollow;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = _toFollow.transform.position.x;
        transform.position = position;
    }
}
