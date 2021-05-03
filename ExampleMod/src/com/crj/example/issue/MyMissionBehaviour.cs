using ExampleMod.Configuretion;
using ExampleMod.View;
using System;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Missions;

namespace ExampleMod.src.com.crj.example.issue
{
    class MyMissionBehaviour : MissionView
    {
        public override MissionBehaviourType BehaviourType => MissionBehaviourType.Logic;
        private KillInfoWriteHandler textHandler;
        private GauntletLayer _showControlHintLayer;
        private bool enable = true;

        public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
        {
            if (!enable)
            {
                return;
            }
            if (affectedAgent == null || affectorAgent == null || !affectorAgent.IsMainAgent || !affectorAgent.IsEnemyOf(affectedAgent) || affectedAgent.IsMount)
            {
                return;
            }
            float health = ((affectorAgent.Health + GameLoadConfiguration.healAmount < affectorAgent.HealthLimit) ? (affectorAgent.Health + GameLoadConfiguration.healAmount) : affectorAgent.HealthLimit);
            affectorAgent.Health = health;
            affectorAgent.UpdateAgentProperties();
            if (agentState == AgentState.Killed)
            {
                textHandler.kill();
            }
            else if (agentState == AgentState.Unconscious)
            {
                textHandler.stun();
            }
            textHandler.SetShowText(true);

        }


        protected override void OnAgentControllerChanged(Agent agent)
        {
            /*if (null == MissionScreen) {
                FocusOnAgent(agent);
            }*/
            if (!enable)
            {
                return;
            }

            if (null == MissionScreen)
            {
                enable = false;
                return;
            }
            if (_showControlHintLayer != null && textHandler != null)
            {
                return;
            }
            _showControlHintLayer = new GauntletLayer(1);
            textHandler = new KillInfoWriteHandler(true, GameLoadConfiguration.horizontalAlignment);
            _showControlHintLayer.LoadMovie("showControlHint", textHandler);
            MissionScreen.AddLayer(_showControlHintLayer);
            textHandler.SetShowText(true);
        }



        public override void OnMissionScreenFinalize()
        {
            base.OnMissionScreenFinalize();
            if (null != _showControlHintLayer)
            {
                MissionScreen.RemoveLayer(_showControlHintLayer);
            }
            _showControlHintLayer = null;
            textHandler = null;
        }

        public override void OnRegisterBlow(Agent attacker, Agent victim, GameEntity realHitEntity, Blow b, ref AttackCollisionData collisionData, in MissionWeapon attackerWeapon)
        {
            if (!enable)
            {
                return;
            }
            if (attacker == null || victim == null || !attacker.IsMainAgent || !attacker.IsEnemyOf(victim) || victim.IsMount)
            {
                return;
            }
            if (BoneBodyPartType.CriticalBodyPartsBegin == b.VictimBodyPart)
            {
                textHandler.block();
                textHandler.SetShowText(true);
            }
        }
        public override void OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
        {
            if (!enable)
            {
                return;
            }
            if (MissionScreen != null && MissionScreen.Mission != null && MissionScreen.Mission.Mode == MissionMode.Tournament)
            {
                enable = false;

            }
        }



        public static String ConvertStr(String key, String value)
        {
            return key + ":" + value + ",";
        }


        public override void OnMissionScreenInitialize()
        {


        }

        public override void OnRemoveBehaviour()
        {

        }


        /*public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, int damage, in MissionWeapon affectorWeapon)
        {

            StringBuilder builder = new StringBuilder("OnAgentHit 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }


        public override void OnAddTeam(Team team)
        {
            StringBuilder builder = new StringBuilder("OnAddTeam 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAfterMissionCreated()
        {

            StringBuilder builder = new StringBuilder("OnAfterMissionCreated 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentAlarmedStateChanged(Agent agent, Agent.AIStateFlag flag)
        {

            StringBuilder builder = new StringBuilder("OnAgentAlarmedStateChanged 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentBuild(Agent agent, Banner banner)
        {

            StringBuilder builder = new StringBuilder("OnAgentBuild 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentCreated(Agent agent)
        {

            StringBuilder builder = new StringBuilder("OnAgentCreated 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentDeleted(Agent affectedAgent)
        {

            StringBuilder builder = new StringBuilder("OnAgentDeleted 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentDismount(Agent agent)
        {

            StringBuilder builder = new StringBuilder("OnAgentDismount 事件触发成功 data:[");

            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentFleeing(Agent affectedAgent)
        {

            StringBuilder builder = new StringBuilder("OnAgentFleeing 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentInteraction(Agent userAgent, Agent agent)
        {

            StringBuilder builder = new StringBuilder("OnAgentInteraction 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentMount(Agent agent)
        {

            StringBuilder builder = new StringBuilder("OnAgentMount 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAgentPanicked(Agent affectedAgent)
        {

            StringBuilder builder = new StringBuilder("OnAgentPanicked 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }

        public override void OnAgentShootMissile(Agent shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, int forcedMissileIndex)
        {

            StringBuilder builder = new StringBuilder("OnAgentShootMissile 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnAssignPlayerAsSergeantOfFormation(Agent agent)
        {

            StringBuilder builder = new StringBuilder("OnAssignPlayerAsSergeantOfFormation 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnBehaviourInitialize()
        {

            StringBuilder builder = new StringBuilder("OnBehaviourInitialize 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnClearScene()
        {

            StringBuilder builder = new StringBuilder("OnClearScene 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnCreated()
        {

            StringBuilder builder = new StringBuilder("OnCreated 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnEarlyAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
        {

            StringBuilder builder = new StringBuilder("OnAgentHit 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnEntityRemoved(GameEntity entity)
        {

            StringBuilder builder = new StringBuilder("OnEntityRemoved 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnFocusGained(Agent agent, IFocusable focusableObject, bool isInteractable)
        {

            StringBuilder builder = new StringBuilder("OnFocusGained 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnFocusLost(Agent agent, IFocusable focusableObject)
        {

            StringBuilder builder = new StringBuilder("OnFocusLost 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnFormationUnitsSpawned(Team team)
        {

            StringBuilder builder = new StringBuilder("OnFormationUnitsSpawned 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnItemPickup(Agent agent, SpawnedItemEntity item)
        {

            StringBuilder builder = new StringBuilder("OnItemPickup 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnMissileCollisionReaction(Mission.MissileCollisionReaction collisionReaction, Agent attackerAgent, Agent attachedAgent, sbyte attachedBoneIndex)
        {

            StringBuilder builder = new StringBuilder("OnMissileCollisionReaction 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnMissileHit(Agent attacker, Agent victim, bool isCanceled)
        {

            StringBuilder builder = new StringBuilder("OnMissileHit 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnMissionActivate()
        {

            StringBuilder builder = new StringBuilder("OnMissionActivate 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnMissionDeactivate()
        {

            StringBuilder builder = new StringBuilder("OnMissionDeactivate 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }

        public override void OnMissionRestart()
        {

            StringBuilder builder = new StringBuilder("OnMissionRestart 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnMissionTick(float dt)
        {

            StringBuilder builder = new StringBuilder("OnMissionTick 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnObjectStoppedBeingUsed(Agent userAgent, UsableMissionObject usedObject)
        {

            StringBuilder builder = new StringBuilder("OnObjectStoppedBeingUsed 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
        {

            StringBuilder builder = new StringBuilder("OnObjectUsed 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnPreDisplayMissionTick(float dt)
        {

            StringBuilder builder = new StringBuilder("OnPreDisplayMissionTick 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnPreMissionTick(float dt)
        {

            StringBuilder builder = new StringBuilder("OnPreMissionTick 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }

        public override void OnRenderingStarted()
        {

            StringBuilder builder = new StringBuilder("OnRenderingStarted 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, float damage, float movementSpeedDamageModifier, float hitDistance, AgentAttackType attackType, float shotDifficulty, BoneBodyPartType victimHitBodyPart)
        {

            StringBuilder builder = new StringBuilder("OnScoreHit 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }

        protected override void OnGetAgentState(Agent agent, bool usedSurgery)
        {

            StringBuilder builder = new StringBuilder("OnGetAgentState 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
        protected override void OnObjectDisabled(DestructableComponent destructionComponent)
        {

            StringBuilder builder = new StringBuilder("OnObjectDisabled 事件触发成功 data:[");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }*/

    }
}
