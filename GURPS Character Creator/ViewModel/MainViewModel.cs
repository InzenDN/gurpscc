using GURPS_Character_Creator.ViewModel.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace GURPS_Character_Creator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Properties
        public SkillViewModel SkillVM { get; set; }
        public AdvantageViewModel AdvantageVM { get; set; }
        public DisadvantageViewModel DisadvantageVM { get; set; }        
        public PlayerStats PlayerStats { get; set; }

        // Constructor
        public MainViewModel()
        {
            SkillVM = new SkillViewModel();
            AdvantageVM = new AdvantageViewModel();
            DisadvantageVM = new DisadvantageViewModel();
            PlayerStats = new PlayerStats();

            SkillVM.SkillAddedEvent += SetUsedSkillPointsEvent;
            AdvantageVM.AdvantageAddedEvent += SetUsedAdvantagePointsEvent;
            DisadvantageVM.DisadvantageAddedEvent += SetUsedDisadvantagePointsEvent;

            AddAttributeCommand = new DelegateCommand(AddAttributeExecute, AddAttributeCanExecute);
            SubAttributeCommand = new DelegateCommand(SubAttributeExecute, SubAttributeCanExecute);
        }

        // Methods
            // Skills
        public void SetUsedSkillPointsEvent(ActiveListedSkill skill)
        {
            if(skill != null)
            {
                skill.PointChangedEvent += SetUsedSkillPoints;
                SetUsedSkillPoints(skill.TotalPoint);
            }
            else
            {
                SetUsedSkillPoints(0);
            }
        }
        public void SetUsedSkillPoints(int x)
        {
            PlayerStats.arrayofpoints[0] = 0;
            foreach(var item in SkillVM.PlayerSkillList)
            {
                PlayerStats.arrayofpoints[0] += item.TotalPoint;
            }
            PlayerStats.CalculateTotalUsedPoints();
        }

            // Advantages
        public void SetUsedAdvantagePointsEvent(ActiveListedAdvantage advantage)
        {
            if(advantage != null)
            {
                advantage.PointChangedEvent += SetUsedAdvantagePoints;
                SetUsedAdvantagePoints(advantage.TotalPoint);
            }
            else
            {
                SetUsedAdvantagePoints(0);
            }
        }
        public void SetUsedAdvantagePoints(int x)
        {
            PlayerStats.arrayofpoints[1] = 0;
            foreach(var item in AdvantageVM.PlayerAdvantageList)
            {
                PlayerStats.arrayofpoints[1] += item.TotalPoint;
            }
            PlayerStats.CalculateTotalUsedPoints();
        }

            // Disadvantages
        public void SetUsedDisadvantagePointsEvent(ActiveListedDisadvantage disadvantage)
        {
            if(disadvantage != null)
            {
                disadvantage.PointChangedEvent += SetUsedDisadvantagePoints; // GOOD
                SetUsedDisadvantagePoints(disadvantage.DisadvantageModel.PtCost);
            }
            else
            {
                SetUsedDisadvantagePoints(0);
            }
        }
        public void SetUsedDisadvantagePoints(int x)
        {
            PlayerStats.arrayofpoints[2] = 0;
            foreach(var item in DisadvantageVM.PlayerDisadvantageList)
            {
                PlayerStats.arrayofpoints[2] += item.DisadvantageModel.PtCost;
            }
            PlayerStats.CalculateTotalUsedPoints();
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Commands
        public DelegateCommand AddAttributeCommand { get; set; }
        public void AddAttributeExecute(object sender)
        {
            switch(((Button)sender).Name)
            {
                case "AddST":
                    PlayerStats.ST += 1;
                    PlayerStats.UnspentPoint -= 10;
                    PlayerStats.UsedPoint += 10;
                    break;
                case "AddHT":
                    PlayerStats.HT += 1;
                    PlayerStats.UnspentPoint -= 10;
                    PlayerStats.UsedPoint += 10;
                    break;
                case "AddDX":
                    PlayerStats.DX += 1;
                    PlayerStats.UnspentPoint -= 20;
                    PlayerStats.UsedPoint += 20;
                    break;
                case "AddIQ":
                    PlayerStats.IQ += 1;
                    PlayerStats.UnspentPoint -= 20;
                    PlayerStats.UsedPoint += 20;
                    break;
            }
        }
        public bool AddAttributeCanExecute(object sender)
        {
            switch(((Button)sender).Name)
            {
                case "AddST":
                case "AddHT":
                    if(PlayerStats.UnspentPoint >= 10)
                        return true;
                    break;
                case "AddDX":
                case "AddIQ":
                    if(PlayerStats.UnspentPoint >= 20)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        public DelegateCommand SubAttributeCommand { get; set; }
        public void SubAttributeExecute(object sender)
        {
            switch(((Button)sender).Name)
            {
                case "SubST":
                    PlayerStats.ST -= 1;
                    PlayerStats.UnspentPoint += 10;
                    PlayerStats.UsedPoint -= 10;
                    break;
                case "SubHT":
                    PlayerStats.HT -= 1;
                    PlayerStats.UnspentPoint += 10;
                    PlayerStats.UsedPoint -= 10;
                    break;
                case "SubDX":
                    PlayerStats.DX -= 1;
                    PlayerStats.UnspentPoint += 20;
                    PlayerStats.UsedPoint -= 20;
                    break;
                case "SubIQ":
                    PlayerStats.IQ -= 1;
                    PlayerStats.UnspentPoint += 20;
                    PlayerStats.UsedPoint -= 20;
                    break;
            }
        }
        public bool SubAttributeCanExecute(object sender)
        {
            switch(((Button)sender).Name)
            {
                case "SubST":
                    if(PlayerStats.ST > 0)
                        return true;               
                    break;
                case "SubHT":
                    if(PlayerStats.HT > 0)
                        return true;
                    break;
                case "SubDX":
                    if(PlayerStats.DX > 0)
                        return true;
                    break;
                case "SubIQ":
                    if(PlayerStats.IQ > 0)
                        return true;
                    break;
            }
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PlayerStats : INotifyPropertyChanged
    {
        // Properties
        private int _MaxPoint { get; set; }
        public int MaxPoint { get { return _MaxPoint; } set { _MaxPoint = value; UnspentPoint = (value - UsedPoint); } }

        private int _MaxDisadvantagePoint { get; set; }
        public int MaxDisadvantagePoint
        {
            get { return _MaxDisadvantagePoint; }
            set
            {
                if(value < 0)
                    _MaxDisadvantagePoint = value;
                else
                    _MaxDisadvantagePoint = -value;
            }
        }

        private int _UsedPoint { get; set; }
        public int UsedPoint { get { return _UsedPoint; } set { _UsedPoint = value; OnPropertyChanged(); } }

        private int _UsedDisadvantagePoint { get; set; }
        public int UsedDisadvantagePoint { get { return _UsedDisadvantagePoint; } set { _UsedDisadvantagePoint = value; OnPropertyChanged(); } }

        private int _UnspentPoint { get; set; }
        public int UnspentPoint { get { return _UnspentPoint; } set { _UnspentPoint = value; OnPropertyChanged(); } }

        private int _ST { get; set; }
        public int ST { get { return _ST; } set { _ST = value; OnPropertyChanged(); } }
        private int _DX { get; set; }
        public int DX { get { return _DX; } set { _DX = value; OnPropertyChanged(); } }
        private int _IQ { get; set; }
        public int IQ { get { return _IQ; } set { _IQ = value; OnPropertyChanged(); } }
        private int _HT { get; set; }
        public int HT { get { return _HT; } set { _HT = value; OnPropertyChanged(); } }

        public int[] arrayofpoints { get; set; }

        // Constructor
        public PlayerStats()
        {
            MaxPoint = 75;
            MaxDisadvantagePoint = -40;
            UsedPoint = 0;
            UsedDisadvantagePoint = 0;
            UnspentPoint = 75;

            ST = 10; DX = 10; IQ = 10; HT = 10;
            arrayofpoints = new int[3];
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // Methods
        //public void SetUsedSkillPoint(int x)
        //{
        //    arrayofpoints[0] = x;
        //    CalculateTotalUsedPoints();
        //}
        //public void SetUsedAdvantagePoint(int x)
        //{
        //    arrayofpoints[1] = x;
        //    CalculateTotalUsedPoints();
        //}
        //public void SetUsedDisadvantagePoint(int x)
        //{
        //    arrayofpoints[2] = x;
        //    CalculateTotalUsedPoints();
        //}

        public void CalculateTotalUsedPoints()
        {
            UsedPoint = 0;
            foreach(var item in arrayofpoints)
            {
                UsedPoint += item;
            }
            UnspentPoint = MaxPoint - UsedPoint - (((ST-10)*10)+((HT-10)*10)+((DX-10)*20)+((IQ-10)*20));
            UsedDisadvantagePoint = arrayofpoints[2];
        }
    }
}
