using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Animator swordAnim;
    protected SwordAnimEvent animEvent;
    protected BoxCollider swordblade;

    protected virtual void Start()
    {
        swordAnim = GetComponent<Animator>();
        animEvent = GetComponent<SwordAnimEvent>();
        swordblade = GetComponent<BoxCollider>();
    }

    protected virtual void Update()
    {
        AttackAnim();
    }

    void AttackAnim()
    {
        bool click = Input.GetKeyDown(KeyCode.A);

        swordblade.enabled = !animEvent.isAnimActive;

        if (click && animEvent.isAnimActive)
        {
            swordAnim.SetTrigger("doAttack");
        }
    }
}
