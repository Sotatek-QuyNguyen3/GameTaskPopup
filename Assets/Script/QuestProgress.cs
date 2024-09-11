using UnityEngine;

public class QuestProgress : MonoBehaviour
{
    [SerializeField] private QuestData questData;
    [SerializeField] private int currentProgress;
    [SerializeField] private QuestStatus currentQuestStatus = QuestStatus.Locking;
    public int Progress { get => currentProgress; }
    public int Require { get => questData.requestAmount; }
    public QuestStatus QuestStatus { get => currentQuestStatus; }
    public QuestProgress(QuestData newQuestData)
    {
        questData = newQuestData;
        currentProgress = 0;
        currentQuestStatus = QuestStatus.Doing;
    }
    public QuestData GetQuestData()
    {
        return questData;
    }

    public int AddQuestProcess(int AddInAmount)
    {
        currentProgress += AddInAmount;
        if (currentProgress >= questData.requestAmount)
        {
            currentQuestStatus = QuestStatus.Finined;
            currentProgress = questData.requestAmount;
        }
        return currentProgress;
    }

}
public enum QuestStatus
{
    Locking,
    Doing,
    Finined
}