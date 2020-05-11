<h1> Manejar nuevas transcripciones </h1><p> Algunas ciudades producen transcripciones de reuniones. Esto nos permite omitir la transcripción de la reunión nosotros mismos. Pero presenta un problema diferente. Las transcripciones no estarán en un formato estándar. </p><p> Nuestro software necesitará: </p>
<ul>
<li> Extraer la información. </li>
<li> Agregue etiquetas que permitan que la información se use fácilmente. </li>
</ul><p> La información normalmente en una transcripción, que queremos extraer son: </p>
<ul>
<li> Información de la reunión: hora, lugar, si se trata de una reunión especial. </li>
<li> Oficiales presentes </li>
<li> Encabezados de sección </li>
<li> El nombre de cada orador y lo que dijeron. </li>
</ul><p> Si no hay encabezados de sección, el software debe ser lo suficientemente inteligente como para determinar dónde comienzan las secciones comunes: </p>
<ul>
<li> Llamada de rol </li>
<li> Invocación </li>
<li> Informes del comité </li>
<li> Introducción de proyectos de ley </li>
<li> Resoluciones </li>
<li> Comentario público </li>
</ul><p> Tendremos que ver qué tan bien también podemos extraer los resultados de la votación de proyectos de ley y resoluciones. A veces, los resultados se indican con frases como "Los ayes lo tienen". Otras veces, se realiza una votación formal donde el nombre de cada funcionario se lee en voz alta y la persona responde "sí" o "no". </p><p> La información superflua necesita ser eliminada. Por ejemplo: encabezados o pies de página repetidos, números de línea y números de página. </p><p> Se espera que se pueda escribir un código general que pueda extraer información de una nueva transcripción que nunca haya publicado. Sin embargo, hasta entonces, será necesario escribir un nuevo código para manejar casos específicos. </p><p> Como normalmente solo las ciudades más grandes producen transcripciones: </p>
<ul>
<li> La mayoría de las veces trataremos con grabaciones de reuniones. </li>
<li> En una ciudad más grande, hay más programadores informáticos disponibles capaces de escribir dicho código. </li>
</ul><p> Podríamos construir un mecanismo de complemento que permitiría agregar módulos que realicen la extracción. Podríamos permitir que los complementos se escriban en muchos idiomas diferentes: Python, Java, PHP, Ruby, además de los idiomas en los que el sistema está actualmente escrito: Typecript y C #. </p><p> Actualmente, el software solo maneja un caso, Philadelphia, PA USA. La biblioteca del proyecto "Backend \ ProcessMeetings \ ProcessTranscripts_lib" contiene código para procesar las transcripciones. </p><p> La clase "Specific_Philadelphia_PA_USA" llama a algunas rutinas de propósito general para procesar transcripciones para Filadelfia. </p><p> Hay una clase de código auxiliar "Specific_Austin_TX_USA" destinada a procesar una transcripción de Austin, TX. Tal vez alguien quisiera apuñalar a completar este código. Hay una transcripción de prueba en la carpeta Testdata. Pero probablemente sea mejor obtener lo último de su sitio web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, Ayuntamiento de TX</a> </p><h1> Modificación del panel del cliente </h1><h2> Agregar una tarjeta para una nueva función </h2>
<ul>
<li> En un indicador de terminal, muévase a la carpeta: FrontEnd / ClientApp </li>
<li> Ingrese: ng generar componente your-feature </li>
<li> Agregue su funcionalidad a los archivos en: FrontEnd / ClientApp / src / app / your-feature </li>
<li> Inserte un nuevo elemento gm-small-card o gm-large-card en app / dash-main / dash-main.html. </li>
<li> Modifique el ícono, iconcolor, título, etc. del elemento de la tarjeta. </li>
<li> Si necesita acceder al nombre de la ubicación y agencia actualmente seleccionada en su controlador: 
<ul>
<li> Agregue los atributos de entrada de ubicación y agencia a su elemento de característica </li>
<li> Agregue propiedades de ubicación y agencia @Input en su controlador. </li>
</ul></li>
</ul><p> (Vea las otras muestras en dash-main.html) </p><h2> Reorganizar tarjetas </h2><ol>
<li> Abra el archivo: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Cambie las posiciones de la tarjeta cambiando la posición de los elementos gm-small-card o gm-large-card en este archivo. </li></ol><h1> Inicio sesión </h1><p> Los archivos de registro para WebApp y WorkflowApp se encuentran en la carpeta "registros" en la raíz de la solución. </p>
<ul>
<li> "nlog-all- (date) .log" contiene todos los mensajes de registro, incluido el sistema. </li>
<li> El archivo "nlog-own- (date) .log" contiene solo los mensajes de la aplicación. </li>
</ul><p> En la parte superior de muchos de los archivos componentes en ClientApp, se define un constante "NoLog". Cambie su valor de verdadero a falso para activar el registro de la consola solo para ese componente. </p><h1> Construir guiones </h1><p> Los scripts de compilación de Powershell se pueden encontrar en Utilities / PsScripts </p><h2> BuildPublishAndDeploy.ps1 </h2><p> Este script llama a muchos de los otros scripts para construir una versión de producción y lo implementa. </p>
<ul>
<li> Build-ClientApp.ps1: compila versiones de producción de ClientApp </li>
<li> Publish-WebApp.ps1: cree una carpeta de "publicación" de WebApp </li>
<li> Copy-ClientAssets.ps1 - Copie los activos de ClientApp en la carpeta wwwroot de WebApp </li>
<li> Deploy-PublishFolder.ps1 - Implemente la carpeta de publicación en un host remoto </li>
<li> Cree el archivo README.md para Gethub a partir de los archivos de documentación </li>
</ul><p> Deploy-PublishFolder.ps1 implementa el software en govmeeting.org, utilizando FTP. La información de inicio de sesión FTP se encuentra en el archivo appsettings.Development.json en la carpeta SECRETS. Contiene FTP y otros secretos para usar en el desarrollo. A continuación se muestra el formato de este archivo: </p><pre> <code>{ "ExternalAuth": { "Google": { "ClientId": "your-client-id", "ClientSecret": "your-client-secret" } }, "ReCaptcha": { "SiteKey": "your-site-key", "Secret": "your-secret" }, "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } }</code> </pre>