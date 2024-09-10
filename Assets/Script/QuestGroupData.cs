using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest Group Data",menuName ="Scriptable Object/Quest Group Data")]
public class QuestGroupData : ScriptableObject
{
    public string QuestGroupID;
    public List<QuestData> listQuest;
}
