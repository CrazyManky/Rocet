using System;
using _Project.Screpts.Services;
using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.Audio
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfig soundConfig;
        [SerializeField] private AudioSource _buttonClickListener;
        [SerializeField] private AudioSource _gameSound;
        [SerializeField] private AudioSource _menuMusic;

        private bool _plaingMenu = false;
        private bool _plaingGame = false;


        private void Awake()
        {
            soundConfig.Load();
            SetDataMusic();
            SetSoundData();
        }

        public void PlayButtonClick()
        {
            _buttonClickListener.Play();
        }

        public void PlayGame()
        {
            if (_plaingGame)
            {
                _menuMusic.Stop();
                _plaingMenu = false;
                return;
            }

            _plaingGame = true;
            _plaingMenu = false;
            _menuMusic.Stop();
            _gameSound.Play();
        }

        public void PlayMenu()
        {
            if (_plaingMenu)
            {
                _plaingGame = false;
                _gameSound.Stop();
                return;
            }

            _plaingMenu = true;
            _plaingGame = false;
            _gameSound.Stop();
            _menuMusic.Play();
        }

        private void SetSoundData()
        {
            if (soundConfig.ActiveSound)
                _buttonClickListener.volume = 1;
            else
                _buttonClickListener.volume = 0;
        }

        private void SetDataMusic()
        {
            if (soundConfig.VolumeMusic)
            {
                _menuMusic.volume = 1;
                _gameSound.volume = 1;
            }
            else
            {
                _gameSound.volume = 0;
                _menuMusic.volume = 0;
            }
        }

        private void Update()
        {
            SetDataMusic();
            SetSoundData();
        }
    }
}