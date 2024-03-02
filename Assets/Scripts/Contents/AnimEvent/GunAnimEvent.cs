using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimEvent : MonoBehaviour
{
    public bool isAnimActive = true;

    public void GunAnimEnd()
    {
        isAnimActive = !isAnimActive;
    }
}
