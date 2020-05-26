using PresentationGrab.ImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationGrab
{
    public partial class frmWindowSelect : Form
    {
        public frmWindowSelect()
        {
            InitializeComponent();
            RefreshWins();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshWins();
        }

        private void RefreshWins()
        {
            string[] vals;
            lstWindows.Items.Clear();
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var wds = OpenWindowsGetter.GetOpenWindows();
                vals =  wds.Values.ToArray();
            }
            else
            {
                var wds = OpenWindowsGetter.GetOpenWindows().Where(x => x.Value.Contains(txtFilter.Text));
                vals = wds.Select(x => x.Value).ToArray();
                // Debug.WriteLine(wds.Count());
                // new ListBox.ObjectCollection(lstWindows, );
                // lstWindows.Items.AddRange();
            }
            lstWindows.Items.Clear();
            foreach (var val in vals)
            {
                lstWindows.Items.Add(val);
            }

            //var getBeePair = wds.FirstOrDefault(x => x.Value.Contains("MusicBee"));
            //var p = getBeePair.Key;
            //var im = ImageProcessing.ScreenCapture.CaptureWindow(p);
            //Clipboard.SetImage(im);

            //foreach (var window in wds)
            //{
            //    IntPtr handle = window.Key;
            //    string title = window.Value;

            //    Console.WriteLine("{0}: {1}", handle, title);
            //}
        }

        internal IntPtr retPtr = IntPtr.Zero;

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            retPtr = IntPtr.Zero;
            Close();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();


        private IntPtr GetActiveWindow()
        {
            IntPtr handle = IntPtr.Zero;
            return GetForegroundWindow();
        }

        int cnt = 5;

        private void ctnCurrent_Click(object sender, EventArgs e)
        {
            cnt = 5;
            tmrPick.Enabled = true;
        }

        private void lstWindows_Click(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItem != null)
                return;
            var t = lstWindows.SelectedItem.ToString();
            if (t != null)
            {
                var wds = OpenWindowsGetter.GetOpenWindows().FirstOrDefault(x => x.Value == t).Key;
                retPtr = wds;
            }
        }

        private void tmrPick_Tick(object sender, EventArgs e)
        {
            cnt--;
            lblPtr.Text = cnt.ToString();
            if (cnt == 0)
            {
                retPtr = GetActiveWindow();
                lblPtr.Text = retPtr.ToString();
                tmrPick.Enabled = false;
                this.Activate();
            }
        }
    }
}
