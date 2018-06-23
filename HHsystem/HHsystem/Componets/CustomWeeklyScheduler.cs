using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Componets
{
    class CustomWeeklyScheduler : Panel
    {
        public CustomWeeklyScheduler()
        {
            rows = 9;
            colums = 7;
            Initialize();
        }

        private void Initialize()
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(600, 400);
            x = (this.Width) / (colums+1);
            y = (this.Height) / (rows+1);


            for (int j = 0; j <= rows; j++)
            {
                for (int i = 0; i <= colums; i++)
                {

                    if (j == 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        header.Location = new System.Drawing.Point(i * x, j * y);
                        header.Name = "Header" + i;
                        header.Size = new System.Drawing.Size(x, y);
                        header.Text = days[i];
                        header.Font = new System.Drawing.Font("Arial", 11.25F);
                        header.TextAlign = ContentAlignment.BottomCenter;
                        header.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.Controls.Add(this.header);
                    }
                    if (i == 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        header.Location = new System.Drawing.Point(i * x, j * y);
                        header.Name = "Header" + i;
                        header.Size = new System.Drawing.Size(x, y);
                        header.Text = times[j];
                        header.AutoSize = false;
                        header.TextAlign = ContentAlignment.TopRight;
                        header.Font = new System.Drawing.Font("Arial", 11.25F);
                        header.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.Controls.Add(this.header);
                    }
                    else
                    {
                        cell = new CustomLabel();
                        cell.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                       // cell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        cell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        cell.Location = new System.Drawing.Point((i * x), (j * y));
                        cell.Name = "Cell" + i;
                        cell.Size = new System.Drawing.Size(x, y);
                        cell.Text = "";
                        cell.Font = new System.Drawing.Font("Arial", 11.25F);
                        cell.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.Controls.Add(this.cell);
                    }
                }
            }
        }

        private Label header;
        private CustomLabel cell;
        private String[] days = new String[] { "", "Mon", "Tues", "Wed", "Thu", "Fri", "Sat", "Sun" };
        private String[] times = new String[] { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
        private int x, y;
        private int rows, colums;
    }
}
