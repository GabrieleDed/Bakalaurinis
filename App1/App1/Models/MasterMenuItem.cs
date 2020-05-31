using System;
using Xamarin.Forms;

namespace App1.Models
{
    class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSource, Color color, Type target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = target;
        }
    }
}
