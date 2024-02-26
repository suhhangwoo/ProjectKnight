using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private const int START_YPOS = -250;
    private const int INTERVAL = 80;

    [SerializeField]
    private GameObject[] attackPin;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject damageTextPrefab;

    public void MoveAttackPin(Side side, int attackIndex)
    {
        Vector3 v = attackPin[(int)side].transform.position;
        v.y = START_YPOS + (INTERVAL * attackIndex);
        attackPin[(int)side].transform.position = v;
    }

    [SerializeField]
    private float damageInterval;
    [SerializeField]
    private float damageStartY;
    [SerializeField]
    private float damageShowTime;

    public void ShowDamage(GameObject target, float damage)
    {
        GameObject obj = Instantiate(damageTextPrefab, canvas.transform);
        Text text = obj.GetComponent<Text>();
        text.text = damage.ToString();
        Vector3 v = target.transform.position;
        v.y = v.y + damageStartY;
        obj.transform.position = v;
        obj.transform.DOMoveY(obj.transform.position.y + damageInterval, damageShowTime).SetEase(Ease.Linear);
        text.DOFade(0f, damageShowTime).SetEase(Ease.Linear).OnComplete(() => { Destroy(obj); });
    }
}
