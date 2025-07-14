using UnityEngine;

public class Skill3 : SkillBase
{
    public override void UseSkill(PlayerController playerController)
    {
        
        playerController.DamageEnemy(20);
    }
}
