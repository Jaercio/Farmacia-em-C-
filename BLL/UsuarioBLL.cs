using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioBLL()
        {   
            try
            {
                _usuarioRepositorio = new UsuarioRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> Get_UsuarioInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _usuarioRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _usuarioRepositorio.Get(u => u.usuarioId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarUsuario(Usuario usu)
        {
            try
            {
                _usuarioRepositorio.Adicionar(usu);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Localizar(int id)
        {
            try
            {
                return _usuarioRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario LoginUsuario(string nome, string senha)
        {
            try
            {
               return  _usuarioRepositorio.ProcuraPor(u=> u.usuarioNome == nome && u.usuarioSenha==senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirUsuario(Usuario usu)
        {
            try
            {
                _usuarioRepositorio.Deletar(c => c == usu);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarUsuario(Usuario usu)
        {
            try
            {
                _usuarioRepositorio.Atualizar(usu);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
