using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
	[SerializeField]
	private float moveTime;

    public void Attack()
    {
		//���ϸ��̼� ���
		//���ӸŴ����� ü�¹� ���
	}

	public void Move(int posX)
	{
		transform.DOMoveX(posX, moveTime);
	}

	public void Die()
	{
		GameObject.Destroy(gameObject);
		//���ϸ��̼� ���
	}
}
