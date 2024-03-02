using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Knife : SwordController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    void AttackAnim()
    {
        bool click = Input.GetKeyDown(KeyCode.A);

        if (click && animEvent.isAnimActive)
        {

        }
    }
}
