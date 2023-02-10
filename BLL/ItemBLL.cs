using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class ItemBLL
    {
        IItemRepositorio _ItemRepositorio;

        public ItemBLL()
        {   
            try
            {
                _ItemRepositorio = new ItemRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Item> Get_ItemInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _ItemRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ItemRepositorio.Get(u => u.itemId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarItem(Item _item)
        {
            try
            {
                _ItemRepositorio.Adicionar(_item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Item Localizar(int id)
        {
            try
            {
                return _ItemRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirItem(Item _item)
        {
            try
            {
                _ItemRepositorio.Deletar(c => c == _item);
                _ItemRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarItem(Item _item)
        {
            try
            {
                _ItemRepositorio.Atualizar(_item);
                _ItemRepositorio.Commit();
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
                _ItemRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Item> GetItensPorPedidosDoCliente(int codigoPedido)
        {
            try
            {
                return _ItemRepositorio.Get(u => u.pedidoId == codigoPedido).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
