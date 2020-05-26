using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace GC
{
    public delegate bool CallBack(int handle, IntPtr param);
    
    internal static class NativeMethods
    {
        // passing managed object as LPARAM
        // BOOL EnumWindows(WNDENUMPROC lpEnumFunc, LPARAM lParam);

        [DllImport("user32.dll")]
        internal static extern bool EnumWindows(CallBack cb, IntPtr param);
    }
    
    class Program
    {
        private static GCHandle _gcHandle;
        
        static void Main(string[] args)
        {
            TextWriter tw = Console.Out;
            GCHandle gcHandle = GCHandle.Alloc(tw);
            CallBack cewp = new CallBack(Cap);
             
            NativeMethods.EnumWindows(cewp, GCHandle.ToIntPtr(gcHandle));
            gcHandle.Free();
            
            
            var first = System.GC.GetTotalMemory(false);
            Changer();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
//            Thread.Sleep(5000);
            var last = System.GC.GetTotalMemory(false);
            Console.WriteLine($"{first} and {last}");
            _gcHandle.Free();
            System.GC.Collect();
            last = System.GC.GetTotalMemory(false);
            Console.WriteLine($"{first} and {last}");
        }

        static void Changer()
        {
            var array = new Decimal[10000000];
            array[55] = 121;

            _gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        static bool Cap(int hadler, IntPtr param)
        {
            GCHandle gch = GCHandle.FromIntPtr(param);
            TextWriter tw = (TextWriter)gch.Target;
            tw.WriteLine(hadler);
            return true;
        }
    }
}