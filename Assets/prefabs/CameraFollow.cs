using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 主角 Transform
    public Vector3 offset = new Vector3(0, 5, -10);  // 距离偏移

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}