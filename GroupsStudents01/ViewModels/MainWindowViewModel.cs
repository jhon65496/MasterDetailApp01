using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<Group> Groups { get; }
               
        #region SelectedGroup
        private Group _SelectedGroup;
        
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                Set(ref _SelectedGroup, value);
                OnShowGroupDetailViewCommandExecuted();
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

        #region Command ShowGroupDetailViewCommand - Отобразить представление группы
        private RelayCommand showGroupDetailViewCommand;
        public RelayCommand ShowGroupDetailViewCommand
        {
            get
            {
                return showGroupDetailViewCommand ??
                  (showGroupDetailViewCommand = new RelayCommand(obj =>
                  {
                      // Group group = obj as _SelectedGroup;
                      CurrentModel = new GroupDetailViewModel(SelectedGroup);
                  }));
            }
        }
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
                      OnShowGroupDetailViewCommandExecuted();
                  }));
            }
        }

        
        private void OnShowGroupDetailViewCommandExecuted()
        {
            // CurrentModel = new BookDetailViewModel(_BooksRepository, SelectedBook);
            CurrentModel = new GroupDetailViewModel(SelectedGroup);
        }
        #endregion

        /* ---------------------------------- */
        #region Конструктор        
        public MainWindowViewModel()
        {
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Id = i,
                Name = $"Группа {i}",
                Description = $"Description {i}",
            });

            Groups = new ObservableCollection<Group>(groups);        
        }
        #endregion
        /* ---------------------------------- */

    }
}
