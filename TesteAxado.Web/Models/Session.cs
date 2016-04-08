using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.Models
{
    public class SessionInstance
    {
        public SessionInstance()
        {
            LoadSession();
        }

        public UserViewModel AuthenticatedUser { get; private set; }

        public bool IsAuthenticated
        {
            get
            {
                return AuthenticatedUser != null;
            }
        }

       void LoadSession()
        {
            //Busca a sessão
            SessionInstance session = HttpContext.Current.Session["Session"] as SessionInstance;
            if (session != null)
                return;

            //Se ela não existe, cria uma nova
            UpdateSession(this);
        }

        internal void UpdateSession(SessionInstance newSession)
        {
            HttpContext.Current.Session.Add("Session", newSession);
        }

        public void Login(UserViewModel user)
        {
            AuthenticatedUser = user;
        }

        public void Logout()
        {
            AuthenticatedUser = null;
        }

    }

    public class MySession
    {
        private static SessionInstance _instance;

        private MySession() { }

        public static SessionInstance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionInstance();

                return _instance;
            }
            set
            {

                _instance = value;
                _instance.UpdateSession(value);
            }
        }
    }
}