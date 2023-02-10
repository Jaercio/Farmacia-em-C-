using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {

        IClienteRepositorio _ClienteRepositorio;
        public ClienteBLL()
        {   
            try
            {
                _ClienteRepositorio = new ClienteRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Cliente> Get_ClienteInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _ClienteRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ClienteRepositorio.Get(u => u.clienteId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarCliente(Cliente cli)
        {
            try
            {
                _ClienteRepositorio.Adicionar(cli);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente Localizar(int id)
        {
            try
            {
                return _ClienteRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente LocalizarPorTelefone(string telefone)
        {
            try
            {
                return _ClienteRepositorio.ProcuraPor(c => c.clienteTelefone.Equals(telefone));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirCliente(Cliente cli)
        {
            try
            {
                _ClienteRepositorio.Deletar(c => c == cli);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarCliente(Cliente cli)
        {
            try
            {
                _ClienteRepositorio.Atualizar(cli);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
