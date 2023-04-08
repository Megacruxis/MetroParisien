using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    private PlayerController pControler;

    private void Awake()
    {
        pControler = FindAnyObjectByType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = pControler.transform.position;
        newPos.x = 0;
        transform.position = newPos;
    }
}
