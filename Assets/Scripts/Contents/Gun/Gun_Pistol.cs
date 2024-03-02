using UnityEngine;

public class Gun_Pistol : GunController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Attack();
    }

    void Attack()
    {
        bool click = Input.GetMouseButtonDown(0);

        if (click && gunAnimEvent.isAnimActive == true)
        {
            var projectile = Managers.Resource.Instantiate("Projectile/Bullet");
            projectile.transform.position = firePos.position;
            projectile.transform.rotation = firePos.rotation;
        }
    }
}