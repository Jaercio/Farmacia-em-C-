using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using DAL;

namespace BLL
{
    public class CategoriaBLL
    {
         ICategoriaRepositorio _CategoriaRepositorio;

        public CategoriaBLL()
        {   
            try
            {
                _CategoriaRepositorio = new CategoriaRepositorio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Categoria> Get_CategoriaInfo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return _CategoriaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _CategoriaRepositorio.Get(u => u.categoriaId == ID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AdicionarCategoria(Categoria cat)
        {
            try
            {
                _CategoriaRepositorio.Adicionar(cat);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria Localizar(int id)
        {
            try
            {
                return _CategoriaRepositorio.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirCategoria(Categoria cat)
        {
            try
            {
                _CategoriaRepositorio.Deletar(c => c == cat);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarCategoria(Categoria cat)
        {
            try
            {
                _CategoriaRepositorio.Atualizar(cat);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
