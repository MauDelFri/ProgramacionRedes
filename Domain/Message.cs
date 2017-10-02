﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Domain
{
    public class Message
    {
        public String Text { get; set; }
        public DateTime Date { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }

        public Message(string text, User sender, User receiver)
        {
            this.Text = text;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Date = DateTime.Now;
        }

        public string FormatToSend()
        {
            return this.Sender.Username + Constants.ATTRIBUTE_SEPARATOR + this.Date.ToString(Constants.DATE_FORMAT) + 
                Constants.ATTRIBUTE_SEPARATOR + this.Text;
        }
    }
}
