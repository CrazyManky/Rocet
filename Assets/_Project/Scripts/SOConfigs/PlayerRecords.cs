using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.SOConfigs
{
    [CreateAssetMenu(fileName = "RecordsItem", menuName = "RecordsPlayers")]
    public class PlayerRecords : ScriptableObject
    {
        [SerializeField] private List<RecordItem> _recordItems = new();

        public List<RecordItem> GetRecords()
        {
            SortList();
            return _recordItems;
        }

        public void AddRecords(string multiplicate, int value)
        {
            var record = new RecordItem();
            record.Multiplicate = multiplicate;
            record.Value = value;
            _recordItems.Add(record);
            SortList();
        }

        public RecordItem GetLastRecordItem()
        {
            if (_recordItems.Count == 0)
            {
                var item = new RecordItem();
                item.Value = 0;
                item.Multiplicate = "x0";
                return item;
            }

            SortList();
            return _recordItems[0];
        }

        private void SortList()
        {
            _recordItems = _recordItems.OrderByDescending(n => n.Value).ToList();
        }

        public void Clear()
        {
            _recordItems.Clear();
        }
    }

    [Serializable]
    public class RecordItem
    {
        public string Multiplicate;
        public int Value;
    }
}