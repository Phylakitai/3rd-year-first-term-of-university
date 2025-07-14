using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSkeleton : EnemyInfo
{



    public override int Initalize(int enemyHp)
    {
        return enemyHp;
    }
    public override int Initalize(int enemyHp, int Damage)
    {
        ad = "Small Skeleton";
        levell = 5;
        EnemyHp = base.Initalize(enemyHp);
        speed = 10;
        base.Initalize(enemyHp , Damage);
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
