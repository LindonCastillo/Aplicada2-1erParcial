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
    public class InscripcionesController
    {
        public bool Guardar(Inscripciones inscripciones)
        {
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if(db.Inscripciones.Any(A => A.InscripcionId == inscripciones.InscripcionId))
				{
					paso = Modificar(inscripciones);
				}
				else
				{
					paso = Insertar(inscripciones);
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

		public bool Insertar(Inscripciones inscripciones)
		{
			Contexto db = new Contexto();
			EstudianteController controller = new EstudianteController();
			bool paso = false;
			try
			{
				Estudiantes tempEstudiante = controller.Buscar(inscripciones.EstudianteId);
				tempEstudiante.Balance += inscripciones.Balance;
				controller.Modificar(tempEstudiante);

				db.Inscripciones.Add(inscripciones);
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

		public bool Modificar(Inscripciones inscripciones)
		{
			Contexto db = new Contexto();
			EstudianteController controller = new EstudianteController();
			bool paso = false;
			try
			{
				Estudiantes tempEstudiante = controller.Buscar(inscripciones.EstudianteId);
				Inscripciones inscripcion = Buscar(inscripciones.InscripcionId);

				decimal nuevoBalance = tempEstudiante.Balance -= inscripcion.Balance;
				tempEstudiante.Balance = nuevoBalance + inscripciones.Balance;
				controller.Modificar(tempEstudiante);

				db.Entry(inscripciones).State = EntityState.Modified;
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
			EstudianteController controller = new EstudianteController();
			bool paso = false;
			try
			{
				Inscripciones inscripciones = db.Inscripciones.Find(id);
				if (inscripciones != null)
				{
					Estudiantes tempEstudiante = controller.Buscar(inscripciones.EstudianteId);
					tempEstudiante.Balance -= inscripciones.Balance;
					controller.Modificar(tempEstudiante);

					db.Entry(inscripciones).State = EntityState.Deleted;
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


		public Inscripciones Buscar(int id)
		{
			Contexto db = new Contexto();
			Inscripciones inscripciones;
			try
			{
				inscripciones = db.Inscripciones.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return inscripciones;
		}


		public List<Inscripciones> GetList(Expression<Func<Inscripciones,bool>> expression)
		{
			Contexto db = new Contexto();
			List<Inscripciones> lista = new List<Inscripciones>();
			try
			{
				lista = db.Inscripciones.Where(expression).ToList();
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
