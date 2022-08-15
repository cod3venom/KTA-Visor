﻿using HidLibrary;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using PCSC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfid_test
{
    internal class Program
    {
         

        static void Main()
        {
            using (var ctx = new SCardContext())
            {
                ctx.Establish(SCardScope.User);

                var readerNames = ctx.GetReaders();
                var readerStates = ctx.GetReaderStatus(readerNames);

                foreach (var state in readerStates)
                {
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("Reader: {0}\n" +
                        "CurrentState: {1}\n" +
                        "EventState: {2}\n" +
                        "CurrentStateValue: {3}\n" +
                        "EventStateValue: {4}\n" +
                        "UserData: {5}\n" +
                        "CardChangeEventCnt: {6}\n" +
                        "ATR: {7}",

                        state.ReaderName,
                        state.CurrentState,
                        state.EventState,
                        state.CurrentStateValue,
                        state.EventStateValue,
                        state.UserData,
                        state.CardChangeEventCnt,
                        BitConverter.ToString(state.Atr ?? new byte[0]));

                    state.Dispose();
                }

                ctx.Release();
            }
            Console.ReadKey();
        }
    }
}

