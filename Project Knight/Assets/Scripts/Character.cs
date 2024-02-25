using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
	public float speed { get; set; }

    public virtual void Attack()
	{
		//에니메이션 재생
		//게임매니저의 체력바 깎기
	}

	public virtual void Move(int posX)
	{
		if (speed == 0.0f)
			return;

		float s = posX - transform.position.x;
		if (s < 0f) { s *= -1.0f; }
		float t = s / speed;
		transform.DOMoveX(posX, t);
	}

	public virtual void Die()
	{
		gameObject.SetActive(false);
		//GameObject.Destroy(gameObject);
		//에니메이션 재생
	}
}
