using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * xMove * Speed * Time.deltaTime;        

    }
}
