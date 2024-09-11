using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance { get; private set; }
    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public ListDailyQuest listDailyQuest;
    public List<QuestProgress> listQuestInProgress;
    public List<QuestProgress> ListQuestFinished;

    public void GenerateQuest(){
        foreach(var item in listDailyQuest.listQuestGroupData){
            QuestProgress newQuestProgress = new(item.listQuest[0]);
            listQuestInProgress.Add(newQuestProgress);
        }
        foreach(var item in listDailyQuest.listQuestData){
            QuestProgress newQuestProgress = new(item);
            listQuestInProgress.Add(newQuestProgress);
        }
    }
    public void OnFinishQuest(QuestProgress finishedQuest){
        // foreach(var item in listDailyQuest.listQuestData){
        //     if(item.questID == finishedQuest.GetQuestData().questID){
        //         ListQuestFinished.Add(finishedQuest);
        //         listQuestInProgress.Remove(finishedQuest);
        //     }
        // }
        ListQuestFinished.Add(finishedQuest);
        listQuestInProgress.Remove(finishedQuest);
        foreach(var group in listDailyQuest.listQuestGroupData){
            if(group.QuestGroupID == finishedQuest.GetQuestData().questGroupID){
                var quest = group.listQuest.Find(x=>x.questID == finishedQuest.GetQuestData().questID);
                string[] nameComponent = quest.questID.Split("_");
                string nextQuestName = nameComponent[0]+nameComponent[1]+ (Convert.ToInt16(nameComponent[2])+1).ToString();
                var nextQuest = group.listQuest.Find(x=>x.questID == nextQuestName);
                if(nextQuest!=null){
                    QuestProgress newQuestProgress = new(nextQuest);
                    listQuestInProgress.Add(newQuestProgress);
                    
                }
            }
        }
    }
}
