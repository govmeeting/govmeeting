<h1> Procesar nuevos formatos de transcripción </h1>
<p> El objetivo final es escribir código que procesará cualquier formato de transcripción. Pero hasta entonces, necesitamos escribir un código personalizado para manejar cada nuevo formato. Cuando tengamos suficientes muestras de diferentes formatos, podremos escribir mejor el código genérico. </p>

<p> Estos son los pasos para manejar nuevos formatos de transcripción: </p>

<ul>
<li>
<p> Obtenga una transcripción de muestra de una reunión del gobierno como un archivo pdf o de texto. </p>
</li>
<li>
<p> Nombre el archivo de la siguiente manera: "country_state_county_municipality_agency_language-code_date.pdf". (o .txt) Por ejemplo: </p>
<pre> <code> "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-01-09.pdf".</code> </pre></li>
<li>
<p> Cree una nueva clase con la interfaz "ISpecificFix" en el proyecto "ProcessTranscripts_Lib". </p>
</li>
<li>
<p> Nombre la clase "country_state_county_municipality_agency_language-code". Por ejemplo: </p>
<pre> <code> public class USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en : ISpecificFix</code> </pre></li>
<li>
<p> Implemente el método de clase: </p>
<pre> <code> string Fix(string _transcript, string workfolder)</code> </pre></li>
<li>
<p> Fix () recibe el texto de la transcripción existente y devuelve el texto en el siguiente formato: </p>
</li>
</ul><pre> <code>Section: INVOCATION Speaker: COUNCIL PRESIDENT CLARKE Good morning. We&#39;re getting a very late start, so we&#39;d like to get moving. To give our invocation this morning, the Chair recognizes Pastor Mark Novales of the City Reach Philly in Tacony. I would ask all guests, members, and visitors to please rise. (Councilmembers, guests, and visitors rise.) Speaker: PASTOR NOVALES Good morning, City Council and guests and visitors. I pastor, as was mentioned, a powerful little church in -- a powerful church in Tacony called City Reach Philly. I&#39;m honored to stand in this great place of decision-making. ...</code> </pre>
<p> Cuando se complete esta clase, WorkflowApp procesará las nuevas transcripciones cuando aparezcan en "DATAFILES / RECEIVED". </p>

<p> Notas: </p>

<p> Usamos System.Reflection para crear una instancia de la clase correcta en función del nombre del archivo que se procesará. </p>

<p> Vea la clase "USA_PA_Philadelphia_Philadelphia_CityCouncil_en" en ProcessTranscripts_Lib para ver un ejemplo. Puede comprender mejor lo que está haciendo esta clase al observar los rastros del archivo de registro en la "carpeta de trabajo" que se pasa como argumento a Fix (). </p>

<p> No extraemos la siguiente información ahora, pero finalmente haremos esto. </p>

<ul>
<li> Oficiales presentes </li>
<li> Proyectos de ley y resoluciones presentados </li>
<li> Resultados de votación </li>
</ul>
<p> Austin, TX - EE. UU. También tiene transcripciones de reuniones públicas en línea. Se creó una clase llamada "USA_TX_TravisCounty_Austin_CityCouncil_en" en ProcessTranscripts_Lib. Pero el método Fix () no se implementó. Las transcripciones se pueden obtener de su sitio web: <a href="https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm">Austin, Ayuntamiento de TX</a> </p>
<h1> Modificar el panel del cliente </h1><h2> Agregar una tarjeta para una nueva función </h2>
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
</ul>
<p> (Vea las otras muestras en dash-main.html) </p>
<h2> Reorganizar tarjetas </h2><ol>
<li> Abra el archivo: FrontEnd / ClientApp / src / app / dash-main / dash-main.html. </li>
<li> Cambie las posiciones de la tarjeta cambiando la posición de los elementos gm-small-card o gm-large-card en este archivo. </li></ol><h1> Inicio sesión </h1>
<p> Los archivos de registro para WebApp y WorkflowApp están en la carpeta "registros" en la raíz de la solución. </p>

<ul>
<li> "nlog-all- (date) .log" contiene todos los mensajes de registro, incluido el sistema. </li>
<li> El archivo "nlog-own- (date) .log" contiene solo los mensajes de la aplicación. </li>
</ul>
<p> En la parte superior de muchos de los archivos componentes en ClientApp, se define un constante "NoLog". Cambie su valor de verdadero a falso para activar el registro de la consola solo para ese componente. </p>
<h1> Construir guiones </h1>
<p> Los scripts de compilación de Powershell se pueden encontrar en Utilities / PsScripts </p>

<ul>
<li> BuildPublishAndDeploy.ps1: llame a los otros scripts para crear una versión y desplegarla. </li>
<li> Build-ClientApp.ps1: crea versiones de producción de ClientApp </li>
<li> Publish-WebApp.ps1: cree una carpeta de "publicación" de WebApp </li>
<li> Copy-ClientAssets.ps1 - Copie los activos de ClientApp en la carpeta wwwroot de WebApp </li>
<li> Deploy-PublishFolder.ps1 - Implemente la carpeta de publicación en un host remoto </li>
<li> Cree el archivo README.md para Gethub a partir de los archivos de documentación </li>
</ul>
<p> Deploy-PublishFolder.ps1 implementa el software en govmeeting.org, utilizando FTP. La información de inicio de sesión FTP se encuentra en el archivo appsettings.Development.json en la carpeta SECRETS. Contiene FTP y otros secretos para usar en el desarrollo. A continuación se muestra la sección de este archivo utilizada por FTP: </p>
<pre> <code>{ ... "Ftp": { "username": "your-username", "password": "your-password", "domain": "your-domain" } ... }</code> </pre>
