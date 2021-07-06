using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NHA_DirtBoxOverlay{
    public partial class DirtBoxOverlay : Form{

        public string OverlayTitle(Process OverlayingProcess) { return "NHADirtBox: " + OverlayingProcess.ProcessName; }
        public string CurrentTitle = "";
        public DirtBoxOverlay(Process OverlayingProcess,Color TransparencyKey,Action CallWhenKilled){
            WhatWeOverlay = OverlayingProcess;
            InitializeComponent();
            SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | 0x80000 | 0x20);
            CurrentTitle = OverlayTitle(OverlayingProcess);
            this.Text = CurrentTitle;
            OverlayWindow();
            SetInvisibleColor(TransparencyKey);
            this.SendToBack();
            this.Size = new Size(0,0);
            this.TopLevel = true;
            this.SendToBack();
        }
      public  Process WhatWeOverlay;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT{
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }


        
        [DllImport("User32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("User32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle(){
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0){
                return Buff.ToString();
            }
            return null;
        }


public void SetInvisibleColor(Color Setup){
            this.AllowTransparency = true;
            this.BackColor = Setup;
            this.TransparencyKey = Setup;
        }

        //Set To True To Close Dirt Box Window
        public bool Shutdown=false;
        public int DirtBoxIndex = 0;
        public Form OverlayingWindow = new Form();
        public bool RefreshOverlayingWindow = false;
        public static int[] RefreshSpeeds = {10,//Fast ASF
                                      50,//Regular
                                     70,//Decent
                                     100,//Slow
                                       };
        public int TicksPerRedraw = 1;
        public int CurrentTickCount = 0;


        public int RefreshSpeedInMiliseconds = RefreshSpeeds[1];//REGULAR SPEED
        public async Task OverlayWindow(){
            CurrentTickCount = 0;
            RefreshOverlayingWindow = true;
           // this.Opacity = 0;
            for (; ; ){
                if (Shutdown==true|| WhatWeOverlay.HasExited) { break; }
                WindowAttached = (AWT == WhatWeOverlay.MainWindowTitle || AWT == this.Text);
                OverlayingRefreshHandler();
                if (CurrentTickCount == TicksPerRedraw){
              await  OverlayingRedrawHandler();
                    CurrentTickCount = 0;
                }
                CurrentTickCount++;

                    await Task.Delay(RefreshSpeedInMiliseconds);
            }
            this.Close();
        }

public async Task OverlayingRefreshHandler(){
if(RefreshOverlayingWindow==true){
this.Controls.Clear();
OverlayingWindow.TopLevel = false;
this.Controls.Add(OverlayingWindow);
}
}
        
public double WindowOpacity=1;
public RECT TestRectangle=new RECT();

public string AWT="";
public async Task OverlayingRedrawHandler(){
 AWT = GetActiveWindowTitle();
if(WindowAttached==true){
if (GetWindowRect(WhatWeOverlay.MainWindowHandle, out TestRectangle)){
Resizing();
ShowWindow();
}
}else if(this.TopMost==true){
HideWindow(); WindowAttached = false;
}


}
public bool WindowAttached=false;

public void Resizing(){
this.Size = new Size((TestRectangle.Right-12) - TestRectangle.Left, (TestRectangle.Bottom-7) - TestRectangle.Top );
this.Top = TestRectangle.Top;
this.Left = TestRectangle.Left+7;
OverlayingWindow.Size=this.Size;
}


public void HideWindow(){       
//this.Opacity=0;
//this.TopLevel=false;
//this.WindowState = FormWindowState.Minimized;
this.TopMost = false;
}

public void ShowWindow(){
//this.Opacity = WindowOpacity;
this.TopMost = true;
SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | 0x80000 | 0x20);
//this.WindowState = FormWindowState.Normal;
}


}
}
