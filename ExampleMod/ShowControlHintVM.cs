﻿using System;
using System.Collections.Generic;
using System.Linq;
using MissionSharedLibrary.Utilities;
using MissionSharedLibrary.View.ViewModelCollection.Basic;
using RTSCamera.Config.HotKey;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;


namespace ExampleMod
{
    class ShowControlHintVM
    {
        public TextViewModel Hint { get; }

        public TextViewModel CharacterName { get; set; }

        public ShowControlHintVM(bool showHint)
        {
            Hint = new TextViewModel(new TextObject(), showHint);
            CharacterName = new TextViewModel(new TextObject(), false);
            RefreshValues();
        }

        public sealed override void RefreshValues()
        {
            base.RefreshValues();

            Hint.RefreshValues();
            CharacterName.RefreshValues();
        }

        public void SetShowText(bool focusedOnAgent, bool showHint, string characterName = null)
        {
            Hint.TextObject = GetHint(focusedOnAgent);
            Hint.IsVisible = showHint;
            if (characterName == null)
            {
                CharacterName.IsVisible = false;
            }
            else
            {
                CharacterName.IsVisible = true;
                CharacterName.TextObject = new TextObject(characterName);
            }
        }

        private TextObject GetHint(bool focusedOnAgent)
        {
            var result = GameTexts.FindText(focusedOnAgent
                ? "str_rts_camera_control_current_agent_hint"
                : "str_rts_camera_control_troop_hint");

            result.SetTextVariable("KeyName",
                Utility.TextForKey(RTSCameraGameKeyCategory.GetKey(GameKeyEnum.ControlTroop)));
            return result;
        }

    }
}
