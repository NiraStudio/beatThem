﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InformationPanel : MonoBehaviour {
    #region SingleTon
    public static InformationPanel Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion

    public InformationByType[] Panels;
    public Animator PanelAnimator;
    public GameObject BackPanel;
    // Use this for initialization
    void Start()
    {
        PanelAnimator.gameObject.SetActive(false);
        BackPanel.SetActive(false);
    }
    public void OpenInfoPanel(string Text, UnityAction OkAction, string OkButtonText)
    {
        DeactiveAll();
        foreach (var item in Panels)
        {
            if (item.Type == InformationType.Info)
            {
                item.Panel.SetActive(true);
                item.text.text = Text;
                item.buttons[0].onClick.RemoveAllListeners();
                if(OkAction!=null)
                item.buttons[0].onClick.AddListener(OkAction);
                item.buttons[0].onClick.AddListener(Close);
                item.buttons[0].transform.GetChild(0).GetComponent<Text>().text = OkButtonText;
            }
        }
        PanelAnimator.gameObject.SetActive(true);
        PanelAnimator.SetTrigger("Open");
        BackPanel.SetActive(true);


    }
    public void OpenRewardPanel(RewardInfo Info, UnityAction OkAction,string OkButtonText)
    {
        DeactiveAll();
        foreach (var item in Panels)
        {
            if (item.Type == InformationType.Reward)
            {
                item.Panel.SetActive(true);
                item.Panel.transform.GetChild(0).GetComponent<RewardCard>().Repaint(Info);
                item.buttons[0].onClick.RemoveAllListeners();
                if (OkAction != null)
                    item.buttons[0].onClick.AddListener(OkAction);
                item.buttons[0].onClick.AddListener(Close);
                item.buttons[0].transform.GetChild(0).GetComponent<Text>().text = OkButtonText;
            }
        }
        PanelAnimator.gameObject.SetActive(true);
        PanelAnimator.SetTrigger("Open");
        BackPanel.SetActive(true);

    }
    void Close()
    {
        PanelAnimator.gameObject.SetActive(false);
        BackPanel.SetActive(false);

    }
    void DeactiveAll()
    {
        for (int i = 0; i < PanelAnimator.transform.childCount; i++)
        {
            PanelAnimator.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    [System.Serializable]
    public class InformationByType
    {
        public InformationType Type;
        public GameObject Panel;
        public Text text;
        public Button[] buttons;
    }
    
}
public enum InformationType
{
    Reward,Info
}
