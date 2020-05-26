using GcInWorkWinForm.Gc;
using GcInWorkWinForm.Threads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GcInWorkWinForm
{
    public partial class Form1 : Form
    {
        ChangeTotalMemory changeTotalMemory;

        public Form1()
        {
            InitializeComponent();

            changeTotalMemory = new ChangeTotalMemory(value => textBox1.Text = value.ToString());
            changeTotalMemory.Change();

            var btnGcObservale = Observable.FromEventPattern(btnGc, "Click");
            var btnThreadObservale = Observable.FromEventPattern(btnThreads, "Click");

            btnGcObservale
                .Subscribe(_ =>
                {
                    new GcForm().ShowDialog();
                });

            btnThreadObservale
                .Subscribe(_ =>
                {
                    new ThreadForm().ShowDialog();
                });

            var btnClickObservable = Observable.FromEventPattern(btnTest, "Click");                    
            //var btnClickObservable = Observable.FromEventPattern<EventArgs>(btnTest, "ButtonClick");

            var sub = btnClickObservable
                .Subscribe(a => {
                    var ee = new int[10000];
                    changeTotalMemory.Change();
                });
        }
    }
}
