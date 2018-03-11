﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testShoot : MonoBehaviour {
    public UnityEvent e;
    public GameObject target,Bullet;
    public Chest s;
	// Use this for initialization
	void Start () {
        
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RewardInfo a = RewardManager.Instance.MakeReward(RewardType.Coin, 10);

            InformationPanel.Instance.OpenRewardPanel(a,null,"Get");

        }
    }
    void spawnBullet()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<AimedProjectile>().Spawn(target, 10);
    }
    void openChest()
    {
        s.MakeChest();
    }
    public string GiveID()
    {
        string answer = "";
        bool find = true;
        for (int i = 0; i < 10; i++)
        {
            int a = Random.Range(1, 3);
            if(a==1)
            {
                answer += (char)Random.Range(48, 58);
            }
            else
            {
                answer += (char)Random.Range(65, 90);
            }
        }
        
        print(answer);
        return answer;
    }
}
