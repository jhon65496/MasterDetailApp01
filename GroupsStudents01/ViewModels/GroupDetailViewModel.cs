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
        private int id;

        public int Id
        {
            get { return id; }
            set => Set(ref id, value);
        }


        private string name;

        public string Name
        {
            get { return name; }
            set => Set(ref name, value);
        }


        private string description;

        public string Description
        {
            get { return description; }
            set => Set(ref description, value);
        }


        public GroupDetailViewModel()
        {

        }
    }
}
