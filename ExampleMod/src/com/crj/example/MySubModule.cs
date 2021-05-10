using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using ExampleMod.Configuretion;
using ExampleMod.src.com.crj.example.issue;
using TaleWorlds.ModuleManager;
using System.IO;
using System.Reflection;

namespace ExampleMod
{




    class MySubModule : MBSubModuleBase
    {
        public static String ModuleId = "model_main";
        public static String ModulePath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).ToString()).ToString();
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

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            game.GameTextManager.LoadGameTexts(Path.Combine(MySubModule.ModulePath, "ModuleData", "module_strings.xml"));

            
        }
    }




}
