using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMan : Soldier
{
    private Animator anim = null;

    public override void Initialize(int hp, int damage, int moraleDamage, float speed)
    {
        base.Initialize(hp, damage, moraleDamage, speed);
        anim = GetComponent<Animator>();
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Move(int posX)
    {
        base.Move(posX);
    }

    public override void Die()
    {
        base.Die();
        anim.SetTrigger("Death");
    }

    private void Start()
    {
        Initialize(5, 5, 5, 5);
    }
}
