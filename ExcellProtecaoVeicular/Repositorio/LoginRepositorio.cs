using ExcellProtecaoVeicular.Models;
using ExcellProtecaoVeicular.Repositorio;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System;
using System.Collections;
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
                using (enty = new _EntyContext())
                {
                    var Tipousuario = (from us in enty.Usuarios
                                       where (us.Login.Equals(user.Login) &&
                                       us.password.Equals(user.password) &&
                                      us.TipoUsuario == user.TipoUsuario  ? us.Login==null: false)
                                       select us.Login.Count());



                    if (Tipousuario.Count() <=0)
                    {
                        return false;
                    }
                    else
                        return true;
                }
            }
            catch (Exception)
            {

                return false;
                //throw new Exception(string.Format("Error \n {0}", ex.Message));
            }
            }
           
        }
    }
