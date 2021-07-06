using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeMenu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            KeyboardHook.HookStart();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NDBO_T1());
        }

        public static NHA_KeybroadHook.NHA_KeyboardHook KeyboardHook = new NHA_KeybroadHook.NHA_KeyboardHook(
            KeyboardHook_KeyDown,
        KeyboardHook_KeyUp);

        public static List<string> HookedKeyboardPressedKeys = new List<string>();
        public static bool KeyboardHook_KeyDown(int vkCode){
            string key = $"{(Keys)vkCode}";
            if (!HookedKeyboardPressedKeys.Contains(key)){
                HookedKeyboardPressedKeys.Add(key);
            }
            return true;
        }

        public static bool KeyboardHook_KeyUp(int vkCode){
            string key = $"{(Keys)vkCode}";
            if (HookedKeyboardPressedKeys.Contains(key)){
                HookedKeyboardPressedKeys.Remove(key);
            }
            return true;
        }


    }
}
