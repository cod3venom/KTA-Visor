using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.card.events
{
    public class OnCardReadedEvent : EventArgs
    {
        public OnCardReadedEvent(string cardId)
        {
            this.CardId = cardId;
        }

        public string CardId { get; set; }
    }
}
