using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FakeMenu{

    public  class FakeMenu{

        public int[] MenuPosition = new int[] {100//y
                                             ,20//x
                                                };

       public Form NEW;
        public FakeMenu(string Base){
            FakeMenu_Items_Base BASE=  new FakeMenu_Items_Base(Base,this);
            BASE.CloseMenu = CloseMenu;
            BASE.RefreshListOptions = RefreshListOptions;

            NEW = new Form();
            NEW.Controls.Add(VisualModImage());
            NEW.FormBorderStyle = FormBorderStyle.None;
            NEW.TopLevel = false;
            NEW.Top = MenuPosition[0];
            NEW.Left = MenuPosition[1];
            RefreshListOptions(BASE.StartMenu);
            void NEW_SizeChanged(object sender, EventArgs e){
            }
            NEW.SizeChanged += NEW_SizeChanged;
            CloseMenu();
            MenuControlHandler();
        }
        


        public List<object> CurrentFakeMenuOptions = new List<object>();

        public Color FakeMenuBackGroundColor = Color.Black;
        public Color FakeMenuForeGroundColor = Color.White;
        public Color FakeMenuTransparancyKey = Color.Beige;
        public Font FakeMenuFont = SystemFonts.DefaultFont;
        public Label VisualFakeModItem(string Name){
            Label D = new Label();
            D.Text = Name;
           D.Width = MenuWidth;
           D.Height = 20;
            D.MaximumSize = new Size(D.Width, D.Height);
            D.Font = FakeMenuFont;
            D.Dock = DockStyle.Top;
            D.BackColor = FakeMenuBackGroundColor;
            D.ForeColor = FakeMenuForeGroundColor;
            D.TextAlign = ContentAlignment.MiddleCenter;
            D.Show();
            D.BringToFront();
            return D;
        }
        public Label VisualFakeModTitle(string Name){
            Label D = new Label();
            D.Text = Name;
           D.Width = MenuWidth;
           D.Height = 20;
            D.MaximumSize = new Size(D.Width, D.Height);
            D.Font = FakeMenuFont;
            D.Dock = DockStyle.Top;
            D.BackColor = FakeMenuBackGroundColor;
            D.ForeColor = FakeMenuForeGroundColor;
            D.TextAlign = ContentAlignment.MiddleCenter;
            D.Show();
            D.BringToFront();
            return D;
        }

        public string DirOfModImage = Environment.CurrentDirectory + "\\NHA_MenuImage.jpg";
        public void CreateModImageIfNone() { if (!System.IO.File.Exists(DirOfModImage)) { System.IO.File.WriteAllBytes(DirOfModImage, Properties.Resources.MENUIMG_GTAV); } }

        public int MenuWidth = 150;
        public int MenuHeightMax = 150;
        public PictureBox VisualModImage(){
            CreateModImageIfNone();
            PictureBox PB = new PictureBox();
            PB.Name = "InitImage";
            PB.Width = MenuWidth;
            PB.Height = 60;
            PB.Image= Bitmap.FromFile(DirOfModImage);
            PB.BackColor = this.FakeMenuTransparancyKey;
            PB.SizeMode = PictureBoxSizeMode.Zoom;
            PB.MaximumSize = new Size(PB.Width, PB.Height);
            PB.Dock = DockStyle.Top;
            PB.ForeColor = this.FakeMenuTransparancyKey;
            PB.Show();
            PB.BringToFront();
            return PB;
        }

        public Control[] GetInitObjects() { return new Control[] { VisualModImage(), VisualFakeModTitle(CurrentMenuTitle) }; }

        public object[] ActionBuilder(string ActionName,Action Action0,Action Action1) {return new object[]{ ActionName,Action0, Action1 }; }
        public List<object[]> ActionHandler = new List<object[]>();
        public string CurrentMenuTitle = "";
        public Type LabelType = new Label().GetType();
        public int StartPointForScrolling = 0;
        public NHA_DirtBoxOverlay.DirtBoxOverlay DBO;
        public int[] MaxWindowSizing(){
            return new int[]{
               DBO.Top,
               DBO.Left,
               DBO.Width,
               DBO.Height,
           };
        }

        public void RefreshListOptions(List<object> MenuPage){
            CurrentMenuTitle = (string)MenuPage[0];
            List<object> Pages = new List<object>(MenuPage);
            Pages.RemoveAt(0); 
            NEW.Controls.Clear();
            NEW.Controls.AddRange(GetInitObjects());
            ActionHandler.Clear();
            NEW.Controls[NEW.Controls.Count - 1].BringToFront();
            StartPointForScrolling= NEW.Controls.Count;
            foreach (List<object> MenuOption in Pages){
                NEW.Controls.Add(VisualFakeModItem((string)MenuOption[0]));
                NEW.Controls[NEW.Controls.Count - 1].BringToFront();
                ActionHandler.Add(ActionBuilder((string)MenuOption[0], (Action)MenuOption[1], (Action)MenuOption[2]));
            }

            MenuHeightMax = 0;
            foreach (Control Obi in NEW.Controls){
                MenuHeightMax += Obi.Height+1;
            }

            MenuCurrentOptionIndex = MenuSizeCap();
            RecolorMenu();
                }


        public string[] BindMenuUp = new string[] { "Up" };
        public string[] BindMenuDown = new string[] { "Down" };
        public string[] BindMenuActivate = new string[] { "Return" };
        public string[] BindMenuBack = new string[] { "Back" };
        public string[] BindMenuOpen = new string[] { "NumPad0" };
        public bool BindPressed(string[] Binds) {
            foreach (string Bind in Binds){
            if (!Program.HookedKeyboardPressedKeys.Contains(Bind)){
              return false;
            }
            }
            return true;
        }

        public bool MenuOpen = false;
        public int MenuCurrentOptionIndex = 0;
        public bool MenuDisposing = false;
        public async Task RecolorMenu(){
                        foreach(Control CTRL in  NEW.Controls){
                            CTRL.BackColor = FakeMenuBackGroundColor;
                        }
                        NEW.Controls[MenuCurrentOptionIndex].BackColor = Color.FromArgb(30, 120, 120);

            NEW.Top = MenuPosition[0];
            NEW.Left = MenuPosition[1];
        }
        
        int MenuSizeCap() { return NEW.Controls.Count - (StartPointForScrolling + 1); }
        public bool MenuShown = false;
        async Task MenuControlHandler(){
            for (; ; ) {
                if (MenuDisposing==true) { break; }
            if (MenuShown == true){
            if (MenuOpen == true){
                if (BindPressed(BindMenuDown)){
                        if(MenuCurrentOptionIndex>0){
                        MenuCurrentOptionIndex--;
                        }else{
                            MenuCurrentOptionIndex = MenuSizeCap();
                        }
                        RecolorMenu();


                    }
                    else if (BindPressed(BindMenuUp)){  
                        
                        if(MenuCurrentOptionIndex<MenuSizeCap()){
                        MenuCurrentOptionIndex++;
                        }else{
                            MenuCurrentOptionIndex = 0;
                        }
                        RecolorMenu();
                }
                if (BindPressed(BindMenuActivate)){
                        foreach(object[] ACTIVE in ActionHandler){
                            if((string)ACTIVE[0]==((Label)NEW.Controls[MenuCurrentOptionIndex]).Text){
                        ((Action)ACTIVE[1])();break;
                                }
                            }

                }else if (BindPressed(BindMenuBack)){
                        foreach(object[] ACTIVE in ActionHandler){
                            if((string)ACTIVE[0]==((Label)NEW.Controls[MenuCurrentOptionIndex]).Text){
                        ((Action)ACTIVE[2])();break;
                                }
                            }
                    }

            }else{//Menu Not open
                if (BindPressed(BindMenuOpen)){
                      //0  MessageBox.Show("Opening");
                        OpenMenu();
                }


            }}
            await Task.Delay(100);
            }
            }




        public void KeyDebug()
        {
            
                if(Program.HookedKeyboardPressedKeys.Count>=1){
                string BLDR = "";
                foreach (string Key in Program.HookedKeyboardPressedKeys.ToArray()){
                     BLDR = BLDR + Key + ", ";
                }
                MessageBox.Show(BLDR);
                }
        }

        
        public void OpenMenu(){
            MenuOpen = true;
            MenuCurrentOptionIndex = MenuSizeCap();
            NEW.Show();
            RecolorMenu();
        }
        
        public void CloseMenu(){
            MenuOpen = false;
            MenuCurrentOptionIndex = MenuSizeCap();
            NEW.Hide();
            RecolorMenu();
        }




        




    }
}
