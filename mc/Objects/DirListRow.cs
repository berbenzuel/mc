using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Objects.DirViewerServices;

namespace mc.Objects
{
    public class DirListRow : ConsoleGraphicsObject.ConsoleGraphicsObject
    {
        private Label NameLabel {  get; set; }
        private Label SizeLabel {  get; set; }
        private Label DateLabel {  get; set; }

        private Size bytesize { get; set; } = new Size(8, 1);
        private Size datesize { get; set; } = new Size(13, 1);
        private Size namesize => new Size(Size.Width - bytesize.Width - datesize.Width, 1);

        private string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private DataServiceResult dataServiceResult { get; set; }


        public DirListRow(DataServiceResult data)
        {
            this.dataServiceResult = data;
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

                NameLabel.SetText(NameBuilder(dataServiceResult));
                SizeLabel.SetText(SizeBuilder(dataServiceResult.Size));
                DateLabel.SetText(DateBuilder(dataServiceResult.Date));    
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

        private string DateBuilder(DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('│');
            sb.Append(months[date.Month - 1]);
            sb.Append(" ");
            if (date.Day < 10)
            {
                sb.Append(" ");

            }
            sb.Append(date.Day);
            sb.Append(" ");
            if (date.Hour < 10)
            {
                sb.Append("0");
            }
            sb.Append(date.Hour);
            sb.Append(':');
            if (date.Minute < 10)
            {
                sb.Append("0");
            }
            sb.Append(date.Minute);


            return sb.ToString();
        }
        private string SizeBuilder(string size)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('│');
            sb.Append(size.PadRight(bytesize.Width, ' '));
            return sb.ToString();
        }

        private string NameBuilder(DataServiceResult row)
        {
            StringBuilder sb = new StringBuilder();
            if (row.Name.Length + 1 <= namesize.Width)
            {
                sb.Append(row.Prefix);
                sb.Append(row.Name.PadRight(namesize.Width));
                return sb.ToString();
            }
            sb.Append(row.Prefix);
            sb.Append(row.Name.Substring(0, namesize.Width - 2));
            sb.Append('~');
            return sb.ToString();


        }


    }
}
