/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Linq;

namespace UnityEngine.UI.Extensions.Examples.FancyScrollViewExample05
{
    class LevelsInitializer : MonoBehaviour
    {
        [SerializeField] private ScrollView _scrollView;
        [SerializeField] private Button _prevCellButton;
        [SerializeField] private Button _nextCellButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Text _selectedItemInfo;
        [SerializeField] private JSONController _jsonController;

        private int _unlockedLevelsCount;

        public int UnlockedLevelsCount
        {
            get { return _unlockedLevelsCount; }
            set { _unlockedLevelsCount = value; }
        }

        void Start()
        {
            _prevCellButton.onClick.AddListener(_scrollView.SelectPrevCell);
            _nextCellButton.onClick.AddListener(_scrollView.SelectNextCell);
            _playButton.onClick.AddListener(_scrollView.LaunchLevel);
            _scrollView.OnSelectionChanged(OnSelectionChanged);

            var items = Enumerable.Range(1, 20)
                .Select(i => new ItemData($"Ур. {i}"))
                .ToList();

            _unlockedLevelsCount = _jsonController.PlayerStats.UnlockedLevelsCount;
            _scrollView.UpdateData(items);
            _scrollView.UpdateSelection(_unlockedLevelsCount - 1);
            _scrollView.JumpTo(_unlockedLevelsCount - 1);
        }

        void OnSelectionChanged(int index)
        {
            _selectedItemInfo.text = $"Selected item info: index {index}";
            if(index > _unlockedLevelsCount - 1)
                _playButton.interactable = false;
            else
                _playButton.interactable = true;
        }
    }
}
