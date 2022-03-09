<p> A continuación se muestra una descripción funcional de las principales piezas del software. </p><h2> Registro individual </h2>
<ul>
<li> Durante el registro, los usuarios especifican la ubicación de su hogar (pueblo, ciudad, pueblo, código postal, etc.). </li>
<li> Según su ubicación, el sistema determina las entidades de gobierno a las que pertenecen. (país, estado, condado, pueblo / ciudad, etc.) </li>
</ul><h2> Registro del organismo gubernamental </h2>
<ul>
<li> Un usuario puede registrar cualquiera de las entidades de gobierno a las que pertenece. </li>
<li> La información ingresada incluirá: 
<ul>
<li> URL del sitio web </li>
<li> Nombres de los funcionarios de gobierno. </li>
<li> URL donde se pueden encontrar transcripciones o grabaciones de reuniones </li>
</ul></li>
<li> Otros usuarios de esta ubicación verán los datos ya ingresados. Pueden votar sobre la precisión de cualquier elemento de datos e ingresar valores alternativos. </li>
<li> Los votos se acumularán para cada valor de datos. Los valores con más votos se convierten en los valores oficiales. <a href="https://github.com/govmeeting/govmeeting/issues/62">Github número 62</a> </li>
</ul><h2> Importar grabaciones o transcripciones </h2>
<ul>
<li> El sistema descargará las grabaciones o transcripciones en línea existentes en un horario regular desde las ubicaciones especificadas en el Registro del organismo gubernamental. </li>
<li> Los usuarios también tienen la opción de cargar grabaciones o transcripciones. </li>
<li> Muchos lugares no proporcionan transcripciones ni grabaciones de sus reuniones. Govmeeting proporcionará una aplicación de smartphome que los usuarios pueden usar para grabar y cargar personalmente la grabación de una reunión. <a href="https://github.com/govmeeting/govmeeting/issues/18">Github número 18</a> </li>
</ul><h2> Preprocesar transcripciones existentes </h2>
<ul>
<li> Convierta transcripciones a texto sin formato. A menudo, las transcripciones existentes están en otros formatos, como PDF. Estos se convierten en texto sin formato para que se procese más fácilmente. </li>
<li> Extraiga información como el orador y los nombres de las secciones. </li>
</ul><h2> Transcribir grabaciones con reconocimiento de voz </h2>
<ul>
<li> Convierta grabaciones a los formatos de video web principales (mp4, ogg y webm.) Esto los hace más accesibles en todo tipo de dispositivos. </li>
<li> Extraiga y combine pistas de audio si hay más de una. </li>
<li> Suba el archivo de audio al almacenamiento de Google Cloud para prepararse para la transcripción. </li>
<li> Llame a la API asíncrona de Google Speech para hacer el reconocimiento automático de voz. </li>
<li> Realizar reconocimiento de cambio de altavoz. Hay una API de Google para esto. </li>
<li> Agregar identificación del hablante. Esto usará software de procesamiento de voz en el servidor. </li>
<li> Ponga la información en un formato JSON para su posterior procesamiento. </li>
<li> Divida los archivos de video, audio y transcripción en segmentos de trabajo de 3 minutos, para que varios voluntarios puedan trabajar simultáneamente en la corrección de pruebas. </li>
</ul><h2> Texto transcrito revisado [paso manual] </h2>
<ul>
<li> Texto corregido para errores. Proporcione una interfaz fácil de usar para corregir rápidamente los errores. </li>
<li> Información correcta como el orador y los nombres de las secciones. </li>
</ul><p> Govmeeting intenta hacer que el procesamiento sea lo más automático posible. Pero las computadoras aún no son tan inteligentes como nos gustaría. Todavía se necesitan humanos para corregir sus errores. Pero cada día, las computadoras se vuelven más inteligentes y este trabajo debería seguir siendo cada vez menos. </p><h2> Agregar etiquetas de problema [Paso manual] </h2>
<ul>
<li> Uno de los trabajos más importantes es agregar correctamente etiquetas o metadatos a la transcripción. Esto es lo que permite: 
<ul>
<li> información para ser fácilmente localizada. </li>
<li> una transcripción para indexar y examinar rápidamente </li>
<li> alertas configuradas por el usuario sobre problemas específicos </li>
</ul></li>
<li> Los nombres de los problemas deben ser asignados por personas y no por computadoras. Esta es la mejor manera de garantizar que sean significativos. </li>
<li> Es importante que se proporcione una interfaz de usuario muy fácil de usar y rápida. </li>
</ul><p> En el futuro, quizás este paso también lo pueda hacer principalmente una computadora. Pero no todo es malo necesitar un poco de trabajo manual de los voluntarios de la comunidad. Ayuda a unir a las personas por una causa común. Si esta es una ciudad pequeña de 35,000 habitantes, no debería ser tan difícil alistar una docena más o menos para dar un poco de tiempo cada mes. </p><h2> Rellenar base de datos relacional </h2><p> Los datos se colocan en una base de datos relacional para que se pueda acceder rápidamente utilizando múltiples criterios. </p><h2> Los datos ahora están disponibles para su uso </h2>
<ul>
<li> Ya está disponible una transcripción que se puede buscar y buscar </li>
<li> Se envía un resumen de los temas discutidos en la reunión a quienes lo solicitan. </li>
<li> Se envían alertas sobre cuestiones específicas a quienes lo solicitan. </li>
</ul><h2> Se organiza una reunión virtual. </h2>
<ul>
<li> Se crea una agenda basada en los problemas de la reunión real. </li>
<li> Se envían invitaciones a los miembros de la comunidad. </li>
<li> En la invitación se incluyen solicitudes de posibles elementos adicionales de la agenda. </li>
<li> Cuando se reciben respuestas, se envía una boleta a los que asistirán. En esta boleta, los miembros pueden votar sobre los nuevos temas de agenda sugeridos para incluir. </li>
<li> Dentro de unos días, se lleva a cabo una reunión virtual. </li>
</ul><h2> Gestión de flujo de trabajo </h2><p> Algunos de los pasos del flujo de trabajo anteriores se realizan automáticamente por computadora y algunos son realizados manualmente por voluntarios. Hay lugares en el flujo de trabajo donde una persona real debe verificar que está bien proceder: </p>
<ul>
<li> Verifique que las URL para recuperar transcripciones y grabaciones parezcan válidas. </li>
<li> Verifique que el contenido de los archivos recuperados parece válido. </li>
<li> Verifique que la salida del preprocesamiento parece válida. </li>
<li> Verifique que la conversión de voz a texto parezca válida. </li>
<li> Verifique que la revisión de la transcripción parezca completada. </li>
<li> Verifique que la adición de etiquetas a la transcripción parezca completada. </li>
<li> Verifique que los datos finales de la transcripción aparezcan completos y válidos. </li>
</ul><p> Debe haber una manera de elevar los derechos de uno o más de los usuarios registrados de una ubicación a un puesto de "administrador". </p>
<ul>
<li> Los gerentes serían notificados cuando haya una decisión pendiente en el flujo de trabajo. </li>
<li> Un administrador podría iniciar sesión y dar o denegar la aprobación para que el flujo de trabajo continúe. </li>
</ul>
