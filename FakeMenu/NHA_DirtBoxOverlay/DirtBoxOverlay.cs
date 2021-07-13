using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static NHA_DirtBoxOverlay.External;

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
                                      150,//Regular
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
                OverlayingRefreshHandler();
                if (CurrentTickCount == TicksPerRedraw){
                OverlayingRedrawHandler();
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

Decider();
}
public bool Deciding=false;
public bool DeciderCameBackNegative= false;

public bool WindowIsCorrect() {
if(AWT == WhatWeOverlay.MainWindowTitle) { return true; }
if(AWT == this.Text){ return true; }
return false;}
public async Task Decider(){
if(Deciding==false){
Deciding=true; 
DeciderCameBackNegative= false;
for(var i=0;i<=10;i++){
if(!WindowIsCorrect()) {
WindowAttached = false;
DeciderCameBackNegative=true;
break;}
}
WindowAttached =!DeciderCameBackNegative;
Deciding=false; }
}
public bool WindowAttached=false;

public void Resizing(){
if(WindowIsCorrect()){
this.Size = new Size((TestRectangle.Right-12) - TestRectangle.Left, (TestRectangle.Bottom-7) - TestRectangle.Top );
this.Top = TestRectangle.Top;
this.Left = TestRectangle.Left+7;
OverlayingWindow.Size=this.Size;
}}

        public FakeMenu.FakeMenu FakeMenuPtr;
public void HideWindow(){       
//this.Opacity=0;
//this.TopLevel=false;
this.TopMost = false;
this.Size=new Size(0,0);
            FakeMenuPtr.MenuShown = false;
}

public void ShowWindow(){
//this.Opacity = WindowOpacity;
if(WindowIsCorrect()){
this.TopMost = true;
SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | 0x80000 | 0x20);
FakeMenuPtr.MenuShown = true;
}
}


}
}
