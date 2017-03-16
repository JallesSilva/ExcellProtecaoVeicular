using ExcellProtecaoVeicular.Models;
using ExcellProtecaoVeicular.Repositorio;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System;
using System.Collections.Generic;
namespace ExcellProtecaoVeicular.Repositorio
{
    public class LoginRepositorio
    {
        _EntyContext enty = null;

        public bool UsuarioCliente(Usuarios user)
        {
            enty = new _EntyContext();
            var Tipousuario = (from us in enty.Usuarios
                               where us.Login.Equals(user.Login) &&
                               us.password.Equals(user.password) &&
                               EnumTipoUsuario.administrador == user.TipoUsuario
                               select us).AsEnumerable();
            if (Tipousuario == null)
            {
                return false;
            }
            else
                return true;
        }
        public bool UsuarioAdministrador(Usuarios user)
        {
            try
            {
                enty = new _EntyContext();
                var Tipousuario = (from us in enty.Usuarios
                                   where (us.Login.ToString()==user.Login.ToString() &&
                                   us.password.ToString() == user.password.ToString() &&
                                  us.TipoUsuario.ToString() == user.TipoUsuario.ToString())
                                   select us).AsEnumerable();


                if (Tipousuario.Count() >0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                enty.Dispose();
                throw new Exception(string.Format("Error \n {0}", ex.Message));
                
            }
           
        }
    }
}