using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierFrame : MonoBehaviour
{
    [SerializeField]
    private Image hpBar;
    private float maxHp;
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private Text unitName;
    [SerializeField]
    private Text unitNumber;

    public void Init(float hp, Sprite port, string unit)
    {
        maxHp = hp;
        portrait.sprite = port;
        unitName.text = unit;
        unitNumber.text = maxHp.ToString();
        hpBar.fillAmount = 1f;
    }

    public void UpdateHpBar(float totalDamage)
    {
        float curHp = Mathf.Max(maxHp - totalDamage, 0f);
        hpBar.fillAmount = curHp / maxHp;
    }
}
