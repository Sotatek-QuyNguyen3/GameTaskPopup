using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
// using Hellmade.Sound;
using System.Linq;

public class PopupDailyMission : Popups
{
    public static PopupDailyMission Instance;
    public QuestItem questItem;
    public Transform scrollHolder;


    private Action<bool> _onResult;
    void InitUI()
    {

        foreach(var item in UserData.Instance.listQuestInProgress){
            Instantiate(questItem,scrollHolder);
            questItem.Init(item,UserData.Instance.onQuestFinish);
        }
    }

    
    #region BASE POPUP 
    static void CheckInstance(Action completed)//
    {
        if (Instance == null)
        {

            var loadAsset = Resources.LoadAsync<PopupDailyMission>("Prefab/UI/PopupPrefabs/PopupDailyMission" +
                "");
            loadAsset.completed += (result) =>
            {
                var asset = loadAsset.asset as PopupDailyMission;
                if (asset != null)
                {
                    Instance = Instantiate(asset,
                        CanvasPopup4.transform,
                        false);

                    if (completed != null)
                    {
                        completed();
                    }
                }
            };

        }
        else        
        {
            if (completed != null)
            {
                completed();
            }
        }
    }

    public static void Show()//
    {

        CheckInstance(() =>
        {
            Instance.Appear();
            Instance.InitUI();
        });

    }

    public static void Hide()
    {
        Instance.Disappear();
    }
    public override void Appear()
    {
        IsLoadBoxCollider = false;
        base.Appear();
        //Background.gameObject.SetActive(true);
        Panel.gameObject.SetActive(true);
    }
    public void Disappear()
    {
        //Background.gameObject.SetActive(false);
        base.Disappear(() =>
        {
            foreach (Transform item in scrollHolder)
            {
                Destroy(item.gameObject);
            }
            Panel.gameObject.SetActive(false);
        });
    }

    public override void Disable()
    {
        base.Disable();
    }

    public override void NextStep(object value = null)
    {
    }
    #endregion

}
