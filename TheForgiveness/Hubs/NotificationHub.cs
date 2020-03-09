using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TheForgiveness.Hubs
{
    public class NotificationHub : Hub
    {
        public static string sms;
        public static int time;

     
        //metodo para enviar cualquier notificacion

        public void Send(string sms)
        {
            Clients.All.sendNewNotification(sms);
        }
        
        public override Task OnConnected()
        {
            //chekeamos si el mancito tiene mas de 3 dias.
            time = 8;

            if (time > 3)
            {
                sms = "Usted lleva tiempo sin entrar a los cursos inutil";
                Clients.All.sendSms(sms);
            }
            else
            {
                sms = "Te estabamos esperando";
                Clients.All.sendSms(sms);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}