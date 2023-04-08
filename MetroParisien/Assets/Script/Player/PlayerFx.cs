using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    PlayerController pControler;
    internal void Initialize()
    {
        pControler = GetComponent<PlayerController>();
    }
}
