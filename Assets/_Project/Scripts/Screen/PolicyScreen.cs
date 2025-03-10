using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class PolicyScreen : BaseScreen
    {
        
        
        public void BackToSettings()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }
    }
}