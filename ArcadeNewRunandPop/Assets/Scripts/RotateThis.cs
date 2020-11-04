using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    public float rotSpeed = 500f;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotSpeed) * Time.deltaTime);
    }
}
