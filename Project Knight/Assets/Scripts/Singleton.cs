using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	// 인스턴스에 접근하는 프로퍼티
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();

				if (instance == null)
				{
					GameObject obj = new GameObject();
					obj.name = typeof(T).Name;
					instance = obj.AddComponent<T>();
				}
			}

			return instance;
		}
	}

	protected virtual void Awake()
	{
		if (instance == null)
		{
			instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
