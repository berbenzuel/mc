using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.services;
using mc.services.FSListServices;


namespace mc.Objects
{
    public class FSRow : ConsoleGraphicsObject.ConsoleObject
    {
        private Label NameLabel {  get; set; }
        private Label SizeLabel {  get; set; }
        private Label DateLabel {  get; set; }

        private Size bytesize { get; set; } = new Size(7, 1);
        private Size datesize { get; set; } = new Size(13, 1);
        private Size namesize => new Size(Size.Width - bytesize.Width - datesize.Width, 1);

        private IFSItem fsitem { get; set; }
        private bool isupdir { get; set; }

        private string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        


        public FSRow(IFSItem fsitemin, bool isupdir = false)
        {
            fsitem = fsitemin;
            this.isupdir = isupdir;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.DarkBlue;

            NameLabel = new Label(this.ForegroundColor, this.BackgroundColor);
            SizeLabel = new Label(this.ForegroundColor, this.BackgroundColor);
            DateLabel = new Label(this.ForegroundColor, this.BackgroundColor);

        }

        public override void Draw()
        {
            base.Draw();
            NameLabel.Draw();
            SizeLabel.Draw();
            DateLabel.Draw();
        }

        public override void SetUp(Point location, Size size)
        {
                base.SetUp(location, size);

                NameLabel.SetUp(new Point(Location.X, Location.Y), namesize);
                SizeLabel.SetUp(new Point(Location.X + namesize.Width, Location.Y), bytesize);
                DateLabel.SetUp(new Point(Location.X + namesize.Width + bytesize.Width, Location.Y), datesize);

                NameLabel.SetText(NameBuilder());
                SizeLabel.SetText(SizeBuilder());
                DateLabel.SetText(DateBuilder());    
        }

        public override void Erease()
        {
            NameLabel.Erease();
            SizeLabel.Erease();
            DateLabel.Erease();
        }

        public void SetTextColor(ConsoleColor background, ConsoleColor foreground)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
            
            NameLabel.SetForegroundColor(foreground);
            SizeLabel.SetForegroundColor(foreground);
            DateLabel.SetForegroundColor(foreground);

            NameLabel.SetBackgroundColor(background);
            SizeLabel.SetBackgroundColor(background);
            DateLabel.SetBackgroundColor(background);
        }

        private string DateBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('│');
            sb.Append(months[fsitem.lastmodifieddate.Month - 1]);
            sb.Append(" ");
            if (fsitem.lastmodifieddate.Day < 10)
            {
                sb.Append(" ");

            }
            sb.Append(fsitem.lastmodifieddate.Day);
            sb.Append(" ");
            if (fsitem.lastmodifieddate.Hour < 10)
            {
                sb.Append("0");
            }
            sb.Append(fsitem.lastmodifieddate.Hour);
            sb.Append(':');
            if (fsitem.lastmodifieddate.Minute < 10)
            {
                sb.Append("0");
            }
            sb.Append(fsitem.lastmodifieddate.Minute);


            return sb.ToString();
        }
        private string SizeBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('│');
            sb.Append(fsitem.size.PadRight(bytesize.Width, ' '));
            return sb.ToString();
        }

        private string NameBuilder()
        {
            string prefix = "";
            if (isupdir)
            {
                return "/..";
            }
            else
            {
                //prefix = DataService.GetPrefix(fsitem);
            }

            StringBuilder sb = new StringBuilder();

            if (fsitem.name.Length + prefix.Length <= namesize.Width)
            {
                sb.Append(prefix);
                sb.Append(fsitem.name.PadRight(namesize.Width));
                return sb.ToString();
            }
            sb.Append(prefix);
            sb.Append(fsitem.name.Substring(0, namesize.Width - prefix.Length -1));
            sb.Append('~');
            return sb.ToString();


        }


    }
}
