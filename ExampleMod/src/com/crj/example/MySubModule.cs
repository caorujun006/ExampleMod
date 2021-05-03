using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using ExampleMod.Configuretion;
using ExampleMod.src.com.crj.example.issue;

namespace ExampleMod
{

    class MySubModule : MBSubModuleBase
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            try
            {
                GameLoadConfiguration.loadConfig();
                //new Harmony("PROZ.healthonkill").PatchAll();
            }
            catch (Exception e)
            {
                InformationManager.DisplayMessage(new InformationMessage("error load public.proerties"));
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission) {
            MyMissionBehaviour myMissionBehaviour = new MyMissionBehaviour();
            mission.MissionBehaviours.Add(myMissionBehaviour);
        }
    }




}
