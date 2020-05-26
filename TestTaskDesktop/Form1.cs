using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using TestTaskDesktop.Helpers;
using TestTaskDesktop.ReadWords;
using TestTaskDesktop.Records;

namespace TestTaskDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var syncContextBefore = SynchronizationContext.Current;
            var result = await Task.Run(() => "Hi!").ConfigureAwait(true);
            var syncContext = SynchronizationContext.Current;
            textBox1.Text = result;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string result = "";

            result = Task.Run(() => Delay()).GetAwaiter().GetResult();

            MessageBox.Show(result);
        }

        private async Task<string> Delay()
        {
            await Task.Delay(5000);

            return "Hi";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var observable = Observable
                .FromEvent<MouseEventHandler, MouseEventArgs>(
                        handler => { MouseEventHandler mHanlder = (s, ev) => handler(ev); return mHanlder; },
                        ev => MouseMove += ev, 
                        ev => MouseMove -= ev);

            observable
                .Subscribe(o => textBox1.Text = $"X {o.X} Y {o.Y}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Set the bitmap object to the size of the screen
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            // Create a graphics object from the bitmap
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            // Take the screenshot from the upper left corner to the right bottom corner
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            // Save the screenshot to the specified path that the user has chosen
            bmpScreenshot.Save("screen.png", ImageFormat.Png);            
            // Show the form again
            this.Show();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var ex = new ExtTask();

            var one = ex.One();
            var two = ex.Two();
            var three = ex.Three();

            Task tasksA = null;

            try
            {
                Task[] tasks = new Task[3];

                tasks[0] = one;
                tasks[1] = two;
                tasks[2] = three;

                tasksA = Task.WhenAll(tasks);

                await tasksA;
            }
            catch (Exception exx)
            {                
                var smth = tasksA;
            }
        }

        CancellationTokenSource cts = new CancellationTokenSource();

        private void button5_Click(object sender, EventArgs e)
        {
            var ctsToken = cts.Token;

            var throwIf = new ActionBlock<int>(n => {
                Thread.Sleep(1000);

                ctsToken.ThrowIfCancellationRequested();

                var s = Thread.CurrentThread.ManagedThreadId.ToString();

                Invoke((MethodInvoker)(() =>
                {
                    dataFlowTxt.Text = n.ToString() + " thread is " + s + " and now " + Thread.CurrentThread.ManagedThreadId.ToString();    
                }));                
            });            

            try
            {
                var i = 0;

                while (i < 20)
                {
                    throwIf.Post(i++);                    
                }

                dataFlowTxt.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            }
            catch (AggregateException ex)
            {
                ex.Handle(o => {
                    Console.WriteLine(o.Message);
                    return true;
                });
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        Recorder rec;
        ShowRecord showRec;

        private void button7_Click(object sender, EventArgs e)
        {
            rec = new Recorder(new RecorderParams("out.avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));

            showRec = new ShowRecord(new CancellationTokenSource(), i => label1.Text = i.ToString());

            showRec.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            showRec.Stop();

            rec.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var readWordForm = new ReadWord();
            readWordForm.ShowDialog();
        }
    }
}
