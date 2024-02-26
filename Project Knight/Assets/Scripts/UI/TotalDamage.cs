using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TotalDamage : MonoBehaviour
{
    [SerializeField]
    private Side side;
    [SerializeField]
    private float size;
    [SerializeField]
    private float time;
    [SerializeField]
    private GameObject damageTextObj;
    [SerializeField]
    private Text damageText;
    private float curDamage;
    private float timer;
    [SerializeField]
    private float interval;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }

    private void Init()
    {
        curDamage = 0f;
        timer = 0f;
        damageText.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void TakeDamage(GameObject attack, float damage)
    {
        curDamage += damage;
        damageText.text = curDamage.ToString();
        timer = 0f;
        gameObject.SetActive(true);

        transform.DOScale(new Vector3(size, size, 1f), time).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), time).SetEase(Ease.Linear);
        });
        damageTextObj.transform.DOScale(new Vector3(size, size, 1f), time).SetEase(Ease.Linear).OnComplete(() =>
        {
            damageTextObj.transform.DOScale(new Vector3(1f, 1f, 1f), time).SetEase(Ease.Linear);
        });

        UIManager.Instance.ShowDamage(attack, damage);
        GameManager.Instance.UpdateHp(side, curDamage);
    }
}
