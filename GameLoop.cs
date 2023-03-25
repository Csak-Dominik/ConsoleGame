using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.GameLoop
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class GameScriptAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class EarlyStartAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class StartAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class LateStartAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class EarlyUpdateAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class UpdateAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class LateUpdateAttribute : Attribute { }

    public static class GameLoop
    {
        private static bool initiated = false;
        public static bool looping = true;

        private static ulong frameCount = 0;
        public static ulong FrameCount => frameCount;

        public static int targetFrameRate = 30;

        private static double frameRate;
        public static double FrameRate => frameRate;

        public static double DeltaTime => 1d / targetFrameRate;

        private static List<Delegate> earlyStartMethods = new List<Delegate>();
        private static List<Delegate> startMethods = new List<Delegate>();
        private static List<Delegate> lateStartMethods = new List<Delegate>();

        private static List<Delegate> earlyUpdateMethods = new List<Delegate>();
        private static List<Delegate> updateMethods = new List<Delegate>();
        private static List<Delegate> lateUpdateMethods = new List<Delegate>();

        public class NullAssemblyException : Exception { }

        public static void Run()
        {
            if (initiated) return;
            Init();

            CallEarlyStarts();
            CallStarts();
            CallLateStarts();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            while (looping)
            {
                if (stopwatch.Elapsed.TotalSeconds < DeltaTime) continue;
                frameRate = 1d / stopwatch.Elapsed.TotalSeconds;

                CallEarlyUpdates();
                CallUpdates();
                CallLateUpdates();

                stopwatch.Restart();
                frameCount++;
            }
        }

        private static void Init()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                //Console.WriteLine(assembly.FullName);
                foreach (TypeInfo typeInfo in assembly.GetTypes())
                {
                    if (!typeInfo.GetCustomAttributes(typeof(GameScriptAttribute)).Any()) continue;

                    //Console.WriteLine("\t"+typeInfo.Name);
                    foreach (MethodInfo methodInfo in typeInfo.GetMethods())
                    {
                        //Console.WriteLine("\t\t" + methodInfo.Name);
                        if (methodInfo.GetCustomAttributes(typeof(EarlyStartAttribute)).Any() || methodInfo.Name == "EarlyStart")
                            earlyStartMethods.Add(methodInfo.CreateDelegate(typeof(Action)));

                        if (methodInfo.GetCustomAttributes(typeof(StartAttribute)).Any() || methodInfo.Name == "Start")
                            startMethods.Add(methodInfo.CreateDelegate(typeof(Action)));

                        if (methodInfo.GetCustomAttributes(typeof(LateStartAttribute)).Any() || methodInfo.Name == "LateStart")
                            lateStartMethods.Add(methodInfo.CreateDelegate(typeof(Action)));

                        if (methodInfo.GetCustomAttributes(typeof(EarlyUpdateAttribute)).Any() || methodInfo.Name == "EarlyUpdate")
                            earlyUpdateMethods.Add(methodInfo.CreateDelegate(typeof(Action)));

                        if (methodInfo.GetCustomAttributes(typeof(UpdateAttribute)).Any() || methodInfo.Name == "Update")
                            updateMethods.Add(methodInfo.CreateDelegate(typeof(Action)));

                        if (methodInfo.GetCustomAttributes(typeof(LateUpdateAttribute)).Any() || methodInfo.Name == "LateUpdate")
                            lateUpdateMethods.Add(methodInfo.CreateDelegate(typeof(Action)));
                    }
                }
            }

            initiated = true;
        }

        #region Start Calls
        private static void CallEarlyStarts()
        {
            //Console.WriteLine("Calling starts...");
            foreach (Delegate method in earlyStartMethods)
            {
                method.DynamicInvoke();
            }
        }

        private static void CallStarts()
        {
            //Console.WriteLine("Calling starts...");
            foreach (Delegate method in startMethods)
            {
                method.DynamicInvoke();
            }
        }

        private static void CallLateStarts()
        {
            //Console.WriteLine("Calling starts...");
            foreach (Delegate method in lateStartMethods)
            {
                method.DynamicInvoke();
            }
        }
        #endregion

        #region Update Calls
        private static void CallEarlyUpdates()
        {
            //Console.WriteLine("Calling updates...");
            foreach (Delegate method in earlyUpdateMethods)
            {
                method.DynamicInvoke();
            }
        }

        private static void CallUpdates()
        {
            //Console.WriteLine("Calling updates...");
            foreach (Delegate method in updateMethods)
            {
                method.DynamicInvoke();
            }
        }

        private static void CallLateUpdates()
        {
            //Console.WriteLine("Calling updates...");
            foreach (Delegate method in lateUpdateMethods)
            {
                method.DynamicInvoke();
            }
        }
        #endregion
    }
}
