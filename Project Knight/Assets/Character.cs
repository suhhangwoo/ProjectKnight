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
		//에니메이션 재생
		//게임매니저의 체력바 깎기
	}

	public void Move(int posX)
	{
		transform.DOMoveX(posX, moveTime);
	}

	public void Die()
	{
		GameObject.Destroy(gameObject);
		//에니메이션 재생
	}
}
