using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest Data",menuName ="Scriptable Object/Quest Data")]
public class QuestData : ScriptableObject
{
    public string questGroupID;
    public string questID;
    public string title;
    public string description;
    public Sprite questIcon;
    public RewardType rewardType = RewardType.Unknown;
    public int rewardAmount = 100;
    public QuestType questType = QuestType.Unknown;
    public int requestAmount = 100;

}
public enum RewardType{
    Unknown,
    Gold,
    Gem,
    Exp,
    Item
}
public enum QuestType{
    Unknown,
    CollectGold,
    UpgradeItem,
}
