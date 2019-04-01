using GURPS_Character_Creator.Models;
using GURPS_Character_Creator.ViewModel.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GURPS_Character_Creator.ViewModel
{
    public class SkillViewModel : INotifyPropertyChanged
    {
        // Properties
        public ObservableCollection<ActiveListedSkill> PlayerSkillList { get; set; }
        public SkillList SkillList { get; set; }

        private SkillModel _SelectedItem;
        public SkillModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                AddSkillCommand?.RaiseCanExecuteChanged();
                OnPropertyChanged();
                DescriptionItem = value;
            }
        }

        private ActiveListedSkill _SelectedItemRM;
        public ActiveListedSkill SelectedItemRM
        {
            get { return _SelectedItemRM; }
            set
            {
                _SelectedItemRM = value;
                RemoveSkillCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
                DescriptionItem = value?.SkillModel;
            }
        }

        private SkillModel _DescriptionItem { get; set; }
        public SkillModel DescriptionItem
        {
            get { return _DescriptionItem; }
            set { _DescriptionItem = value; OnPropertyChanged(); }
        }

        // Constructor
        public SkillViewModel()
        {
            PlayerSkillList = new ObservableCollection<ActiveListedSkill>();
            SkillList = new SkillList();

            AddSkillCommand = new DelegateCommand(x => AddSkillExecute(), x => AddSkillCanExecute());
            RemoveSkillCommand = new DelegateCommand(x => RemoveSkillExecute(), x => RemoveSkillCanExecute());
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Action<ActiveListedSkill> SkillAddedEvent;
        private void OnSkillAdded(ActiveListedSkill x)
        {
            SkillAddedEvent?.Invoke(x);
        }

        // Commands
        public DelegateCommand AddSkillCommand { get; set; }
        public void AddSkillExecute()
        {
            var x = new ActiveListedSkill(SelectedItem);

            if(!PlayerSkillList.Any(p => p.SkillModel.Name == SelectedItem.Name))
            {
                if(SelectedItem != null)
                    PlayerSkillList.Add(x);
                OnSkillAdded(x);
                AddSkillCommand.RaiseCanExecuteChanged();
                //x.DescriptionChangedEvent += UpdateDescription;
            }
        }
        private bool AddSkillCanExecute() { return SelectedItem != null && !PlayerSkillList.Any(p => p.SkillModel.Name == SelectedItem.Name); }

        public DelegateCommand RemoveSkillCommand { get; set; }
        public void RemoveSkillExecute() { if(SelectedItemRM != null) PlayerSkillList.Remove(SelectedItemRM); OnSkillAdded(SelectedItemRM); }
        private bool RemoveSkillCanExecute() { return SelectedItemRM != null; }

        // Methods
        private void UpdateDescription(SkillModel x)
        {
            DescriptionItem = x;
        }
    }

    /// <summary>
    /// Object for Skills the Player has Selected
    /// </summary>
    public class ActiveListedSkill : INotifyPropertyChanged
    {
        // Properties
        public SkillModel SkillModel { get; private set; }

        private PlayerStats PlayerStats { get; set; }
        private int UnspentPoints { get; set; }

        private int _TotalPoint { get; set; }
        public int TotalPoint
        {
            get { return _TotalPoint; }
            set { _TotalPoint = value; OnPointChanged(value); OnPropertyChanged(); }
        }

        private int _RankLevel { get; set; }
        public int RankLevel
        {
            get { return _RankLevel; }
            set { _RankLevel = value; OnPropertyChanged(); }
        }

        private int _Modifier { get; set; }
        public int Modifier
        {
            get { return _Modifier; }
            set { _Modifier = value; OnPropertyChanged(); }
        }

        // Constructor
        public ActiveListedSkill(SkillModel skill)
        {
            SkillModel = skill;
            RankLevel = 0;
            TotalPoint = 0;

            switch(skill.Type.Difficulty)
            {
                case Difficulty.Easy:
                    Modifier = -1;
                    break;
                case Difficulty.Average:
                    Modifier = -2;
                    break;
                case Difficulty.Hard:
                    Modifier = -3;
                    break;
            }

            IncSkillRankCommand = new DelegateCommand((x) => IncRankExecute(), (x) => true);
            DecSkillRankCommand = new DelegateCommand((x) => DecRankExecute(), (x) => DecRankCanExecute());

                //UpdateDescriptionCommand = new DelegateCommand(x => UpdateDescriptionExecute(x), x => true);
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event Action<int> PointChangedEvent;
        private void OnPointChanged(int x)
        {
            PointChangedEvent?.Invoke(x);
        }

            //public event Action<SkillModel> DescriptionChangedEvent;
            //public void OnDescriptionChanged(SkillModel x)
            //{
            //    DescriptionChangedEvent?.Invoke(x);
            //}

        // Commands
        public DelegateCommand IncSkillRankCommand { get; set; }
        public void IncRankExecute()
        {
            RankLevel += 1;
            CalcIncTotalPoint();
            DecSkillRankCommand.RaiseCanExecuteChanged();
        }

        public DelegateCommand DecSkillRankCommand { get; set; }
        public void DecRankExecute() { RankLevel -= 1; CalcDecTotalPoint(); DecSkillRankCommand.RaiseCanExecuteChanged(); }
        private bool DecRankCanExecute() { return RankLevel >= 1; }

        //public DelegateCommand UpdateDescriptionCommand { get; set; }
        //public void UpdateDescriptionExecute(object sender)
        //{
        //    Console.WriteLine("Hello " + sender);
        //    // OnDescriptionChanged(sender as SkillModel);
        //}

        // Methods
        private void CalcIncTotalPoint()
        {
            if(RankLevel >= 4)
                TotalPoint += 4;
            else if(RankLevel == 3)
                TotalPoint = 4;
            else if(RankLevel == 2)
                TotalPoint = 2;
            else if(RankLevel <= 1)
                TotalPoint += 1;

            SetModifier();
        }

        private void CalcDecTotalPoint()
        {
            if(RankLevel >= 4)
                TotalPoint -= 4;
            else if(RankLevel == 3)
                TotalPoint = 4;
            else if(RankLevel == 2)
                TotalPoint = 2;
            else if(RankLevel <= 1)
                TotalPoint -= 1;

            SetModifier();
        }

        private void SetModifier()
        {
            switch(SkillModel.Type.Difficulty)
            {
                case Difficulty.Easy:
                    Modifier = RankLevel - 1;
                    break;
                case Difficulty.Average:
                    Modifier = RankLevel - 2;
                    break;
                case Difficulty.Hard:
                    Modifier = RankLevel - 3;
                    break;
            }
        }
    }
}
