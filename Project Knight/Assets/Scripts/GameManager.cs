using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Right };

public class GameManager : Singleton<GameManager>
{
    private const int RIGHT_START_INDEX = 4;

    [SerializeField]
    private int[,] soldierNumber;
    [SerializeField]
    private int[] attackIndex;
    [SerializeField]
    private GameObject[] soldierFrameObjArr;
    private List<SoldierFrame> leftSoldierFrameList;
    private List<SoldierFrame> rightSoldierFrameList;

    [SerializeField]
    private Sprite sprite;

    private void Start()
    {
        soldierNumber = new int[4, 2];
        attackIndex = new int[2];
        leftSoldierFrameList = new List<SoldierFrame>();
        rightSoldierFrameList = new List<SoldierFrame>();

        for (int i = 0; i < soldierFrameObjArr.Length; i++)
        {
            if (i < RIGHT_START_INDEX)
                leftSoldierFrameList.Add(soldierFrameObjArr[i].GetComponent<SoldierFrame>());
            else
                rightSoldierFrameList.Add(soldierFrameObjArr[i].GetComponent<SoldierFrame>());
        }
        for (int i = 0; i < leftSoldierFrameList.Count; i++)
        {
            leftSoldierFrameList[i].Init(soldierNumber[i, (int)Side.Left], sprite, "창병");
        }
        for (int i = 0; i < rightSoldierFrameList.Count; i++)
        {
            rightSoldierFrameList[i].Init(soldierNumber[i, (int)Side.Right], sprite, "창병");
        }
    }

    private void Update()
    {
        
    }

    public void UpdateHp(Side side, float totalDamage)
    {
        if (side == Side.Left)
        {
            rightSoldierFrameList[attackIndex[(int)Side.Right]].UpdateHpBar(totalDamage);
        }
        else
        {
            leftSoldierFrameList[attackIndex[(int)Side.Left]].UpdateHpBar(totalDamage);
        }
    }
}
