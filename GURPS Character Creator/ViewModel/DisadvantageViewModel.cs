using GURPS_Character_Creator.Models;
using GURPS_Character_Creator.ViewModel.Command;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GURPS_Character_Creator.ViewModel
{
    public class DisadvantageViewModel : INotifyPropertyChanged
    {
        // Properties
        public ObservableCollection<ActiveListedDisadvantage> PlayerDisadvantageList { get; set; }
        public DisadvantageList DisadvantageList { get; set; }

        private DisadvantageModel _SelectedItem;
        public DisadvantageModel SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; AddDisadvantageCommand.RaiseCanExecuteChanged(); DescriptionItem = value; }
        }

        private ActiveListedDisadvantage _SelectedItemRM;
        public ActiveListedDisadvantage SelectedItemRM
        {
            get { return _SelectedItemRM; }
            set { _SelectedItemRM = value; RemoveDisadvantageCommand.RaiseCanExecuteChanged(); DescriptionItem = value?.DisadvantageModel; }
        }

        private DisadvantageModel _DescriptionItem { get; set; }
        public DisadvantageModel DescriptionItem
        {
            get { return _DescriptionItem; }
            set { _DescriptionItem = value; OnPropertyChanged(); }
        }

        // Constructors
        public DisadvantageViewModel()
        {
            PlayerDisadvantageList = new ObservableCollection<ActiveListedDisadvantage>();
            DisadvantageList = new DisadvantageList();

            AddDisadvantageCommand = new DelegateCommand(x => AddDisadvantageExecute(), x => AddDisadvantageCanExecute());
            RemoveDisadvantageCommand = new DelegateCommand(x => RemoveDisadvantageExecute(), x => RemoveDisadvantageCanExecute());
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event Action<ActiveListedDisadvantage> DisadvantageAddedEvent;
        private void OnDisadvantageAdded(ActiveListedDisadvantage x)
        {
            DisadvantageAddedEvent?.Invoke(x);
        }

        // Commands
        public DelegateCommand AddDisadvantageCommand { get; set; }
        public void AddDisadvantageExecute()
        {
            if(!PlayerDisadvantageList.Any(p => p.DisadvantageModel.Name == SelectedItem.Name))
            {
                var x = new ActiveListedDisadvantage(SelectedItem);
                PlayerDisadvantageList.Add(x);
                OnDisadvantageAdded(x);
                AddDisadvantageCommand.RaiseCanExecuteChanged();
            }
        }
        private bool AddDisadvantageCanExecute() { return SelectedItem != null && !PlayerDisadvantageList.Any(p => p.DisadvantageModel.Name == SelectedItem.Name); }

        public DelegateCommand RemoveDisadvantageCommand { get; set; }
        public void RemoveDisadvantageExecute()
        {
            PlayerDisadvantageList.Remove(SelectedItemRM);
            OnDisadvantageAdded(SelectedItemRM);
        }
        private bool RemoveDisadvantageCanExecute() { return SelectedItemRM != null; }
    }

    public class ActiveListedDisadvantage : INotifyPropertyChanged
    {
        // Properties
        public DisadvantageModel DisadvantageModel { get; set; }
        private int _TotalPoint { get; set; }
        public int TotalPoint { get { return _TotalPoint; } set { _TotalPoint = value; OnPointChanged(value); OnPropertyChanged(); } }

        // Constructor
        public ActiveListedDisadvantage(DisadvantageModel disadvantage)
        {
            DisadvantageModel = disadvantage;

            IncDisadvantageRankCommand = new DelegateCommand(x => IncRankExecute(), x => IncRankCanExecute());
            DecDisadvantageRankCommand = new DelegateCommand(x => DecRankExecute(), x => DecRankCanExecute());
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

        // Commands
        public DelegateCommand IncDisadvantageRankCommand { get; set; }
        private void IncRankExecute() { DecDisadvantageRankCommand.RaiseCanExecuteChanged(); }
        private bool IncRankCanExecute() { return false; }

        public DelegateCommand DecDisadvantageRankCommand { get; set; }
        private void DecRankExecute() { DecDisadvantageRankCommand.RaiseCanExecuteChanged(); }
        private bool DecRankCanExecute() { return false; }
    }
}
