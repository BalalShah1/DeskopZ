﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Diagnostics;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerformanceCounter perfCPU = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        System.Windows.Threading.DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();

            GetProcessorInfo();
            GetRamInfo();
            CenterWindowOnScreen();
            GetGpuInfo();
            GetRamCapacity();
            GetMotherboardInfo();
        }

        private void CenterWindowOnScreen()
        {
            var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            var windowWidth = this.Width;
            var windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rpbCPU.Value = (int)perfCPU.NextValue();
            lblCPUPercent.Text = "CPU ";
        }

        private void RpbCPU_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #region // Processor Info

        private void GetProcessorInfo()
        {
            var wmi = new ManagementClass("Win32_Processor");
            var providers = wmi.GetInstances();

            foreach (var provider in providers)
            {
                var processorFamily = (provider["Name"]);
                var processorSpeed = Convert.ToInt32(provider["CurrentClockSpeed"]);
                var processorStatus = provider["Status"].ToString();
                var processorCores = Convert.ToInt16(provider["NumberOfLogicalProcessors"]);
                var processorCache = (provider["Description"]);
                var processorType = (provider["SystemName"]);

                lblProcessorStatus.Text = "Processor Status : " + "  " + processorStatus.ToString();
                lblProcessorClockSpeed.Text = "Clock Speed : " + "  " + processorSpeed.ToString() + " " + "MHz";
                lblProcessorFamily.Text = "CPU: " + "  " + processorFamily.ToString();
                lblProcessorVoltage.Text = "Cores : " + "  " + processorCores.ToString();
                lblProcessorCache.Text = "Revision : " + "  " + processorCache.ToString();
                lblProcessorType.Text = "Desktop Name : " + "  " + processorType.ToString();
            }
        }
        #endregion



        #region // GPU

        private void GetGpuInfo()
        {
            var wmi = new ManagementClass("Win32_VideoController");
            var providers = wmi.GetInstances();

            foreach (var provider in providers)
            {
                var gpuName = (provider["Description"]);
                var gpuMemory = (provider["DriverVersion"]);
                var gpuSpec = (provider["Status"]);
                var gpuMem = (provider["VideoModeDescription"]);


                lblGPUName.Text = "GPU : " + "  " + gpuName.ToString();
                lblGPURAM.Text = "Driver version : " + "  " + gpuMemory.ToString();
                lblGPUSpec.Text = "GPU Status : " + "  " + gpuSpec.ToString();
                lblGPUMem.Text = "Resolution : " + "  " + gpuMem.ToString();
            }
        }




        #endregion


        #region // Ram info

        private void GetRamInfo()
        {
            var wmi = new ManagementClass("Win32_PhysicalMemory");
            var providers = wmi.GetInstances();

            foreach (var provider in providers)
            {
                var ramSpeed = Convert.ToInt32(provider["Speed"]);

                lblRAM.Text = "RAM Speed : " + "  " + ramSpeed.ToString() + " MHz";
            }
        }

        #endregion


        #region  // RAM Capacity

        private void GetRamCapacity()
        {
            var wmi = new ManagementClass("Win32_MemoryDevice");
            var providers = wmi.GetInstances();


            foreach (var provider in providers)
            {
                var ramCapacity = Convert.ToInt64(provider["NumberOfBlocks"]);

                lblRAMCapacity.Text = ramCapacity.ToString();
            }
        }

        #endregion

        #region // Motherboard Info

        private void GetMotherboardInfo()
        {
            var wmi = new ManagementClass("Win32_MotherboardDevice");
            var providers = wmi.GetInstances();


            foreach (var provider in providers)
            {

            }
        }

        #endregion
    }
}
