using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
