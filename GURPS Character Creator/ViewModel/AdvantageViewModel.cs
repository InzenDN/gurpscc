using GURPS_Character_Creator.Models;
using GURPS_Character_Creator.ViewModel.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GURPS_Character_Creator.ViewModel
{
    public class AdvantageViewModel : INotifyPropertyChanged
    {
        // Properties
        public ObservableCollection<ActiveListedAdvantage> PlayerAdvantageList { get; set; }
        public AdvantageList AdvantageList { get; set; }

        private AdvantageModel _SelectedItem;
        public AdvantageModel SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; AddAdvantageCommand.RaiseCanExecuteChanged(); DescriptionItem = value; }
        }

        private ActiveListedAdvantage _SelectedItemRM;
        public ActiveListedAdvantage SelectedItemRM
        {
            get { return _SelectedItemRM; }
            set { _SelectedItemRM = value; RemoveAdvantageCommand.RaiseCanExecuteChanged(); DescriptionItem = value?.AdvantageModel; }
        }

        private AdvantageModel _DescriptionItem { get; set; }
        public AdvantageModel DescriptionItem
        {
            get { return _DescriptionItem; }
            set { _DescriptionItem = value; OnPropertyChanged(); }
        }

        // Constructors
        public AdvantageViewModel()
        {
            PlayerAdvantageList = new ObservableCollection<ActiveListedAdvantage>();
            AdvantageList = new AdvantageList();

            AddAdvantageCommand = new DelegateCommand(x => AddAdvantageExecute(), x => AddAdvantageCanExecute());
            RemoveAdvantageCommand = new DelegateCommand(x => RemoveAdvantageExecute(), x => RemoveAdvantageCanExecute());
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event Action<ActiveListedAdvantage> AdvantageAddedEvent;
        private void OnAdvantageAdded(ActiveListedAdvantage x)
        {
            AdvantageAddedEvent?.Invoke(x);
        }

        // Commands
        public DelegateCommand AddAdvantageCommand { get; set; }
        public void AddAdvantageExecute()
        {
            var x = new ActiveListedAdvantage(SelectedItem);
            if(!PlayerAdvantageList.Any(p => p.AdvantageModel.Name == SelectedItem.Name))
            {
                PlayerAdvantageList.Add(x);
                OnAdvantageAdded(x);
                AddAdvantageCommand.RaiseCanExecuteChanged();
            }            
        }
        private bool AddAdvantageCanExecute() { return SelectedItem != null && !PlayerAdvantageList.Any(p => p.AdvantageModel.Name == SelectedItem.Name); }

        public DelegateCommand RemoveAdvantageCommand { get; set; }
        public void RemoveAdvantageExecute()
        {
            PlayerAdvantageList.Remove(SelectedItemRM);
            OnAdvantageAdded(null);
        }
        private bool RemoveAdvantageCanExecute() { return SelectedItemRM != null; }
    }

    /// <summary>
    /// Active Listed Advantage
    /// </summary>
    public class ActiveListedAdvantage : INotifyPropertyChanged
    {
        public AdvantageModel AdvantageModel { get; set; }

        private int _TotalPoint { get; set; }
        public int TotalPoint { get { return _TotalPoint; } set { _TotalPoint = value; OnPointChanged(value);  OnPropertyChanged(); } }

        private int _RankLevel { get; set; }
        public int RankLevel { get { return _RankLevel; } set { _RankLevel = value; OnPropertyChanged(); } }

        public ActiveListedAdvantage(AdvantageModel advantage)
        {
            AdvantageModel = advantage;
            TotalPoint = AdvantageModel.PtCostPerLvl;
            RankLevel = 1;

            IncAdvantageRankCommand = new DelegateCommand(x => IncRankExecute(), x => IncRankCanExecute());
            DecAdvantageRankCommand = new DelegateCommand(x => DecRankExecute(), x => DecRankCanExecute());
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event Action<int> PointChangedEvent;
        public void OnPointChanged(int x)
        {
            PointChangedEvent?.Invoke(x);
        }

        // Commands
        public DelegateCommand IncAdvantageRankCommand { get; set; }
        public DelegateCommand DecAdvantageRankCommand { get; set; }

        private void IncRankExecute() { RankLevel += 1; CalcTotalPoints(); DecAdvantageRankCommand.RaiseCanExecuteChanged(); }
        private bool IncRankCanExecute() { return AdvantageModel.CanLevel == "Has Rank"; }

        private void DecRankExecute() { RankLevel -= 1; CalcTotalPoints(); DecAdvantageRankCommand.RaiseCanExecuteChanged(); }
        private bool DecRankCanExecute() { return AdvantageModel.CanLevel == "Has Rank" && RankLevel > 1; }

        private void CalcTotalPoints() { TotalPoint = AdvantageModel.PtCostPerLvl * RankLevel; }
    }
}
