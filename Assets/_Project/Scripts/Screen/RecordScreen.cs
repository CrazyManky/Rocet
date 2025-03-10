using System.Collections.Generic;
using _Project.Scripts.SOConfigs;
using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class RecordScreen : BaseScreen
    {
        [SerializeField] private PlayerRecords _playerRecords;
        [SerializeField] private Transform _conteiner;
        [SerializeField] private RecordItem _recordItemPrefab;

        private List<RecordItem> _recordItems = new();

        public override void Init()
        {
            base.Init();
            var data = _playerRecords.GetRecords();
            if (data.Count <= 7)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var instanceScore = Instantiate(_recordItemPrefab, _conteiner);
                    instanceScore.SetData(i, data[i].Value, data[i].Multiplicate);
                    _recordItems.Add(instanceScore);
                }
            }
            else
            {
                for (int i = 0; i <= 7; i++)
                {
                    var instanceScore = Instantiate(_recordItemPrefab, _conteiner);
                    instanceScore.SetData(i, data[i].Value, data[i].Multiplicate);
                    _recordItems.Add(instanceScore);
                }
            }
        }

        public void BackMenu()
        {
            Dialog.ShowMenuScreen();
        }

        public void Clear()
        {
            AudioManager.PlayButtonClick();
            _recordItems.ForEach((item) => { Destroy(item.gameObject); });
            _recordItems.Clear();
            _playerRecords.Clear();
        }
    }
}