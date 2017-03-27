using ExcellProtecaoVeicular.Model;
using System.Linq;
using System;
namespace ExcellProtecaoVeicular.Data
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
                                   where (us.Login == user.Login &&
                                   us.password == user.password &&
                                  us.TipoUsuario == user.TipoUsuario )
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