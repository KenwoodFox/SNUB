// CS-114 SNHU

// SNUB Client Program

using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SNUBclientFinalProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}