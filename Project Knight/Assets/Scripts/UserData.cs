using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitData
{
    public string commanderName;
    public string unitName;
    public int unitNumber;
}

public class UserData : Singleton<UserData>
{
    private int MAX_UNIT = 4;

    public UnitData[] unitData;

    private void Start()
    {
        unitData = new UnitData[MAX_UNIT];
    }
}
