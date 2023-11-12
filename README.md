1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

    - Ruta: http://localhost:5125/api/Persona/consulta1

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Persona>> GetConsulta1()
        {
            var alumno = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno")
            .OrderBy(e=>e.Apellido1)
            .ThenBy(e=>e.Apellido2)
            .ThenBy(e=>e.Nombre)
            .ToArrayAsync();

            return alumno;
        }
    ```

2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.
- [x] Crear una consulta que devuelva las personas de un curso determinado, el nombre del curso y la cant   
- Ruta: http://localhost:5125/api/Persona/consulta2

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Persona>> GetConsulta2()
        {
            var alumnoSinTelf = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno" && e.Telefono == null)
            .ToListAsync();

            return alumnoSinTelf;
        }
    ```

3. Devuelve el listado de los alumnos que nacieron en `1999`.

    - Ruta: http://localhost:5125/api/Persona/consulta3

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Persona>> GetConsulta3()
        {
            var alumnos1999 = await _context.Personas
            .Where(e=>e.FechaNacimiento.Year == 1999)
            .ToListAsync();

            return alumnos1999;
        }
    ```

4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.

    - Ruta: http://localhost:5125/api/Persona/consulta4

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Persona>> GetConsulta4()
        {
            var profesoresSinTelf = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "profesor" && e.Nif.ToLower().EndsWith("k"))
            .ToListAsync();

            return profesoresSinTelf;
        }
    ```

5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.

    - Ruta: http://localhost:5125/api/Asignatura/consulta5

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Asignatura>> GetConsulta5()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.Cuatrimestre ==1 && e.Curso == 3 && e.Grado.Id == 7)
            .Include(e=> e.Grado)
            .ToListAsync();

            return asignatura;
        }
    ```

6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

    - Ruta: http://localhost:5125/api/Persona/consulta6

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Persona>> GetConsulta6()
        {
            var alumnas = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.Sexo.ToLower() == "mujer" && 
                    e.AlumnoSeMatriculaAsignaturas.Any(e=>e.Asignatura.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"))
            .ToListAsync();

            return alumnas;
        }
    ```

7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

    - Ruta: http://localhost:5125/api/Asignatura/consulta7

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<Asignatura>> GetConsulta7()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
            .Include(e=>e.Grado)
            .ToListAsync();

            return asignatura;
        }
    ```

8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

    - Ruta: http://localhost:5125/api/Profesor/consulta8

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<object>> GetConsulta8()
        {
            var profesores = await _context.Profesores
            .OrderBy(e=>e.Persona.Apellido1)
            .ThenBy(e=>e.Persona.Apellido2)
            .ThenBy(e=>e.Persona.Nombre)
            .Select(e=> new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre,
                Departamento = e.Departamento.Nombre
            }).ToListAsync();

            return profesores;
        }
    ```

9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.

    - Ruta: http://localhost:5125/api/Asignatura/consulta9

    ```sql
      # Consulta Aqui
      public async Task<IEnumerable<object>> GetConsulta9()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.AlumnoSeMatriculaAsignaturas.Any(e=>e.Alumno.Nif =="26902806M"))
            .Select(e=> new
            {
                NombreAsignatura = e.Nombre,
                AñoDeInicio = e.AlumnoSeMatriculaAsignaturas.Where(e=> e.Alumno.Nif =="26902806M").Select(e=>e.CursoEscolar.Inicio).FirstOrDefault(),
                AñoFinal = e.AlumnoSeMatriculaAsignaturas.Where(e=> e.Alumno.Nif =="26902806M").Select(e=>e.CursoEscolar.Fin).FirstOrDefault()
            }).ToListAsync();

            return asignatura;
        }
    ```

10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`.

    - Ruta: http://localhost:5125/api/Departamento/consulta10

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Departamento>> GetConsulta10()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Asignaturas.Any(e=>e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")))
            .ToListAsync();

            return Departamento;
        }
     ```

11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.

    - Ruta: http://localhost:5125/api/Persona/consulta11

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Persona>> GetConsulta11()
        {
            var alumnos = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.AlumnoSeMatriculaAsignaturas.Any(e=>e.CursoEscolar.Inicio == 2018 && e.CursoEscolar.Fin == 2019))
            .ToListAsync();

            return alumnos;
        }
     ```

12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.

    - Ruta: http://localhost:5125/api/Profesor/consulta12

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta12()
        {
            var profesores = await _context.Profesores
            .OrderBy(e=>e.Departamento.Nombre)
            .ThenBy(e=>e.Persona.Apellido1)
            .ThenBy(e=>e.Persona.Nombre)
            .Select(e=>new
            {
                Departamento = e.Departamento.Nombre,
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }
     ```

13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.

    - Ruta: http://localhost:5125/api/Departamento/consulta13

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Departamento>> GetConsulta13()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Departamento == null))
            .ToListAsync();

            return Departamento;
        }
     ```

14. Devuelve un listado con los profesores que no imparten ninguna asignatura.

    - Ruta: http://localhost:5125/api/Profesor/consulta14

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta14()
        {
            var profesores = await _context.Profesores
            .Where(e=>e.Asignaturas.Any(e=>e.IdProfesorFk == null))
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }
     ```

15. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

    - Ruta: http://localhost:5125/api/Asignatura/consulta15

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Asignatura>> GetConsulta15()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=>e.IdProfesorFk == null)
            .ToListAsync();

            return asignatura;
        }
     ```

16. Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca.

    - Ruta: http://localhost:5125/api/Departamento/consulta16

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta16()
        {
            var asignaturasNoImpartidas = await _context.Asignaturas
            .Where(a => !a.AlumnoSeMatriculaAsignaturas.Any())
            .Select(e=>new
            {
                NombreDepartamento = e.Profesor.Departamento.Nombre,
                NombreAsignatura = e.Nombre
            })
            .ToListAsync();

            

            return asignaturasNoImpartidas;
        }
     ```

17. Devuelve el número total de **alumnas** que hay.

    - Ruta: http://localhost:5125/api/Persona/consulta17

     ```sql
       # Consulta Aqui
       public async Task<int>GetConsulta17()
        {
            var totalAlumans = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.Sexo.ToLower() =="mujer")
            .CountAsync();

            return totalAlumans;
        }
     ```

18. Calcula cuántos alumnos nacieron en `1999`.

    - Ruta: http://localhost:5125/api/Persona/consulta18

     ```sql
       # Consulta Aqui
       public async Task<int>GetConsulta18()
        {
            var total = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno" && e.FechaNacimiento.Year ==1999)
            .CountAsync();

            return total;
        }
     ```

19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

    - Ruta: http://localhost:5125/api/Departamento/consulta19

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta19()
        {
            var departamentos = await _context.Departamentos
            .Where(e=>e.Profesores.Count >=1)
            .Select(e=> new
            {
                NombreDepartamento = e.Nombre,
                TotalProfesores = e.Profesores.Count
            }).OrderByDescending(t=>t.TotalProfesores)
            .ToArrayAsync();

            return departamentos;
        }
     ```

20. Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.

    - Ruta: http://localhost:5125/api/Departamento/consulta20

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta20()
        {
            var departamentos = await _context.Departamentos
            .Select(e=> new
            {
                NombreDepartamento = e.Nombre,
                TotalProfesores = e.Profesores.Count
            }).OrderByDescending(t=>t.TotalProfesores)
            .ToArrayAsync();

            return departamentos;
        }
     ```

21. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas.

    - Ruta: http://localhost:5125/api/Grado/consulta21

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta21()
        {
            var grados = await _context.Grados
            .Select(e=> new
            {
                NombreGrado = e.Nombre,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return grados;
        }
     ```

22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.

    - Ruta: http://localhost:5125/api/Grado/consulta22

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta22()
        {
            var grados = await _context.Grados
            .Where(e=> e.Asignaturas.Count >=40)
            .Select(e=> new
            {
                NombreGrado = e.Nombre,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return grados;
        }
     ```

23. Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de crédidos.

    - Ruta: http://localhost:5125/api/Grado/consulta23

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta23()
        {
            var grados = await _context.Grados
            .SelectMany(e=>e.Asignaturas)
            .GroupBy(e =>new{e.IdGradoFk, e.Tipo})
            .Select(e=> new
            {
                NombreGrado = e.FirstOrDefault().Grado.Nombre,
                TipoAsignatura = e.Key.Tipo,
                TotalCreditos = e.Sum(f=>f.Creditos)
            }).OrderByDescending(t=>t.TotalCreditos)
            .ToListAsync();

            return grados;
        }
     ```

24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.

    - Ruta: http://localhost:5125/api/CursoEscolar/consulta24

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta24()
        {
            var cursos = await _context.CursosEscolares
            .Select(e=>new
            {
                AñoInicio = e.Inicio,
                TotalAlumnosMatriculados = e.AlumnoSeMatriculaAsignaturas.Count
            }).ToListAsync();

            return cursos;
        }
     ```

25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

    - Ruta: http://localhost:5125/api/Profesor/consulta25

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta25()
        {
            var profesores = await _context.Profesores
            .Select(e=> new
            {
                Id = e.Id,
                Nombre = e.Persona.Nombre,
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return profesores;
        }
     ```

26. Devuelve todos los datos del alumno más joven.

    - Ruta: http://localhost:5125/api/Persona/consulta26

     ```sql
       # Consulta Aqui
       public async Task<Persona>GetConsulta26()
        {
            var alumno = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno")
            .OrderByDescending(e => e.FechaNacimiento)
            .FirstOrDefaultAsync();

            return alumno;
        }
     ```

27. Devuelve un listado con los profesores que no están asociados a un departamento.

    - Ruta: http://localhost:5125/api/Profesor/consulta27

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta27()
        {
            var profesores = await _context.Profesores
            .Where(e=>e.Departamento == null)
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }
     ```

28. Devuelve un listado con los departamentos que no tienen profesores asociados.

    - Ruta: http://localhost:5125/api/Departamento/consulta28

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Departamento>> GetConsulta28()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores == null)
            .ToListAsync();

            return Departamento;
        }
     ```

29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.

    - Ruta: http://localhost:5125/api/Profesor/consulta29

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<object>> GetConsulta29()
        {
            var profesor = await _context.Profesores
            .Where(e=> e.IdDepartamentoFk != null && e.Asignaturas.Count == 0)
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesor;
        }
     ```

30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

    - Ruta: http://localhost:5125/api/Asignatura/consulta30

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Asignatura>> GetConsulta30()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=>e.IdProfesorFk == null)
            .ToListAsync();

            return asignatura;
        }
     ```

31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

    - Ruta: http://localhost:5125/api/Departamento/consulta31

     ```sql
       # Consulta Aqui
       public async Task<IEnumerable<Departamento>> GetConsulta31()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Asignaturas.Any(t=>t.AlumnoSeMatriculaAsignaturas == null)))
            .ToListAsync();

            return Departamento;
        }
     ```