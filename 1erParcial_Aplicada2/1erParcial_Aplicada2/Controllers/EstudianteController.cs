using _1erParcial_Aplicada2.Data;
using _1erParcial_Aplicada2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Controllers
{
    public class EstudianteController
    {
		public bool Guardar(Estudiantes estudiantes)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if (db.Estudiantes.Any(A => A.EstudianteId == estudiantes.EstudianteId))
				{
					paso = Modificar(estudiantes);
				}
				else
				{
					paso = Insertar(estudiantes);
				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Insertar(Estudiantes estudiantes)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Estudiantes.Add(estudiantes);
				paso = db.SaveChanges() > 0;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Modificar(Estudiantes estudiantes)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				db.Entry(estudiantes).State = EntityState.Modified;
				paso = db.SaveChanges() > 0;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}

		public bool Eliminar(int id)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				Estudiantes estudiantes = db.Estudiantes.Find(id);
				if (estudiantes != null)
				{
					db.Entry(estudiantes).State = EntityState.Deleted;
					paso = db.SaveChanges() > 0;
				}
				else
				{
					paso = false;
				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return paso;
		}


		public Estudiantes Buscar(int id)
		{
			Contexto db = new Contexto();
			Estudiantes estudiantes;
			try
			{
				estudiantes = db.Estudiantes.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return estudiantes;
		}


		public List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> expression)
		{
			Contexto db = new Contexto();
			List<Estudiantes> lista = new List<Estudiantes>();
			try
			{
				lista = db.Estudiantes.Where(expression).ToList();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return lista;
		}
	}
}
