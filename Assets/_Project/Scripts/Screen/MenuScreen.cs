using Project.Screpts.Screen;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class MenuScreen : BaseScreen
    {
        public void ShowGameScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowGameScreen();
        }

        public void ShowSettingsScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowShopScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowShopScreen();
        }

        public void ShowRecordsScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowRecordsScreen();
        }

        public void CloseApp()
        {
            AudioManager.PlayButtonClick();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif

            Application.Quit();
        }
    }
}