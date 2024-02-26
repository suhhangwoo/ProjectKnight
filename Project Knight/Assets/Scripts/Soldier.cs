using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public string unitName;
    public float Speed { get; set; }

    public virtual void Attack()
    {
        //���ϸ��̼� ���
        //���ӸŴ����� ü�¹� ���
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

    public virtual void Die()
    {
        gameObject.SetActive(false);
        //GameObject.Destroy(gameObject);
        //���ϸ��̼� ���
    }
}
