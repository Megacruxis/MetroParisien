using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
    }
}
