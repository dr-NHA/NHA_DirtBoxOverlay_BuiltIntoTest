using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static NHA_KeybroadHook.NHA_WinAPI;

namespace NHA_KeybroadHook{
public class NHA_KeyboardHook{
public bool GetSystemKeyEvent { get; set; } = true;
public event KeyboardEventCallback KeyDown;
public event KeyboardEventCallback KeyUp;
private readonly LowLevelProc _proc;
private IntPtr _hookID = IntPtr.Zero;

public NHA_KeyboardHook(KeyboardEventCallback DownKey, KeyboardEventCallback UpKey){
_proc = HookCallback;
HookStart();
KeyDown += DownKey;
KeyUp += UpKey;
}

public IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam){
if (nCode >= 0){
var hookStruct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

int vkCode = hookStruct.vkCode;
int flags = hookStruct.flags;

if (wParam == (IntPtr)WM_KEYDOWN
|| (GetSystemKeyEvent && wParam == (IntPtr)WM_SYSKEYDOWN))
if (KeyDown?.Invoke(vkCode) == false)
return (IntPtr)1;

if (wParam == (IntPtr)WM_KEYUP
|| (GetSystemKeyEvent && wParam == (IntPtr)WM_SYSTEMKEYUP))
if (KeyUp?.Invoke(vkCode) == false)
return (IntPtr)1;
}

return CallNextHookEx(_hookID, nCode, wParam, lParam);
}

public void HookStart(){
using (Process curProcess = Process.GetCurrentProcess())
using (ProcessModule curModule = curProcess.MainModule){
_hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle("user32"), 0);
}
}

public void HookEnd(){
UnhookWindowsHookEx(_hookID);
}

public void MakeKeyEvent(int vkCode, KeyboardEventType type){
switch (type){
case KeyboardEventType.KEYDOWN:
keybd_event((byte)vkCode, 0x00, 0x00, 0);
break;
case KeyboardEventType.KEYUP:
keybd_event((byte)vkCode, 0x00, 0x02, 0);
break;
case KeyboardEventType.KEYCLICK:
keybd_event((byte)vkCode, 0x00, 0x00, 0);
keybd_event((byte)vkCode, 0x00, 0x02, 0);
break;
}
}

}
}
