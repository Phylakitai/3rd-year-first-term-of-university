using UnityEngine;

public class Skill2 : SkillBase
{
  
    public override void UseSkill(PlayerController playerController)
    {
       
        playerController.DamageEnemy(15);
    }
}
