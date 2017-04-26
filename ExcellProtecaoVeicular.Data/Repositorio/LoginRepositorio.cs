using ExcellProtecaoVeicular.Data.Context;
using System.Linq;
using System;
using ExcellProtecaoVeicular.Model.Entity;
using ExcellProtecaoVeicular.Model.Enum;
namespace ExcellProtecaoVeicular.Data.Repositorio
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
                               EnumTipoUsuario.Administrador == user.TipoUsuario
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
                                   where us.Login.Equals(user.Login) &&
                                   us.password.Equals(user.password) &&
                                   us.TipoUsuario == EnumTipoUsuario.Administrador
                                   select us).AsEnumerable();
                if (Tipousuario.Count() >0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                enty.Dispose();
                return false;               
                
            }           
        }
    }
}