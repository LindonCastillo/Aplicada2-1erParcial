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
    public class PagosController
    {
		public bool Guardar(Pagos pagos)
		{
			Contexto db = new Contexto();
			bool paso = false;
			try
			{
				if (db.Pagos.Any(A => A.PagoId == pagos.PagoId))
				{
					paso = Modificar(pagos);
				}
				else
				{
					paso = Insertar(pagos);
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

		public bool Insertar(Pagos pagos)
		{
			Contexto db = new Contexto();
			EstudianteController estudiante = new EstudianteController();
			InscripcionesController inscripciones = new InscripcionesController();
			bool paso = false;
			try
			{
				Inscripciones tempIncripcion = inscripciones.Buscar(pagos.InscripcionId);
				Estudiantes tempEstudiante = estudiante.Buscar(tempIncripcion.EstudianteId);
				tempIncripcion.Balance -= pagos.Monto;
				tempEstudiante.Balance -= pagos.Monto;
				if(tempIncripcion.Balance < 0)
				{
					tempIncripcion.Balance = 0;
				}

				if(tempEstudiante.Balance < 0)
				{
					tempEstudiante.Balance = 0;
				}

				inscripciones.Modificar(tempIncripcion);
				estudiante.Modificar(tempEstudiante);

				db.Pagos.Add(pagos);
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

		public bool Modificar(Pagos pagos)
		{
			Contexto db = new Contexto();
			EstudianteController estudiante = new EstudianteController();
			InscripcionesController inscripciones = new InscripcionesController();
			bool paso = false;
			try
			{
				Inscripciones tempIncripcion = inscripciones.Buscar(pagos.InscripcionId);
				Estudiantes tempEstudiante = estudiante.Buscar(tempIncripcion.EstudianteId);
				Pagos tempPago = Buscar(pagos.PagoId);

				decimal nuevoBalance1 = tempIncripcion.Balance += tempPago.Monto;
				decimal nuevoBalance2 = tempEstudiante.Balance += tempPago.Monto;

				tempIncripcion.Balance = nuevoBalance1 - pagos.Monto;
				tempEstudiante.Balance = nuevoBalance2 - pagos.Monto;
				if (tempIncripcion.Balance < 0)
				{
					tempIncripcion.Balance = 0;
				}

				if (tempEstudiante.Balance < 0)
				{
					tempEstudiante.Balance = 0;
				}

				inscripciones.Modificar(tempIncripcion);
				estudiante.Modificar(tempEstudiante);

				db.Entry(pagos).State = EntityState.Modified;
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
			EstudianteController estudiante = new EstudianteController();
			InscripcionesController inscripciones = new InscripcionesController();
			bool paso = false;
			try
			{
				Pagos pagos = db.Pagos.Find(id);
				if (pagos != null)
				{
					Inscripciones tempIncripcion = inscripciones.Buscar(pagos.InscripcionId);
					Estudiantes tempEstudiante = estudiante.Buscar(tempIncripcion.EstudianteId);
					tempIncripcion.Balance += pagos.Monto;
					tempEstudiante.Balance += pagos.Monto;
					if (tempIncripcion.Balance < 0)
					{
						tempIncripcion.Balance = 0;
					}

					if (tempEstudiante.Balance < 0)
					{
						tempEstudiante.Balance = 0;
					}

					inscripciones.Modificar(tempIncripcion);
					estudiante.Modificar(tempEstudiante);


					db.Entry(pagos).State = EntityState.Deleted;
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


		public Pagos Buscar(int id)
		{
			Contexto db = new Contexto();
			Pagos pagos;
			try
			{
				pagos = db.Pagos.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return pagos;
		}


		public List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
		{
			Contexto db = new Contexto();
			List<Pagos> lista = new List<Pagos>();
			try
			{
				lista = db.Pagos.Where(expression).ToList();
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
