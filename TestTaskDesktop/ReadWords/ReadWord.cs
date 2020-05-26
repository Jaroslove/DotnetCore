using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTaskDesktop.ReadWords
{
    public partial class ReadWord : Form
    {
        public ReadWord()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            double totalValue = 0;

            var cancelationTokenSource = new CancellationTokenSource();
            var progress = new Progress<int>();

            progress.ProgressChanged += Progress_ProgressChanged;

            var channel = new Channel<StringContainer>();

            var counter = new Counter(progress, cancelationTokenSource.Token);

            var files = Directory.GetFiles("readWords");

            var _ = Task.Run( async() => {
                for (int i = 0; i < files.Count(); i++)
                {
                    var text = await Task.Run(() => File.ReadAllText(files[i]));
                    channel.Write(new StringContainer { Data = text, Number = i, Total = files.Count()});
                }

                channel.Complete();
            });

            while (!channel.IsComplete())
            {
                var data = await channel.ReadAsync();
                totalValue += await counter.CountAsync(data.Data, data.Total, data.Number);
            }

            textBox1.Text = totalValue.ToString();
        }

        private void Progress_ProgressChanged(object sender, int e)
        {
            progressBar1.Value = e;
        }
    }
}
