using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowAnswers.Wpf
{

    partial class PersonVM : ObservableObject
    {
        [ObservableProperty]
        private bool isSelected = false;
    }


    partial class TeacherVM : PersonVM
    {
        public TeacherVM()
        {
            PropertyChanged += TeacherVM_PropertyChanged;
        }

        private void TeacherVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IsSelected)) return;
            // do stuff
        }
    }
}
