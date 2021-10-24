using Project_week05.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_week05
{
    public partial class Form1 : Form
    {
        List<Tick> Ticks;
        PortfolioEntities context = new PortfolioEntities();
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        List<decimal> Profit = new List<decimal>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();

            int interval = 30;
            DateTime startDate = (from x in Ticks select x.TradingDay).Min();
            DateTime finishDate = new DateTime(2016, 12, 30);
            TimeSpan z = finishDate-startDate;
            for (int i = 0; i < z.Days - interval; i++)
            {
                decimal p = GetPortfolioValue(startDate.AddDays(i + interval))
                          - GetPortfolioValue(startDate.AddDays(i));
                Profit.Add(p);
                Console.WriteLine(i + "" + p);
            }

            var profitSorted = (from x in Profit
                                orderby x
                                select x).ToList();

            MessageBox.Show(profitSorted[profitSorted.Count() / 5].ToString());
        }
        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim() && date <= x.TradingDay
                            select x).First();
                value += (decimal)last.Price * item.Volume;
            }

            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sf.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sf.FileName))
                {
                    sw.WriteLine("Időszak\tNyereség");
                    for (int i = 0; i < Profit.Count; i++)
                    {
                        sw.WriteLine((i + 1).ToString() + "\t" + Profit[i]);
                    }
                }
            }
        }
    }
}
