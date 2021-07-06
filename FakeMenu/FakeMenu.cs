using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FakeMenu{

    public  class FakeMenu{


        public Form NEW;
        public FakeMenu(string Base){
            FakeMenu_Items_Base BASE=  new FakeMenu_Items_Base(Base);
            BASE.CloseMenu = CloseMenu;
            BASE.RefreshListOptions = RefreshListOptions;
            NEW = new Form();
            NEW.FormBorderStyle = FormBorderStyle.None;
            NEW.TopLevel = false;
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
           D.Width = 100;
           D.Height = 20;
            D.MaximumSize = new Size(D.Width, D.Height);
            D.Show();
            D.Font = FakeMenuFont;
            D.Dock = DockStyle.Top;
            D.BackColor = FakeMenuBackGroundColor;
            D.ForeColor = FakeMenuForeGroundColor;
            D.TextAlign = ContentAlignment.MiddleCenter;
            return D;
        }
        public Label VisualFakeModTitle(string Name){
            Label D = new Label();
            D.Text = Name;
           D.Width = 100;
           D.Height = 20;
            D.MaximumSize = new Size(D.Width, D.Height);
            D.Show();
            D.Font = FakeMenuFont;
            D.Dock = DockStyle.Top;
            D.BackColor = FakeMenuBackGroundColor;
            D.ForeColor = FakeMenuForeGroundColor;
            D.TextAlign = ContentAlignment.MiddleCenter;
            return D;
        }

        public Action[] ActionBuilder(Action Action0,Action Action1) {return new Action[]{Action0,Action1 }; }
        public List<Action[]> ActionHandler = new List<Action[]>();
        public string CurrentMenuTitle = "";
        public void RefreshListOptions(List<object> MenuPage){
            CurrentMenuTitle = (string)MenuPage[0];
            List<object> Pages = new List<object>(MenuPage);
            Pages.RemoveAt(0);
            NEW.Controls.Clear(); 
            ActionHandler.Clear();
            NEW.Controls.Add(VisualFakeModTitle(CurrentMenuTitle));
            NEW.Controls[NEW.Controls.Count - 1].BringToFront();
            foreach (List<object> MenuOption in Pages){
                NEW.Controls.Add(VisualFakeModItem((string)MenuOption[0]));
                ActionHandler.Add(ActionBuilder((Action)MenuOption[1], (Action)MenuOption[2]));
                NEW.Controls[NEW.Controls.Count - 1].BringToFront();
            }

            MenuCurrentOptionIndex = NEW.Controls.Count - 2;
            RecolorMenu();
                }


        public string[] BindMenuUp = new string[] { "Up" };
        public string[] BindMenuDown = new string[] { "Down" };
        public string[] BindMenuActivate = new string[] { "Return" };
        public string[] BindMenuBack = new string[] { "Back" };
        public string[] BindMenuOpen = new string[] { "NumPad0" };
        public bool BindPressed(string[] Binds) {
            foreach(string Bind in Binds){
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
        }

        async Task MenuControlHandler(){
            for (; ; ) {
                if (MenuDisposing==true) { break; }
            if (MenuOpen == true){
                if (BindPressed(BindMenuDown)){
                        if(MenuCurrentOptionIndex>0){
                        MenuCurrentOptionIndex--;
                        }else{
                            MenuCurrentOptionIndex = NEW.Controls.Count - 2;
                        }
                        RecolorMenu();


                    }
                    else if (BindPressed(BindMenuUp)){  
                        
                        if(MenuCurrentOptionIndex<NEW.Controls.Count - 2){
                        MenuCurrentOptionIndex++;
                        }else{
                            MenuCurrentOptionIndex = 0;
                        }
                        RecolorMenu();
                }
                if (BindPressed(BindMenuActivate)){
                           ActionHandler[NEW.Controls.Count - 2-MenuCurrentOptionIndex][0]();

                }else if (BindPressed(BindMenuBack)){
                           ActionHandler[NEW.Controls.Count - 2 - MenuCurrentOptionIndex][1]();
                    }

            }else{//Menu Not open
                if (BindPressed(BindMenuOpen)){
                      //0  MessageBox.Show("Opening");
                        OpenMenu();
                }


            }
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
            MenuCurrentOptionIndex = NEW.Controls.Count - 2;
            NEW.Show();
            RecolorMenu();
        }
        
        public void CloseMenu(){
            MenuOpen = false; 
            MenuCurrentOptionIndex = NEW.Controls.Count - 2;
            NEW.Hide();
            RecolorMenu();
        }




        




    }
}
