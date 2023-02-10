using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class ProdutoBLL
    {
        IProdutoRepositorio _ProdutoRepositorio;

        public ProdutoBLL()
        {   
            try
            {
                _ProdutoRepositorio = new ProdutoRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Produto> Get_ProdutoInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _ProdutoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ProdutoRepositorio.Get(u => u.produtoId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Produto> filtrarProdutoPorCategoria(int catId)
        {
            try
            {
                 return _ProdutoRepositorio.Get(u => u.produtoCategoriaId == catId ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarProduto(Produto prod)
        {
            try
            {
                _ProdutoRepositorio.Adicionar(prod);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto Localizar(int id)
        {
            try
            {
                return _ProdutoRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirProduto(Produto prod)
        {
            try
            {
                _ProdutoRepositorio.Deletar(c => c == prod);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarProduto(Produto prod)
        {
            try
            {
                _ProdutoRepositorio.Atualizar(prod);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
