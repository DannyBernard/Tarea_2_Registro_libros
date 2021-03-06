﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RegistroLibros.DAL;
using RegistroLibros.Entidades;

namespace RegistroLibros.BLL
{
   public class LibrosBll
    {
        public static bool Guardar(Libros libros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Libro.Add(libros) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;


        }
        public static bool Modificar(Libros libros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(libros).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Libros libros = contexto.Libro.Find(id);
                contexto.Libro.Remove(libros);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static Libros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Libros libros = new Libros();

            try
            {
                libros = contexto.Libro.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return libros;
        }
        public static List<Libros> GetList(Expression<Func<Libros,bool>> expression)
        {
            List<Libros> Libros = new List<Libros>();
            Contexto contexto = new Contexto();
            try
            {
                Libros = contexto.Libro.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libros;
        }
        

    }
}


