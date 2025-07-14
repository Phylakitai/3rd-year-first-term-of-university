using System.Collections;
using UnityEngine;

public class Skill1 : SkillBase
{
   

    public override void UseSkill(PlayerController playerController)
    {
        StartCoroutine(TemporaryDamageBoost(playerController));
    }

    private IEnumerator TemporaryDamageBoost(PlayerController playerController)
    {
        int originalDamage = playerController.Damage;
        playerController.Damage = 20; // Geçici hasar artýþý
        

        yield return new WaitForSeconds(3); // Güçlendirilmiþ hasar süresi

        playerController.Damage = originalDamage; // Hasar eski haline dönüyor
        
    }
}
