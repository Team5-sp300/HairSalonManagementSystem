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
            width = 600;
            height=400;
            Initialize();
        }

        public void setAppointment(String[] date, String[] time, String[] description, int[] duration)
        {
            bookingDetails = new string[date.Length, 4];
            for (int i = 0; i < date.Length; i++)
            {
                bookingDetails[i, 0] = description[i];
                bookingDetails[i, 1] = date[i];
                bookingDetails[i, 2] = time[i];
                bookingDetails[i, 3] = duration[i].ToString();
            }

            addAppointments();
        }

        public void setAppointment(string[,] bookingDetails)
        {
            this.bookingDetails = new string[bookingDetails.GetLength(0), bookingDetails.GetLength(1)];
            Array.Copy(bookingDetails, this.bookingDetails, bookingDetails.Length);
            addAppointments();
        }

        private void addAppointments()
        {
            int k = 0;
            for (int j = 0; j < bookingDetails.GetLength(0); j++)
            {
                for (int i = 0; i < dates.Length; i++)
                {

                    if (bookingDetails[j, 1].Equals(dates[i]))
                    {
                        for (int m = 0; m < times.Length; m++)
                        {
                            if (bookingDetails[j, 2].Equals(times[m]))
                            {
                                if (Int32.Parse(bookingDetails[j, 3]) == 2)
                                {
                                    k = i + 1;
                                    cells[i + 1, m].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m + 1].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m + 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m].Text = bookingDetails[j, 2] + " \n" + bookingDetails[j, 0];
                                }
                                else
                                {
                                    k = i + 1;
                                    cells[k, m].BackColor = System.Drawing.SystemColors.MenuHighlight;
                                    cells[k, m].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    cells[k, m].Text = bookingDetails[j, 2] + " \n" + bookingDetails[j, 0];
                                }
                            }
                        }
                    }
                }
            }
        }

        public void getCurrentDate()
        {
            int weekNo = weeknum;
            DateTime startOfWeek = DateTime.Today.AddDays(
      (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
      (int)DateTime.Today.DayOfWeek + 1 + weekNo);
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i] = startOfWeek.AddDays(i).ToString("dd/MM");
            }
        }


        public void setWeekNo(int number)
        {
            weeknum = number * 7;
            getCurrentDate();
            setHeaders();
            setCells();
            addAppointments();
        }

        public void setHeaders()
        {
            for (int i = 0; i < 5; i++)
            {
                headersColumm[i + 1].Text = dates[i];

            }
        }

        public void setCells()
        {
            for (int j = 1; j <= rows; j++)
            {
                for (int i = 1; i <= colums; i++)
                {
                    cells[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    cells[i, j].Text = "";
                    if (i % 2 == 1)
                    {
                        cells[i, j].BackColor = System.Drawing.SystemColors.ButtonFace;
                    }
                    else
                    {
                        cells[i, j].BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        public void redraws(int wth,int hght)
        {
            width = wth;
            height = hght;
            for (int i = 0; i < cells.GetLength(0); i++)
            {

                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Controls.Remove(this.cells[i, j]);
                }
            }

            for (int i = 0; i < headersColumm.Length; i++)
            {
                Controls.Remove(headersColumm[i]);
            }

            for (int i = 0; i < headersRow.Length; i++)
            {
                Controls.Remove(headersRow[i]);
            }
            Initialize();
            addAppointments();
        }

        private void Initialize()
        {
            getCurrentDate();
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(width, height);
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
                        headersRow[0]=header;
                    }
                    else if (j == 0 && i != 0)
                    {
                        header = new Label();
                        header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        header.Location = new System.Drawing.Point(((i * yInterval) - yheader - (int)errorCorrection), j * xInterval);
                        header.Name = "Header" + i;
                        header.Size = new System.Drawing.Size(yInterval, xheader);
                        header.Text = days[i];
                        header.Text = dates[k++];
                        header.Font = new System.Drawing.Font("Arial", 11.25F);
                        header.TextAlign = ContentAlignment.TopCenter;
                        header.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        headersColumm[i] = header;
                        this.Controls.Add(this.headersColumm[i]);
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
                        headersRow[j] = header;
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

        private int width;
        private int height;
        private Label header;
        private Label cell;
        private String[] days = new String[] { "", "Mon", "Tues", "Wed", "Thu", "Fri", "Sat", "Sun" };
        private String[] times = new String[] { "", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
        private int y, x;
        private int yheader, xheader;
        private int yInterval, xInterval;
        private int rows, colums;
        private Label[,] cells = new Label[20, 20];
        private Label[] headersColumm = new Label[7];
        private Label[] headersRow = new Label[10];
        //private List<DateTime> dates;
        private int weeknum = 0;
        private string[] dates = new string[7];
        string[,] bookingDetails;
        //private String[] appointments;
        //private String[] time;
    }
}
