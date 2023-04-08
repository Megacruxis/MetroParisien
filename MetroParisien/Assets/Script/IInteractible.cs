using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible 
{
    public bool isActive { get; set; }

    public void Activate();

    public void Disable();
}
