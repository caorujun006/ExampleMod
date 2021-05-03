
using HarmonyLib;

using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;
using System.Text;
using TaleWorlds.InputSystem;
using TaleWorlds.GauntletUI;

namespace ExampleMod.Other
{
	/*[HarmonyPatch(typeof(Mission), "RegisterBlow")]
	internal class HealthOnKillPatch
	{
		*//*private static bool blowWillDoDamageToVictim(Agent attacker, Agent victim, Blow b, ref AttackCollisionData collisionData)
		{

			return !collisionData.AttackBlockedWithShield && b.SelfInflictedDamage < 0 && attacker.IsEnemyOf(victim) && !victim.IsMount;
		}*//*

		private static void Postfix(Agent attacker, Agent victim, GameEntity realHitEntity, Blow b, ref AttackCollisionData collisionData)
		{

			if (attacker == null || victim == null || !attacker.IsMainAgent) {
				return;
			}
			InformationManager.DisplayMessage(new InformationMessage("agentStatus:" + victim.State.ToString()));
			*//*StringBuilder message = new StringBuilder("datas:[");
				message.Append("AttackCollisionData.AttackBlockedWithShield :" + collisionData.AttackBlockedWithShield + "  ,");
				message.Append("Blow.SelfInflictedDamage :" + b.SelfInflictedDamage + "  ,");
				message.Append("attacker.IsEnemyOf(victim) :" + attacker.IsEnemyOf(victim) + "  ,");
				message.Append("victim.IsMount :" + victim.IsMount + "  ,");
				message.Append("\r");
				message.Append("0f :" + 0f + "  ,");
				message.Append("attacker.Health :" + attacker.Health + "  ,");
				message.Append("attacker.HealthLimit :" + attacker.HealthLimit + "  ,");
				message.Append("victim.Health :" + victim.Health + "  ,");
				message.Append("victim.HealthLimit :" + victim.HealthLimit + "  ,");
				message.Append("]");
				FileUtil.writeLog(message.ToString());*//*
			InformationManager.DisplayMessage(new InformationMessage("AttackerStunPeriod:" + collisionData.DefenderStunPeriod + "-" + collisionData.AttackerStunPeriod));
			//1受害者是个人(砍坐骑无效) 2受害者是进攻者的敌人(砍自己人无效)  3受害者死亡或者被击晕
			if (!victim.IsMount && attacker.IsEnemyOf(victim) && (0<= victim.Health || 0<= collisionData.AttackerStunPeriod ))
			{
				InformationManager.DisplayMessage(new InformationMessage("击杀击晕事件触发成功啦Postfix ,击杀数量:"+ attacker.KillCount));
				float health = ((attacker.Health + HealOnKillConfiguration.healAmount < attacker.HealthLimit) ? (attacker.Health + HealOnKillConfiguration.healAmount) : attacker.HealthLimit);
				attacker.Health = health;
				attacker.UpdateAgentProperties();
				//FileUtil.writeLog("结算后血量:" + health + " ,是否修改成功" + attacker.Health.Equals(health));
			}
		}
	}*/
}
