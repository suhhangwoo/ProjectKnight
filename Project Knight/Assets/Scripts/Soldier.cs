using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Soldier : MonoBehaviour
{
    public string unitName;

    public int Hp { get; set; }
    public int Damage { get; set; }
    public int MoraleDamage { get; set; }
    public float Speed { get; set; }

    private Soldier AttackTarget { get; set; } = null;

    public void Initialize(int hp, int damage, int moraleDamage, float speed)
    {
        this.Hp = hp;
        this.Damage = damage;
        this.MoraleDamage = moraleDamage;
        this.Speed = speed;
    }

    public void SetAttactTarget(Soldier target)
    {
       this.AttackTarget = target;
    }

    public virtual void Attack()
    {
        if(AttackTarget == null) { return; }
        AttackTarget.TakeDamage(Damage); //MoraleDamage 보류
        //에니메이션 재생

    }

    public virtual void Move(int posX)
    {
        if (Speed == 0.0f)
            return;

        float s = posX - transform.position.x;
        if (s < 0f) { s *= -1.0f; }
        float t = s / Speed;
        transform.DOMoveX(posX, t);
    }

    private void Die()
    {
        //에니메이션 재생
        float targetX = 50f;
        if (transform.position.x < 0f)
        { targetX *= -1f; }

        DG.Tweening.Sequence sq = DOTween.Sequence();
        sq.SetAutoKill()
            .Append(transform.DOMove(new Vector3(targetX, 50f), 1f))
            .AppendCallback(SetActiveFalse);
        
        //체력바 깎기 -100
    }
    private void SetActiveFalse()
    { 
        gameObject.SetActive(false); 
    }
    public void TakeDamage(int Damage)
    {
        Hp -= Damage;
        if (Hp <= 0f)
            Die();
    }
}
