using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMenu
{
   public class FakeMenu_Items_Base{

        public Action CloseMenu;
        public Action<List<object>> RefreshListOptions;
        public List<object> StartMenu;
        public List<object> BackMenu;
        public FakeMenu_Items_Base(string Base,FakeMenu MenuBase){
            if (Base=="FakeMenu"){

                StartMenu = FakeMenuPage0();


                void OpenFakeMenuPageSettings() { RefreshListOptions(FakeMenuPageSettings()); }
                
                List<object> FakeMenuPageSettings(){
                BackMenu = FakeMenuPage0();
                void AddY() {if(MenuBase.MenuPosition[0]< MenuBase. MaxWindowSizing()[3]-( MenuBase.MenuHeightMax)) {  MenuBase.MenuPosition[0]+=10; MenuBase.RecolorMenu();} }
                void TakeY() {if(MenuBase.MenuPosition[0]>35) { MenuBase.MenuPosition[0]-=10; MenuBase.RecolorMenu(); }}
                void AddX() {if(MenuBase.MenuPosition[1]< MenuBase.MaxWindowSizing()[2]-(MenuBase.MenuWidth+4)) {  MenuBase.MenuPosition[1]+=10; MenuBase.RecolorMenu();} }
                void TakeX() {if(MenuBase.MenuPosition[1]> 0) { MenuBase.MenuPosition[1]-=10; MenuBase.RecolorMenu(); }}
               
                    void BACK() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenu Settings",
                NewOption("Add 10 To Menu Y", AddY,BACK),
                NewOption("Take 10 From Menu Y", TakeY,BACK),
                NewOption("Add 10 To Menu X", AddX,BACK),
                NewOption("Take 10 From Menu X", TakeX,BACK)
                };
        }

                List<object> FakeMenuPage0(){           
                BackMenu = StartMenu;
                void Opt0() { RefreshListOptions(FakeMenuPage1()); }
                void Opt1() { RefreshListOptions(FakeMenuPage2()); }
                void Opt2() { RefreshListOptions(FakeMenuPage3()); }
                void Opt3() { RefreshListOptions(FakeMenuPage4()); }
                void Opt4() { RefreshListOptions(FakeMenuPage5()); }
                    return new List<object>() {
                 "FakeMenuPage0",//title
                NewOption("Opt0", Opt0,CloseMenu),//option
                NewOption("Opt1", Opt1,CloseMenu),//option
                NewOption("Opt2", Opt2,CloseMenu),//option
                NewOption("Opt3", Opt3,CloseMenu),//option
                NewOption("Opt4", Opt4,CloseMenu),//option
                NewOption("MenuSettings", OpenFakeMenuPageSettings,CloseMenu)//option

                
      };}

                List<object> FakeMenuPage1(){
                BackMenu = FakeMenuPage0();
                void Opt0B() { RefreshListOptions(BackMenu); }
                void Opt1B() { RefreshListOptions(BackMenu); }
                void Opt2B() { RefreshListOptions(BackMenu); }
                void Opt3B() { RefreshListOptions(BackMenu); }
                void Opt4B() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenuPage1",
                NewOption("Opt0", FakeAction,Opt0B),
                NewOption("Opt1", FakeAction,Opt1B),
                NewOption("Opt2", FakeAction,Opt2B),
                NewOption("Opt3", FakeAction,Opt3B),
                NewOption("Opt4", FakeAction,Opt4B)};
        }
        
        List<object> FakeMenuPage2(){
                BackMenu = FakeMenuPage0();
                void Opt0B() { RefreshListOptions(BackMenu); }
                void Opt1B() { RefreshListOptions(BackMenu); }
                void Opt2B() { RefreshListOptions(BackMenu); }
                void Opt3B() { RefreshListOptions(BackMenu); }
                void Opt4B() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenuPage2",
                NewOption("Opt0", FakeAction,Opt0B),
                NewOption("Opt1", FakeAction,Opt1B),
                NewOption("Opt2", FakeAction,Opt2B),
                NewOption("Opt3", FakeAction,Opt3B),
                NewOption("Opt4", FakeAction,Opt4B)};
            }

         List<object> FakeMenuPage3(){
                BackMenu = FakeMenuPage0();
                void Opt0B() { RefreshListOptions(BackMenu); }
                void Opt1B() { RefreshListOptions(BackMenu); }
                void Opt2B() { RefreshListOptions(BackMenu); }
                void Opt3B() { RefreshListOptions(BackMenu); }
                void Opt4B() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenuPage3",
                NewOption("Opt0", FakeAction,Opt0B),
                NewOption("Opt1", FakeAction,Opt1B),
                NewOption("Opt2", FakeAction,Opt2B),
                NewOption("Opt3", FakeAction,Opt3B),
                NewOption("Opt4", FakeAction,Opt4B)};
            }

         List<object> FakeMenuPage4(){
                BackMenu = FakeMenuPage0();
                void Opt0B() { RefreshListOptions(BackMenu); }
                void Opt1B() { RefreshListOptions(BackMenu); }
                void Opt2B() { RefreshListOptions(BackMenu); }
                void Opt3B() { RefreshListOptions(BackMenu); }
                void Opt4B() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenuPage4",
                NewOption("Opt0", FakeAction,Opt0B),
                NewOption("Opt1", FakeAction,Opt1B),
                NewOption("Opt2", FakeAction,Opt2B),
                NewOption("Opt3", FakeAction,Opt3B),
                NewOption("Opt4", FakeAction,Opt4B)};
            }

         List<object> FakeMenuPage5(){
                    BackMenu = FakeMenuPage0();
                    void Opt0B() { RefreshListOptions(BackMenu); }
                void Opt1B() { RefreshListOptions(BackMenu); }
                void Opt2B() { RefreshListOptions(BackMenu); }
                void Opt3B() { RefreshListOptions(BackMenu); }
                void Opt4B() { RefreshListOptions(BackMenu); }
                return new List<object>() {
                 "FakeMenuPage5",
                NewOption("Opt0", FakeAction,Opt0B),
                NewOption("Opt1", FakeAction,Opt1B),
                NewOption("Opt2", FakeAction,Opt2B),
                NewOption("Opt3", FakeAction,Opt3B),
                NewOption("Opt4", FakeAction,Opt4B)};
            }


            }
        }

        public List<object> NewOption(string OptionName, Action Function, Action Back){
            return new List<object>() { OptionName, Function , Back };
        }
        public void FakeAction(){ }
      

    }
}
