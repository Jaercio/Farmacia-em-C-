using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class PedidoBLL
    {
        IPedidoRepositorio _pedidoRepositorio;

        public PedidoBLL()
        {   
            try
            {
                _pedidoRepositorio = new PedidoRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Pedido> Get_PedidoInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _pedidoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _pedidoRepositorio.Get(u => u.pedidoId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarPedido(Pedido ped)
        {
            try
            {
                _pedidoRepositorio.Adicionar(ped);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pedido Localizar(int id)
        {
            try
            {
                return _pedidoRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirPedido(Pedido ped)
        {
            try
            {
                _pedidoRepositorio.Deletar(c => c == ped);
                _pedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarPedido(Pedido ped)
        {
            try
            {
                _pedidoRepositorio.Atualizar(ped);
                _pedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar()
        {
            try
            {
                _pedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pedido> GetPedidosPorCliente(int codigoCliente)
        {
            try
            {
                return _pedidoRepositorio.Get(u => u.clienteId == codigoCliente).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
