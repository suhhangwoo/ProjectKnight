using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField]
	private GameObject origin; //원본객체
	[SerializeField]
	private int beforeCreateCnt; //사전 생성 개수

	private List<GameObject> listPool;

	public void Init()
	{
		listPool = new List<GameObject>();

		for (int i = 0; i < beforeCreateCnt; i++)
		{
			GameObject newGameObject = Instantiate(origin, gameObject.transform);
			newGameObject.SetActive(false);
			listPool.Add(newGameObject);
		}
	}

	public GameObject GetFromPool()
	{
		for (int i = 0; i < listPool.Count; i++)
		{
			if (!listPool[i].gameObject.activeInHierarchy)
			{
				return listPool[i];
			}
		}
		GameObject newGameObject = Instantiate(origin, gameObject.transform);
		listPool.Add(newGameObject);
		return newGameObject;
	}

	public bool GetFromPool(out GameObject get)
	{
		for (int i = 0; i < listPool.Count; i++)
		{
			if (!listPool[i].gameObject.activeInHierarchy)
			{
				get = listPool[i];
				return false;
			}
		}
		GameObject newGameObject = Instantiate(origin, gameObject.transform);
		listPool.Add(newGameObject);
		get = newGameObject;
		return true;
	}

	private void Start()
	{
		Init();
	}
}

