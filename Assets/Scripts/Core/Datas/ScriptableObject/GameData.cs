using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/GameData", order = int.MinValue)]
public class GameData : BaseData
{
    public int hp;
    public int mp;
    public int gold;

    public int HP { get { return hp; } }
    public int MP { get { return mp; } }
    public int GOLD { get { return gold; } }
}
