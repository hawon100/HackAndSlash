using UnityEngine;

public class GunController : MonoBehaviour
{
    public float curShotDelay;
    public float maxShotDelay;

    public Transform firePos;
    public Animator gunAnim;
    public GunAnimEvent gunAnimEvent;

    protected virtual void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void Update()
    {
        Attack();
    }

    void Attack()
    {
        bool click = Input.GetMouseButtonDown(0);

        if (click && gunAnimEvent.isAnimActive == true)
        {
            gunAnim.SetTrigger("Fire");
        }
    }
}