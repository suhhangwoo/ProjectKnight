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

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        curDamage = 0f;
        damageText.text = string.Empty;
    }

    public void TakeDamage(float damage)
    {
        curDamage += damage;
        damageText.text = curDamage.ToString();

        Sequence sequence = DOTween.Sequence();

        Tweener t1 = transform.DOScale(new Vector3(size, size, 1f), time).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), time).SetEase(Ease.Linear);
        });
        Tweener t2 = damageTextObj.transform.DOScale(new Vector3(size, size, 1f), time).SetEase(Ease.Linear).OnComplete(() =>
        {
            damageTextObj.transform.DOScale(new Vector3(1f, 1f, 1f), time).SetEase(Ease.Linear);
        });

        sequence.Join(t1);
        sequence.Join(t2);

        GameManager.Instance.UpdateHp(side, curDamage);
    }
}
