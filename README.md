# NHA_DirtBoxOverlay_BuiltIntoTest
This Is A Simple And Easy To Use Game / Process Overlay  Can Be Modified Into Any Overlay Of Your Choice

Usage:

//Set Transparency Key
Color TPK = Color.Aquamarine;

//Function For When The Overlay Dies
void DoWhenDead(){
}

//Create New Overlay
DirtBoxOverlay NewDBO = new DirtBoxOverlay( (Process) , (Color)//TransparencyKey , (void/Action) DoWhenDead);

//Set Overlay ID For Overlay Arrays
NewDBO.DirtBoxIndex = (int);

//Refreshrate
NewDBO.TicksPerRedraw=(int)

//Flag To Set A New Form As Overlay
NewDBO.RefreshOverlayingWindow = true;

//Overlay Window Form
NewDBO.OverlayingWindow = (Form);//Pop A Form In This Variable For It To Show In The Overlay
//Form Needs To Be Shown As The Code Wont Call Show On It!

//Show Overlay (DOESNT AUTO SHOW WHEN CREATING IT)
NewDBO.Show();
