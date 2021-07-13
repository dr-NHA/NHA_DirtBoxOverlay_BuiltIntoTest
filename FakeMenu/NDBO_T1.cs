using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NHA_DirtBoxOverlay;

namespace FakeMenu{
    public partial class NDBO_T1 : Form{

        public NDBO_T1(){
            InitializeComponent();
            OverlayProcessList.CheckOnClick = false;
            SetupOverlayProcessList();
            RefreshOverlayInfoTask();
        }

       public Process[] NEW_PROCESSLIST{
            get{
                Process ThisProcess = Process.GetCurrentProcess();
                List<Process> ProcessArrayBuilder = new List<Process>();
                foreach (Process ListedProcess in Process.GetProcesses()){
                    if (ListedProcess!=ThisProcess&&
                        !ListedProcess.ProcessName.StartsWith("svchost")
                        &&
                        ListedProcess.MainWindowTitle.Replace(" ","")!=""
                        ){
                        ProcessArrayBuilder.Add(ListedProcess);
                    }
                }
                return ProcessArrayBuilder.ToArray();
            }
        }
        public string[] NEW_PROCESSNAMES{
            get{
                List<string> ProcessNameBuilder = new List<string>();
                foreach (Process ListedProcess in NEW_PROCESSLIST) {
                    ProcessNameBuilder.Add(ListedProcess.ProcessName+" | "+ ListedProcess.MainWindowTitle + " | ");
                        }
                return ProcessNameBuilder.ToArray();
            }
        }


        List<string> OverlayedProcessNames = new List<string>();
        List<DirtBoxOverlay> OverlayObjects = new List<DirtBoxOverlay>();
        Process[] ProcessItems;
        public async Task SetupOverlayProcessList(){
            ProcessItems = NEW_PROCESSLIST;
            string[] ProcessNames = NEW_PROCESSNAMES;
            OverlayProcessList.Items.Clear();
            OverlayProcessList.Items.AddRange(ProcessNames);
            int ProcessIndex = 0;
            foreach (string ProcessName in ProcessNames){
                if (OverlayedProcessNames.Contains(ProcessName)){
                    OverlayProcessList.SetItemChecked(ProcessIndex, true);
                }
                ProcessIndex = ProcessIndex + 1;
            }
        }

        public async Task RemoveDirtBoxOverlay(int INDEX){
            foreach (DirtBoxOverlay Overlay in new List<DirtBoxOverlay>(OverlayObjects)){
                if(Overlay.DirtBoxIndex== INDEX){
                    OverlayObjects.Remove(Overlay);
                    Overlay.Shutdown = true;
                }
            }

        }

public void AddDirtBoxOverlayToProcess(int INDEX){
void DoWhenDead(){
RemoveOverlayWindow(INDEX);
RefreshOverlayInfoTask();
}
FakeMenu NewFakeMenu = new FakeMenu("FakeMenu");
DirtBoxOverlay NewDBO = new DirtBoxOverlay(ProcessItems[INDEX], NewFakeMenu.FakeMenuTransparancyKey, DoWhenDead);
NewDBO.FakeMenuPtr= NewFakeMenu;
NewFakeMenu.DBO= NewDBO;
NewDBO.DirtBoxIndex = INDEX;
//NewDBO.TicksPerRedraw
NewDBO.RefreshSpeedInMiliseconds=100;
NewDBO.RefreshOverlayingWindow = true;
NewDBO.Show();
NewDBO.OverlayingWindow = NewFakeMenu.NEW;
NewDBO.OverlayingWindow.BackColor= NewFakeMenu.FakeMenuTransparancyKey;
OverlayObjects.Add(NewDBO);
            

}

        private void RefreshProcessList_Click(object sender, EventArgs e){
            SetupOverlayProcessList();
        }

        private void AddProcessOverlay_Click(object sender, EventArgs e){
            int INDEX = OverlayProcessList.SelectedIndex;
            if(INDEX!=-1){
            if (!OverlayProcessList.GetItemChecked(INDEX)){
                AddDirtBoxOverlayToProcess(INDEX);
                OverlayedProcessNames.Add(OverlayProcessList.GetItemText(OverlayProcessList.Items[INDEX]));
                AllowedItemCheck = true;
                OverlayProcessList.SetItemChecked(INDEX, true);
                RefreshOverlayInfoTask();
            }}
            AllowedItemCheck = false;
        }

        private void RemoveProcessOverlay_Click(object sender, EventArgs e){
            int INDEX = OverlayProcessList.SelectedIndex;
            
            if(INDEX!=-1){
            RemoveOverlayWindow(INDEX);
                }
        }
        public void RemoveOverlayWindow(int INDEX)
        {
            
            if (OverlayProcessList.GetItemChecked(INDEX)){
                try { RemoveDirtBoxOverlay(INDEX); } catch { };
                OverlayedProcessNames.Remove(OverlayProcessList.GetItemText(OverlayProcessList.Items[INDEX]));
                 AllowedItemCheck = true;
                OverlayProcessList.SetItemChecked(INDEX,false);
                RefreshOverlayInfoTask();
            }
            AllowedItemCheck = false;
        }

        public bool AllowedItemCheck = false;
        private void OverlayProcessList_ItemCheck(object sender, ItemCheckEventArgs e){
            if (AllowedItemCheck!=true){
                e.NewValue = e.CurrentValue;
            }
        }

        private void RefreshOverlayInfo_Click(object sender, EventArgs e){
            RefreshOverlayInfoTask();
        }

async Task RefreshOverlayInfoTask(){
OverlayObjectsDisp.Text="Overlay Objects: "+ OverlayObjects.Count.ToString();
OverlayNamesDisp.Text = "Overlay Names: " + OverlayedProcessNames.Count.ToString();
}



    }
}
