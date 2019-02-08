using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class BrowserHelper
    {
        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void BrowserMinimize()
        {
            ObjectRepository.Driver.Manage().Window.Minimize();
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void GoForward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;

            if (index > windows.Count)
            {
                throw new NoSuchWindowException("Invalid Browser Window index : " + index);
            }

            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            BrowserMaximize();
        }

        /// <summary>
        /// The method closes all windows except the parent window
        /// </summary>
        public static void SwitchToParentWindow()
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;

            for (int id = windows.Count - 1; id > 0; id--)
            {
                ObjectRepository.Driver.SwitchTo().Window(windows[id]);
                ObjectRepository.Driver.Close();
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[0]);
        }
    }
}
