using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{
    [SerializeField] private QuestProgress questProgress;
    [SerializeField] private TextMeshProUGUI questTitle;
    [SerializeField] private TextMeshProUGUI questDescription;
    [SerializeField] private Sprite questIcon;
    [SerializeField] private SpriteAtlas iconAtlas;
    [SerializeField] private RewardType rewardType;
    [SerializeField] private TextMeshProUGUI rewardAmount;
    [SerializeField] private Sprite rewardIcon;
    [SerializeField] private Slider questProgressBar;
    [SerializeField] private TextMeshProUGUI questProgressText;
    [SerializeField] private Button collectReward;
    [SerializeField] private Image finishedBackground;

    public void Init(QuestProgress newQuestProgress)
    {
        questProgress = newQuestProgress;
    }
    public void UpdateProgress()
    {
        questProgressText.text = $"{questProgress.Progress}/{questProgress.Require}";
        questProgressBar.value = (float)questProgress.Progress / questProgress.Require;
        if (questProgress.QuestStatus == QuestStatus.Finined)
        {
            collectReward.interactable = true;
            finishedBackground.gameObject.SetActive(true);
        }
    }

}
