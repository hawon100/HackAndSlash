using UnityEngine;

public class SwordAnimEvent : MonoBehaviour
{
    public bool isAnimActive = true;

    public void SwordAnimEnd()
    {
        isAnimActive = !isAnimActive;
    }
}