using GURPS_Character_Creator.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GURPS_Character_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel main = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = main;
            MouseLeftButtonDown += (x, y) => { Keyboard.ClearFocus(); SkillsView.DGPlayerSkillUC.DGPlayerSkillList.SelectedIndex = -1; };

            SkillsView.DGSkillList.ItemsSource = main.SkillVM.SkillList.SkillsDict.Values;
            SkillsView.DGSkillList.MouseDoubleClick += (x,y) => { main.SkillVM.AddSkillExecute(); };
            SkillsView.DGPlayerSkillUC.DGPlayerSkillList.DataContext = main.SkillVM;
            SkillsView.DGPlayerSkillUC.DGPlayerSkillList.ItemsSource = main.SkillVM.PlayerSkillList;
            

            AdvantagesView.DGAdvantageList.ItemsSource = main.AdvantageVM.AdvantageList.AdvantageDict.Values;
            AdvantagesView.DGAdvantageList.MouseDoubleClick += (x, y) => { main.AdvantageVM.AddAdvantageExecute(); };
            AdvantagesView.DGPlayerAdvantageUC.DGPlayerAdvantageList.DataContext = main.AdvantageVM;
            AdvantagesView.DGPlayerAdvantageUC.DGPlayerAdvantageList.ItemsSource = main.AdvantageVM.PlayerAdvantageList;

            DisadvantagesView.DGDisadvantageList.ItemsSource = main.DisadvantageVM.DisadvantageList.DisadvantageDict.Values;
            DisadvantagesView.DGDisadvantageList.MouseDoubleClick += (x, y) => { main.DisadvantageVM.AddDisadvantageExecute(); };
            DisadvantagesView.DGPlayerDisadvantageUC.DGPlayerDisadvantageList.DataContext = main.DisadvantageVM;
            DisadvantagesView.DGPlayerDisadvantageUC.DGPlayerDisadvantageList.ItemsSource = main.DisadvantageVM.PlayerDisadvantageList;

            LabelDescription.DataContext = main.SkillVM;
            TabControlBacon.SelectionChanged += ChangeDescriptionDataContext;
        }

        public void ChangeDescriptionDataContext(object sender, SelectionChangedEventArgs e)
        {
            switch(TabControlBacon.SelectedIndex)
            {
                case 0:
                    LabelDescription.DataContext = main.SkillVM;
                    break;
                case 1:
                    LabelDescription.DataContext = main.AdvantageVM;
                    break;
                case 2:
                    LabelDescription.DataContext = main.DisadvantageVM;
                    break;
            }
        }
    }
}
