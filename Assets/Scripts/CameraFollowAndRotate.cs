using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAndRotate : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 cameraOffset;

    [SerializeField]
    private Space cameraOffsetSpace = Space.Self;

    private bool lookAt = true;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset.Set(0, 1, -3);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraOffsetSpace == Space.Self)
        {
            transform.position = target.TransformPoint(cameraOffset);
        }
        else
        {
            transform.position = target.position + cameraOffset;
        }

        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

}
