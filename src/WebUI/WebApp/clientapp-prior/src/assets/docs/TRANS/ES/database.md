<style>
  table {
  font-size: 100%;
}

table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
  font-weight: normal;
}
th, td {
  padding: 3px;
}
th {
  text-align: left;
}
th {
  text-align: center;
  font-weight: bold;
}
</style><p> Las tablas en la base de datos consisten en: </p><ol>
<li> Tablas de autenticación. </li></ol><p> Estos fueron creados automáticamente por Microsoft Identity Service cuando se verificó "Autenticación = Cuentas de usuario individuales" cuando se compiló el proyecto por primera vez. </p><ol start="2">
<li> Mesas de gobierno. </li></ol><p> Estos son creados por la función "Código Primero" de Entity Framework. EF lee las clases de C# en la biblioteca del proyecto "Base de datos / Modelo" y genera automáticamente el esquema y las tablas de la base de datos. </p><p> Consulte la página del documento "Configuración" para crear y trabajar con la base de datos. </p><h1> Esquema </h1><h2> Tabla de "entidad gubernamental" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th><th> Ejemplo 3 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Nombre </td><td> nombre de la entidad </td><td> Senado </td><td> Montaje </td><td> Junta de planificación </td></tr>
<tr><td> País </td><td> ubicación del país </td><td> Estados Unidos </td><td> Estados Unidos </td><td> Estados Unidos </td></tr>
<tr><td> Estado </td><td> ubicación del estado </td><td></td><td> Iowa </td><td> New Jersey </td></tr>
<tr><td> Condado </td><td> ubicación del condado o región </td><td></td><td></td><td> Gloucester </td></tr>
<tr><td> Municipal </td><td> ciudad o pueblo </td><td></td><td></td><td> Municipio de Monroe </td></tr>
</table>
<p>
* Más ejemplos para la tabla de entidades gubernamentales </p>
<table><tr><th> Campo </th><th> Ejemplo 4 </th><th> Ejemplo 5 </th></tr>
<tr><td> Clave primaria </td><td> 4 4 </td><td> 5 5 </td></tr>
<tr><td> Nombre </td><td> Vidhan Sabha </td><td> Consejo Municipal </td></tr>
<tr><td> País </td><td> India </td><td> India </td></tr>
<tr><td> Estado </td><td> Andhra Pradesh </td><td> Andhra Pradesh </td></tr>
<tr><td> Condado </td><td></td><td> Distrito de Kadapa </td></tr>
<tr><td> Municipal </td><td></td><td> Rayachoty </td></tr>
</table>
<p> Tenga en cuenta que si la entidad gubernamental está a nivel nacional, sus ubicaciones estatales, municipales y del condado son nulas. Si la entidad está a nivel estatal, sus ubicaciones municipales y del condado son nulas, etc. </p><p> Se necesitan ejemplos para otros países. Si tiene otros ejemplos, edite este documento y emita una solicitud de extracción en Github. Si hay razones por las que esto no funcionará en algunos países, envíe un problema a Github. </p><hr /><h2> "Mesa de reuniones </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Gobierno </td><td> clave para entidad gubernamental </td><td> 2 (Senado de los Estados Unidos) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Hora </td><td> tiempo de reunión </td><td> 3 de agosto, &#39;14 19:30 </td><td> 2 de mayo, &#39;14 13:00 </td></tr>
<tr><td> Texto </td><td> texto de transcripción </td><td> "La reunión llegará al orden ..." </td><td> "La asamblea se reunirá ..." </td></tr>
</table>
<hr /><h2> Mesa "representativa" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nombre completo </td><td> nombre completo </td><td> Rep. Steve Jones </td><td> Presidente Ravi Anand </td></tr>
<tr><td> Identificador </td><td> identificador personal </td><td> (por decidir </td><td> (por decidir) </td></tr>
</table>
<p> Los oradores en las reuniones podrían ser representantes de la entidad rectora o del público en general. En cualquier caso, puede haber las mismas personas que asisten a reuniones en más de una entidad gubernamental. Queremos hacer un seguimiento de lo que dice el mismo representante en cada uno de los cuerpos de los que es miembro. Por lo tanto, necesitamos un identificador único para cada representante. </p><p> Tendremos que decidir qué información se requiere para esta identificación. Obviamente no tendremos el número de identidad nacional de una persona de algo de esa naturaleza. Es posible que necesitemos usar una combinación de más de un campo para identificar a alguien. Por ejemplo, dirección y nombre. </p><p> Habrá una tabla "Representante" que contiene un identificador personal único para cada representante. </p><hr /><h2> Tabla "RepresentativeToEntity" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th><th> Ejemplo 3 </th></tr>
<tr><td> Representante </td><td> clave para representante </td><td> 1 </td><td> 2 </td><td> 2 </td></tr>
<tr><td> Gobierno </td><td> clave para entidad gubernamental </td><td> 5 5 </td><td> 7 7 </td><td> 9 9 </td></tr>
</table>
<p> También habrá una tabla, "RepresentativeToEntity", que vincula a los representantes y las entidades gubernamentales en las que sirven. Tenga en cuenta que el mismo representante puede servir en múltiples entidades gubernamentales. </p><hr /><h2> Mesa "ciudadano" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Nombre </td><td> nombre </td><td> John J. </td><td> Rai S. </td></tr>
<tr><td> Reunión </td><td> clave para la reunión </td><td> 2 (reunión del Senado de los Estados Unidos el 3 de agosto de 2014) </td><td> 4 (reunión de Vidhan Sabha el 2 de mayo &#39;14) </td></tr>
</table>
<p> Habrá una mesa "Ciudadano" para los miembros del público. La tabla Ciudadano contendrá una clave extranjera que señala la reunión en la que habló esta persona. </p><p> ¿Deberíamos tratar de rastrear lo que dicen los miembros del público en todas las reuniones a las que asisten? Quizás eso no sea apropiado. </p><p> De lo contrario, no es necesario tratar de identificar de forma exclusiva a los oradores públicos. El nombre que la persona da cuando habla en una reunión se puede usar para identificar a alguien solo para esa reunión. No necesitamos correlacionar ese nombre en las reuniones. Incluso podemos preferir simplemente almacenar el nombre y la inicial del apellido. </p><hr /><h2> Tabla "Tema" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th><th> Ejemplo 3 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td><td> 3 </td></tr>
<tr><td> Gobierno </td><td> clave para entidad gubernamental </td><td> 2 (Senado de los Estados Unidos) </td><td> 2 (Senado de los Estados Unidos) </td><td> 4 (Vidhan Sabha) </td></tr>
<tr><td> Tipo </td><td> Categoría o tema </td><td> Categoría </td><td> Tema </td><td> Categoría </td></tr>
<tr><td> Nombre </td><td> nombre del tema </td><td> Salud </td><td> Obamacare </td><td> educación </td></tr>
</table>
<p> Cada entidad gubernamental (por ejemplo, el senado de los EE. UU. O la Junta de Zonificación en Monroe Township, NJ, EE. UU.) Tendrá sus propios nombres únicos para las categorías y los temas discutidos en sus reuniones. Por lo tanto, la tabla Nombre de etiqueta contiene una clave externa que apunta a la entidad gubernamental. </p><hr /><p> La transcripción completa de la reunión es una cadena de texto. Las tablas Ubicación del altavoz y Ubicación de la etiqueta contienen punteros en el texto, es decir, los puntos de inicio y finalización en los que cambia el altavoz o la etiqueta. Estos serán punteros de caracteres en la cadena de texto. </p><h2> Tabla "Etiquetas de altavoces" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th></tr>
<tr><td> PimaryKey </td><td> llave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Altavoz </td><td> clave para el orador </td><td> 1 (Rep. Jones) </td><td> 2 (Presidente. Anand) </td></tr>
<tr><td> Reunión </td><td> clave para la reunión </td><td> 1 (reunión n. ° 1) </td><td> 2 (reunión n. 2) </td></tr>
<tr><td> comienzo </td><td> señalar cuando el hablante comienza a hablar </td><td> 521 </td><td> 12045 </td></tr>
<tr><td> Final </td><td> señalar cuando el hablante deja de hablar </td><td> 1050 </td><td> 14330 </td></tr>
</table>
<hr /><h2> Tabla "Etiquetas de tema" </h2>
<table><tr><th> Campo </th><th> Sentido </th><th> Ejemplo 1 </th><th> Ejemplo 2 </th></tr>
<tr><td> Clave primaria </td><td> llave unica </td><td> 1 </td><td> 2 </td></tr>
<tr><td> Etiqueta </td><td> clave de etiqueta </td><td> 1 (energía) </td><td> 2 (educación) </td></tr>
<tr><td> Reunión </td><td> clave para la reunión </td><td> 1 (reunión n. ° 1) </td><td> 2 (reunión n. 2) </td></tr>
<tr><td> comienzo </td><td> señalar cuándo comienza el tema </td><td> 750 </td><td> 14500 </td></tr>
<tr><td> Final </td><td> señalar cuando el tema se detiene </td><td> 1345 </td><td> 17765 </td></tr>
</table>
<hr /><h2> Tamaño de datos </h2><p> El tamaño de la base de datos de la reunión final es muy pequeño. Esto nos permitirá crear aplicaciones donde gran parte de los datos se almacenan localmente en la computadora o teléfono inteligente de un usuario, para un alto rendimiento y la capacidad de ejecutar la aplicación fuera de línea. </p>
