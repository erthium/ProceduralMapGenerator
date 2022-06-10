using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 target_position;
    Quaternion target_rotation;

    public float smoothness = 10f;
    public float target_speed = 0.1f;

    float horizontal_axis;
    float vertical_axis;

    void Start()
    {
        target_position = transform.position;
        target_rotation = transform.rotation;
    }

    void FixedUpdate()
    {
        horizontal_axis = Input.GetAxisRaw("Horizontal"); // 1: right -- 2: left
        vertical_axis = Input.GetAxisRaw("Vertical"); // 1: up -- 2: down
        target_position += new Vector3(horizontal_axis * target_speed, 0, vertical_axis * target_speed);
        Vector3 smoothed_position = Vector3.Lerp(transform.position, target_position, smoothness * Time.fixedDeltaTime);
        transform.position = smoothed_position;

    }
}
