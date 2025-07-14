using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSkeletonScript : EnemyInfo
{
    public override int Initalize(int enemyHp)
    {        
        return enemyHp;
    }
    public override int Initalize(int enemyHp, int Damage)
    {
        ad = "Big Skeleton";
        levell = 5;
        EnemyHp = base.Initalize(enemyHp);
        speed = 8;
        base.Initalize(enemyHp + 50, Damage + 10);
        return base.Initalize(enemyHp, Damage);
    }
    public override void TextMetod()
    {
        textName.text = ad;
        textlevel.text = "Level:" + levell.ToString();
        textspeed.text = "Hýz:" + speed.ToString();
        textEnemyHp.text = "Can:" + EnemyHp.ToString();
        textenemyDamage.text = "Hasar:" + EnemyDamage.ToString();
    }
    


}
