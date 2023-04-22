using System;
using System.Collections.Generic;
using System.Text;
using GroupsStudents01.ViewModels.Base;
using GroupsStudents01.Models;
using System.Windows.Automation.Peers;

          
namespace GroupsStudents01.ViewModels
{    
    internal class GroupDetailViewModel : ViewModel
    {
        #region Group
        private Group _group;

        public Group Group
        {
            get => _group;
            set => Set(ref _group, value);
        }
        #endregion

        public GroupDetailViewModel(Group group)
        {
            _group = group;
        }
    }
}
