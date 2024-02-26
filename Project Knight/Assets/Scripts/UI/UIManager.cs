using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject[] attackPin;

    private const int START_YPOS = -250;
    private const int INTERVAL = 80;

    public void MoveAttackPin(Side side, int attackIndex)
    {
        Vector3 v = attackPin[(int)side].transform.position;
        v.y = START_YPOS + (INTERVAL * attackIndex);
        attackPin[(int)side].transform.position = v;
    }
}
