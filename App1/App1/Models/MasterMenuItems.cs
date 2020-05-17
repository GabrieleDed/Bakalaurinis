using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Models
{
    class MasterMenuItems
    {
        public string Title { get; set; }
        public string IconSource{ get; set; }
        public Color BackgroundColor{ get; set; }
        public Type TargetType{ get; set; }

        public  MasterMenuItem(string Title, string IconSource, Color color, Type target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = target;
        }
    }
}
