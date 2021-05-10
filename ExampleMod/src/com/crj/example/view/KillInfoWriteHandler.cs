using ExampleMod.View;
using TaleWorlds.Core;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.Localization;


namespace ExampleMod.View
{
    public class KillInfoWriteHandler : ViewModel
    {
        private int killCount {get;set;}
        private int stunCount { get; set;}

        private int blockCount { get; set; }

        public TextViewModel killInfo { get; }

        public void kill() {
            killCount++;
        }

        public void stun()
        {
            stunCount++;
        }

        public void block() {
            blockCount++;
        }

        public KillInfoWriteHandler(bool showHint, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right)
        {
            killInfo = new TextViewModel(new TextObject(), showHint , horizontalAlignment);
            RefreshValues();
        }

        public sealed override void RefreshValues()
        {
            base.RefreshValues();
            killInfo.RefreshValues();
        }

        public void SetShowText(bool showHint)
        {
            killInfo.IsVisible = showHint;
            //击杀数：8 ｜ 击晕数：2 | 爆头数:1 格挡数:
            killInfo.TextObject = GameTexts.FindText("str_yigu_kill_format");
            killInfo.TextObject.SetTextVariable("kill", killCount.ToString());
            killInfo.TextObject.SetTextVariable("stun", stunCount.ToString());
            killInfo.TextObject.SetTextVariable("block", blockCount.ToString());
            killInfo.RefreshValues();
        }

        private TextObject GetHint(bool focusedOnAgent)
        {
            var result = GameTexts.FindText(focusedOnAgent
                ? "str_rts_camera_control_current_agent_hint"
                : "str_rts_camera_control_troop_hint");
            return result;
        }
    }
}
