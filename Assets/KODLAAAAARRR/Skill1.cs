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
        playerController.Damage = 20; // Ge�ici hasar art���
        

        yield return new WaitForSeconds(3); // G��lendirilmi� hasar s�resi

        playerController.Damage = originalDamage; // Hasar eski haline d�n�yor
        
    }
}
