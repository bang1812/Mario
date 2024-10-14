using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    Coin,
    Size,
    Skill
}
public class BoxReward : MonoBehaviour, IBoxRespond
{
    public Animator box_ani;
    public GameObject coin;
    public GameObject sizeup;
    public GameObject flower;
    public int countcoin;
    public int countmushroom;
    public int countflower;
    public PowerType type = PowerType.Size;
    public GameObject hitpoint;
    

    public void Respond()
    {
        switch (type)
        {
            case PowerType.Coin:
                if (countcoin == 0)
                    return;
                box_ani.Play("Hit", 0, 0);
                
                GameObject bonusCoin = Instantiate(coin, transform.position, Quaternion.identity);
                
                GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
                clone.GetComponent<BonusPoint>().scorenumber = 5;
                UIManager.instance.score += 5;
                UIManager.instance.SetScore();
                Destroy(clone, 1);
                Destroy(bonusCoin, 1);
                if (--countcoin <= 0)
                {
                    box_ani.Play("Empty", 0, 0);
                    return;
                }
                break;
            case PowerType.Size:

                if (countmushroom == 0)
                    return;
                box_ani.Play("Hit", 0, 0);
                Vector3 position = transform.position;
                position.y ++;

                GameObject apple = Instantiate(sizeup, position, Quaternion.identity);
                apple.transform.SetParent(LevelManager.instance.curLevel.transform);
                if (--countmushroom <= 0)
                {
                    box_ani.Play("Empty", 0, 0);
                    return;
                }
                

                break;
            case PowerType.Skill:
                if (countflower == 0)
                    return;
                box_ani.Play("Hit", 0, 0);
                Vector3 pos = transform.position;
                pos.y++;

                GameObject Skill = Instantiate(flower, pos, Quaternion.identity);
                Skill.transform.SetParent(LevelManager.instance.curLevel.transform);
                if (--countflower <= 0)
                {
                    box_ani.Play("Empty", 0, 0);
                    return;
                }
                break;
            

            default:
                break;
        }
        
        
    }
    

}
