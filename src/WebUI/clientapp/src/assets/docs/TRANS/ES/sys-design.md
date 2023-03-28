<style>
  img {
  max-width: 100%;
  height: auto;
}
</style>

<p> Los siguientes diagramas muestran la interacción entre los componentes del software. </p>
<ul>
<li><p> ClientApp es una aplicación Angular Typecript de una sola página que se ejecuta en el navegador. Proporciona la interfaz de usuario. </p></li>
<li><p> <a href="https://github.com/aspnet/home">WebApp</a> es una aplicación <a href="https://github.com/aspnet/home">Asp.Net Core</a> C
# que se ejecuta en el servidor. Responde a las llamadas de WebApi. </p></li>
<li><p> WorkflowApp es una aplicación <a href="https://github.com/dotnet/core">DotNet Core</a> C
# que se ejecuta en el servidor. Realiza el procesamiento por lotes de grabaciones y transcripciones. También podría convertirse en una biblioteca que se ejecute como parte del proceso de la aplicación web. </p></li>
<li><p> Los otros componentes del servidor son las bibliotecas DotNet Core C #. Los utilizan tanto WebApp como WorkflowApp. </p></li>
</ul><hr /><h2> Diseño de sistemas </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>
<p> Los componentes en el diagrama anterior son: </p>
<table style="width:100%">
<tr><th colspan="2"> Aplicaciones </th></tr>
<tr><td> ClientApp </td><td> SPA angular </td></tr>
<tr><td> Aplicación Web </td><td> Proceso del servidor web Asp.Net </td></tr>
<tr><td> WorkflowApp </td><td> Proceso de control del servidor de flujo de trabajo </td></tr>
<tr><th colspan="2"> Bibliotecas </th></tr>
<tr><td> GetOnlineFiles </td><td> Recupere transcripciones y grabaciones en línea </td></tr>
<tr><td> Grabación de proceso </td><td> Extraer y transcribir audio. Crear segmentos de trabajo. </td></tr>
<tr><td> ProcessTranscript </td><td> Transforma las transcripciones en bruto </td></tr>
<tr><td> LoadDatabase </td><td> Rellene la base de datos con datos de la transcripción completa </td></tr>
<tr><td> Acceso en linea </td><td> Rutinas para recuperar archivos de sitios remotos </td></tr>
<tr><td> GoogleCloudAccess </td><td> Rutinas para acceder a los servicios de Google Cloud </td></tr>
<tr><td> FileDataRepositories </td><td> Almacenar y obtener datos de archivos de trabajo JSON </td></tr>
<tr><td> Depósitos de bases de datos </td><td> Almacenar y obtener datos del modelo de la base de datos </td></tr>
<tr><td> DatabaseAccess </td><td> Acceda a la base de datos utilizando Entity Framework </td></tr>
</table>
<hr /><h2> Diseño de ClientApp </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>
<p> La estructura de ClientApp se muestra mejor por su estructura de componente angular </p>
<table style="width:100%">
<tr><th colspan="2"> Componentes de la aplicación </th></tr>
<tr><td> Encabezamiento </td><td> Encabezamiento </td></tr>
<tr><td> Sidenav </td><td> Barra lateral de navegación </td></tr>
<tr><td> Tablero </td><td> Contenedor para componentes del tablero </td></tr>
<tr><td> Documentación </td><td> Contenedor para páginas de documentación </td></tr>
<tr><th colspan="2"> Componentes del tablero de instrumentos </th></tr>
<tr><td> Fixasr </td><td> Reparar texto de reconocimiento de voz automático </td></tr>
<tr><td> Agregar etiquetas </td><td> Agregar etiquetas a las transcripciones </td></tr>
<tr><td> ViewMeeting </td><td> Ver transcripciones completadas </td></tr>
<tr><td> Cuestiones </td><td> Ver información sobre problemas </td></tr>
<tr><td> Alertas </td><td> Ver y establecer información sobre alertas </td></tr>
<tr><td> Oficiales </td><td> Ver información sobre funcionarios </td></tr>
<tr><td> (Otros)) </td><td> Otros componentes a implementar </td></tr>
<tr><th colspan="2"> Servicios </th></tr>
<tr><td> VirtualMeeting </td><td> Ejecutar reunión virtual </td></tr>
<tr><td> Charla </td><td> Componente de chat de usuario </td></tr>
</table>
<hr /><h2> Diseño de aplicaciones web </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>
<p> Cada una de las API web es pequeña y llama a los repositorios para colocar u obtener datos de la base de datos o sistema de archivos. </p>
<table style="width:100%">
<tr><th colspan="2"> Controladores </th></tr>
<tr><td> Fixasr </td><td> Guarde y obtenga la versión más reciente de la transcripción siendo revisada. </td></tr>
<tr><td> Agregar etiquetas </td><td> Guarde y obtenga la versión más reciente de la transcripción que se está etiquetando. </td></tr>
<tr><td> Viewmeeting </td><td> Obtenga el último trnascript completo. </td></tr>
<tr><td> Cuerpos de gobierno </td><td> Guarde y obtenga datos de organismos gubernamentales registrados. </td></tr>
<tr><td> Reuniones </td><td> Guarde y obtenga información de la reunión. </td></tr>
<tr><td> Vídeo </td><td> Obtener video de la reunión. </td></tr>
<tr><td> Cuenta </td><td> Proceso de registro de usuario e inicio de sesión. </td></tr>
<tr><td> Gestionar </td><td> Los usuarios pueden administrar sus perfiles. </td></tr>
<tr><td> Administración </td><td> El administrador puede administrar usuarios, políticas y reclamos </td></tr>
<tr><th colspan="2"> Servicios </th></tr>
<tr><td> Correo electrónico </td><td> Manejar el correo electrónico de confirmación de registro. </td></tr>
<tr><td> Mensaje </td><td> Manejar la confirmación de registro por mensaje de texto. </td></tr>
</table>
<hr /><h2> Diseño de WorkflowApp </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>
<p> El estado del flujo de trabajo para una reunión específica se mantiene en su registro de Reunión en la base de datos. Cada uno de los componentes del flujo de trabajo funciona de forma independiente. Cada uno de ellos recibe una llamada para verificar el trabajo disponible. Cada componente consultará en la base de datos las reuniones que coincidan con sus criterios para el trabajo disponible. Si se encuentra trabajo, lo realizarán y actualizarán el estado de la reunión en la base de datos. </p><p> Para construir un sistema robusto, que pueda recuperarse de fallas, necesitaremos tratar los pasos en el flujo de trabajo como "transacciones". Una transacción se completa por completo o no se completa en absoluto. Si hay fallas irrecuperables durante un paso de procesamiento, el estado de esa reunión vuelve al último estado válido. El código actualmente no implementa transacciones. (Problema de Gitub a seguir) </p><p> Pseudocódigo se da a continuación para los componentes </p>
<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Para todas las entidades gubernamentales del sistema. </li>
<ul>
<li> Verifique los horarios de las reuniones para recuperar </li>
<li> Recuperar archivos de grabación o transcripción </li>
<li> Poner el archivo en la carpeta DATAFILES \ Received </li>
</ul>
<li> Los archivos también se pueden colocar en la carpeta Recibido por la carga del usuario. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Para archivos en DATAFILES \ Received y el registro de la base de datos no existe: </li>
<ul>
<li> Determinar tipo de archivo </li>
<li> Crear registro de base de datos </li>
<li> establecer estado = recibido, aprobado = falso </li>
<li> Enviar mensaje de administrador (es): "Recibido" </li>
</ul>
</ul>
<li> TranscribeRecordings </li>
<ul>
<li> Para grabaciones con tipo de fuente = grabación, estado = recibido, aprobado = verdadero </li>
<ul>
<li> Crear carpeta de trabajo </li>
<li> establecer estado = transcripción, aprobado = falso </li>
<li> Transcribir grabación </li>
<li> establecer estado = transcrito, aprobado = falso </li>
<li> Enviar mensaje de administrador (es): "Transcrito" </li>
</ul>
</ul>
<li> ProcessTranscripts </li>
<ul>
<li> Para transcripciones con sourcetype = transcripción, estado = recibido, aprobado = verdadero </li>
<ul>
<li> Crear carpeta de trabajo </li>
<li> establecer estado = procesamiento, aprobado = falso </li>
<li> Transcripción del proceso </li>
<li> establecer estado = procesado, aprobado = falso </li>
<li> Enviar mensaje de administrador (es): "Procesado" </li>
</ul>
</ul>
<li> Grabación corregida </li>
<ul>
<li> Para grabaciones con estado = transcrito / aprobado = verdadero </li>
<ul>
<li> Crear carpeta de trabajo </li>
<li> establecer estado = revisión, aprobado = falso </li>
<li> La revisión manual ahora tendrá lugar </li>
</ul>
<li> Para grabaciones con estado = corrección de pruebas </li>
<ul>
<li> Compruebe si la corrección de pruebas parece completa. Si es así: </li>
<li> establecer estado = revisión, aprobado = falso </li>
<li> enviar mensaje de administrador (es): "Revisión" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Para grabaciones con estado = revisión, aprobado = verdadero O para transcripciones con estado = procesado, aprobado = verdadero </li>
<ul>
<li> Crear carpeta de trabajo </li>
<li> establecer estado = etiquetado, aprobado = falso </li>
<li> El etiquetado manual ahora tendrá lugar </li>
</ul>
</ul>
<ul>
<li> Para transcripciones con estado = etiquetado </li>
<ul>
<li> Compruebe si el etiquetado parece completo. Si es así: </li>
<li> establecer estado = etiquetado, aprobado = falso </li>
<li> enviar mensaje de administrador (es): "Etiquetado" </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Para reuniones con estado = etiquetado, aprobado = verdadero 
<ul>
<li> establecer estado = cargando, aprobado = falso </li>
<li> cargar el contenido de la reunión en la base de datos </li>
<li> establecer estado = cargado, aprobado = falso </li>
<li> Enviar mensaje de administrador (es): "Cargado" </li>
</ul>
</ul>
</ul><hr /><h2> Secretos de usuario </h2><p> Cuando clonas el repositorio de gobierno desde Github, obtienes todo excepto la carpeta "SECRETS". Esta carpeta reside fuera del repositorio. Contiene la siguiente información "secreta": </p>
<ul>
<li> ClientId y ClientSecret para el servicio de autorización externa de Google. </li>
<li> SiteKey y Secret para el servicio Google ReCaptcha. </li>
<li> Credenciales para Google Cloud Platform. </li>
<li> Cadena de conexión de base de datos. </li>
<li> Nombre de usuario y contraseña de administrador. </li>
</ul><p> La carpeta SECRETS puede contener cuatro archivos. </p>
<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> appsettings.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul><p> TranscribeAudio.json contiene las credenciales de Google Cloud Platform. Cada uno de los otros tres archivos puede contener configuraciones para cada uno de los otros secretos. appsettings.Production.json debe contener toda la configuración para la producción. Cualquier configuración que se encuentre en estos archivos anulará las que están en Server / WebApp / app.settings.json. Este archivo está incluido en el repositorio. </p><p> Si desea que su máquina local tenga acceso a los servicios de Google, debe crear una carpeta local "../SECRETS en relación con la ubicación del repositorio. Luego, por ejemplo, puede agregar un archivo" appsettings.Development. json ", que contiene claves que obtienes de Google. Ver: <a href="home#google-api-keys">claves de API de Google</a> </p><hr /><h1> Documentación </h1><p> Originalmente, esta documentación se guardaba en las páginas de Github Wiki. Pero se decidió mover las páginas al proyecto principal en sí, por dos razones: </p>
<ul>
<li> No puede hacer una solicitud de extracción para cambios en las páginas de Wiki de Github. Esto dificulta que los miembros de la comunidad cambien la documentación. </li>
<li> Es más probable que la documentación permanezca sincronizada con el código si está junto con el código en el mismo repositorio. Un solo RP para cambios de código puede incluir los cambios de documentación asociados con él. </li>
</ul><p> La documentación está escrita en Markdown y se encuentra en Frontend / ClientApp / src / app / assets / docs. </p>
</markdown>
<p> &lt;/mat-card&gt; </p>
