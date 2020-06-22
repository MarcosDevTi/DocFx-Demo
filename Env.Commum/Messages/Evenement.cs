using MediatR;
using System;

namespace Env.Commun
{
    public class Evenement : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Evenement()
        {
            Timestamp = DateTime.Now;
        }
    }
}