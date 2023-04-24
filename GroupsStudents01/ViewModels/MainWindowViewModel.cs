using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
//using GroupsStudents01.Infrastructure.Commands;
using GroupsStudents01.Models;

using GroupsStudents01.ViewModels.Base;
using GroupsStudents01.ViewModels;

using GroupsStudents01.Commands;


namespace GroupsStudents01.ViewModels
{    
    internal class MainWindowViewModel : ViewModel
    {
        public ObservableCollection<GroupDetailViewModel> Groups { get; set; }

        #region SelectedGroup
        private GroupDetailViewModel _SelectedGroup;

        public GroupDetailViewModel SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                Set(ref _SelectedGroup, value);

                OnShowGroupDetailViewCommandExecuted(value);
            }
        }
        #endregion

        #region Заголовок окна. Для теста подключения View + ViewModel
        private string _Title = "Группы-Студенты";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;            
            set => Set(ref _Title, value);
        }

        #endregion

        #region CurrentModel : ViewModel - Текущая дочерняя модель-представления

        /// <summary>Текущая дочерняя модель-представления</summary>
        private ViewModel _CurrentModel;

        /// <summary>Текущая дочерняя модель-представления</summary>
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }

        #endregion

        
        #region Command ShowGroupDetailViewCommand2 - Отобразить представление группы
        private RelayCommand showGroupDetailViewCommand2;
        public RelayCommand ShowGroupDetailViewCommand2
        {
            get
            {
                return showGroupDetailViewCommand2 ??
                  (showGroupDetailViewCommand2 = new RelayCommand(obj =>
                  {
                      // Group group = obj as _SelectedGroup;
                      OnShowGroupDetailViewCommandExecuted(SelectedGroup);
                  }));
            }
        }


        private void OnShowGroupDetailViewCommandExecuted(GroupDetailViewModel selectedGroup)
        {
            CurrentModel = selectedGroup;
            Debug.Writline("=== === === ===");
            Debug.Writline(selectedGroup.Description);
            Debug.Writline("=== === === ===");
        }
        #endregion


        public IEnumerable<GroupDetailViewModel> LoadData()
        {
            var groups = Enumerable.Range(1, 20).Select(
                i => new GroupDetailViewModel
                {
                    Id = i,
                    Name = $"Группа {i}",
                    Description = $"Description {i}"
                });

            return groups;
        }

        /* ---------------------------------- */
        #region Конструктор        
        public MainWindowViewModel()
        {   
            Groups = new ObservableCollection<GroupDetailViewModel>(LoadData());        
        }
        #endregion
        /* ---------------------------------- */

    }
}
