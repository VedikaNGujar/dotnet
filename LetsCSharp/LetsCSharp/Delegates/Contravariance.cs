﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static LetsCSharp.Delegates.KeyEventArgs;

namespace LetsCSharp.Delegates
{
    public interface EventArgs { }
    public class KeyEventArgs : EventArgs { }
    public class MouseEventArgs : EventArgs { }

    public class TextBox
    {
        public delegate void KeyEventHandler(object sender, KeyEventArgs e);
        public event KeyEventHandler? KeyDown;


        public delegate void MouseEventHandler(object sender, MouseEventArgs e);
        public event MouseEventHandler? MouseClick;
    }

    internal class Contravariance
    {

        public void MultiHandler(object sender, EventArgs e)
        {
            Console.WriteLine("In multihandler");
        }

        public void Test()
        {
            TextBox textBox = new TextBox();
            // You can use a method that has an EventArgs parameter,  
            // although the event expects the KeyEventArgs parameter.  
            textBox.KeyDown += this.MultiHandler;

            // You can use the same method
            // for an event that expects the MouseEventArgs parameter.  
            textBox.MouseClick += this.MultiHandler;


        }


    }
}