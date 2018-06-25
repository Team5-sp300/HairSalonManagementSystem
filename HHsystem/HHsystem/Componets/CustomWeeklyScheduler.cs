using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Componets
{
    class WeeklyScheduler : Panel
    {
        public WeeklyScheduler()
        {
            rows = 9;
            colums = 5;
            Initialize();
        }

        public void addAppointment(String[] date, String[] time, String[] description,int [] duration)
        {
            int k = 0;

            for (int j = 0; j < date.Length; j++)
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    if (date[j].Equals(dates[i].ToString("dd/MM")))
                    {
                        for (int m = 0; m < times.Length; m++)
                        {
                            if (time[j].Equals(times[m]))
                            {
                                if ( duration[j] == 2)
                                {
                                    k = i + 1;
                                    cells[i+1, m].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m + 1].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m + 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m].Text = time[j] + " \n" + description[j];
                                }
                                else
                                {
                                    k = i + 1;
                                    cells[k, m].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m].Text = time[j] + " \n" + description[j];
                                }
                            }
                        }
                    }
                }
            }
        }

        public void getCurrentDate()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(
      (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
      (int)DateTime.Today.DayOfWeek);

            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(7);
            var numDays = (int)((endDate - startDate).TotalDays);
            dates = Enumerable.Range(0, numDays).Select(x => startOfWeek.AddDays(x)).ToList();
        }

        private void Initialize()
        {
            getCurrentDate();
            cells = new Label[20, 20];
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(600, 400);
            y = (this.Width) / (colums + 1);
            x = (this.Height) / (rows + 1);
            yheader = (int)(y * 0.5);
            xheader = (int)(x * 0.5);
            yInterval = y + (yheader / colums);
            xInterval = x + (xheader / rows);
            int k = 0;
            double errorCorrection = yInterval - (yheader * 2);

            for (int j = 0; j <= rows; j++)
            {
                for (int i = 0; i <= colums; i++)
                {
                    if (j == 0 && i == 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.Color.White;
                        header.Name = "Header" + i;
                        header.Text = "";
                        header.Location = new System.Drawing.Point(0, 0);
                        header.Size = new System.Drawing.Size(yheader, xheader);
                        this.Controls.Add(this.header);
                    }
                    else if (j == 0 && i != 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        // header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        header.Location = new System.Drawing.Point(((i * yInterval) - yheader - (int)errorCorrection), j * xInterval);
                        header.Name = "Header" + i;
                        header.Size = new System.Drawing.Size(yInterval, xheader);
                        header.Text = days[i];
                        header.Text = dates[k++].ToString("ddd dd/MM");
                        header.Font = new System.Drawing.Font("Arial", 11.25F);
                        header.TextAlign = ContentAlignment.TopCenter;
                        header.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.Controls.Add(this.header);
                    }
                    else if (i == 0 && j != 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        //     header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        header.Location = new System.Drawing.Point(i * y, (j * xInterval) - xheader);
                        header.Name = "Header" + i;
                        header.Size = new System.Drawing.Size(yheader, xInterval);
                        header.Text = times[j];
                        header.AutoSize = false;
                        header.TextAlign = ContentAlignment.TopLeft;
                        header.Font = new System.Drawing.Font("Arial", 11.25F);
                        header.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.Controls.Add(this.header);
                    }
                    else
                    {
                        cell = new Label();
                        //  cell.BackColor = System.Drawing.SystemColors.ButtonFace;
                        cell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        cell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        cell.Location = new System.Drawing.Point(i * yInterval - yheader - (int)errorCorrection, j * xInterval - xheader);
                        cell.Name = "Cell" + i;
                        cell.Size = new System.Drawing.Size(yInterval, xInterval);
                        cell.Text = "";
                        cell.Font = new System.Drawing.Font("Arial", 11.25F);
                        cell.ForeColor = System.Drawing.Color.White;
                        this.Controls.Add(this.cell);
                        cells[i, j] = cell;
                        if (i % 2 == 1)
                        {
                            cell.BackColor = System.Drawing.SystemColors.ButtonFace;
                        }
                        else
                        {
                            cell.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }
        }


        private Label header;
        private Label cell;
        private String[] days = new String[] { "", "Mon", "Tues", "Wed", "Thu", "Fri", "Sat", "Sun" };
        private String[] times = new String[] { "", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
        private int y, x;
        private int yheader, xheader;
        private int yInterval, xInterval;
        private int rows, colums;
        private Label[,] cells;
        private List<DateTime> dates;
        //private String[] appointments;
        //private String[] time;
    }
}
