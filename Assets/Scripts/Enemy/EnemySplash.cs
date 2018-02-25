﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplash : Enemy
{
    Collider2D[] characters;
    public override void Attack()
    {
        characters = Physics2D.OverlapCircleAll(transform.position, range, charactersLayer);
        foreach (var item in characters)
        {
            item.SendMessage("GetHit",(float) damage);
        }
        time = 0;
    }

}
