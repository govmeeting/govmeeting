<ul>
<li> Se implementan varias piezas del software (pero necesitan mejoras). </li>
<li> Se deben implementar varias piezas críticas. </li>
</ul><h1> Implementado </h1>
<ul>
<li> Diseño general del sistema </li>
<li> Bibliotecas de componentes </li>
<li> Modelo de datos / diseño de bases de datos relacionales. </li>
<li> Crear y publicar guiones </li>
</ul><h2> Interfaz </h2>
<ul>
<li> Diseño de interfaz de usuario </li>
<li> Marco para navegación y tablero </li>
<li> Componente para corregir una transcripción </li>
<li> Componente para agregar etiquetas a una transcripción </li>
<li> Componente para examinar una transcripción procesada </li>
<li> Marcadores de posición para varios otros componentes </li>
<li> Ver modelos </li>
<li> Servicios de mensajes </li>
</ul><h2> Backend </h2>
<ul>
<li> API web de Asp.Net </li>
<li> Marco de procesamiento de flujo de trabajo .Net </li>
<li> Transcriba una grabación de reunión con los servicios de voz de Google. </li>
<li> Rutinas de acceso a Google Cloud. </li>
<li> Procese automáticamente una transcripción de ciudad existente y extraiga la información. </li>
<li> Rutinas de acceso a bases de datos y archivos </li>
<li> Repositorios para abstraer el acceso a archivos y bases de datos </li>
<li> Componente para manejar múltiples copias de seguridad durante la edición de transcripciones </li>
<li> Registro de mensajes </li>
</ul><h2> Autenticación </h2>
<ul>
<li> Registro de usuario e inicio de sesión </li>
<li> Autenticación de 2 factores e inicios de sesión de terceros </li>
<li> Autorización de llamadas a la API web </li>
</ul><h1> A ser implementado </h1>
<ul>
<li> <b>Componentes críticos</b> : esenciales para que el software sea utilizable. </li>
<li> <b>Mejoras necesarias</b> : importante para facilitar su uso. </li>
<li> <b>Prioridad</b> : agregaría mucho valor. </li>
<li> <b>Extras</b> : podrían agregarse más tarde. </li>
</ul><h2> Componentes críticos </h2>
<ul>
<li> Componente para recuperar transcripciones y grabaciones en línea. <a href="https://github.com/govmeeting/govmeeting/issues/83">Edición 83</a> </li>
<li> Implemente la función "Registrar entidad gubernamental". <a href="https://github.com/govmeeting/govmeeting/issues/62">Edición 62</a> </li>
<li> Función de trabajo en progreso. <a href="https://github.com/govmeeting/govmeeting/issues/58">Edición 58</a> </li>
<li> Implementar la función de Alertas de usuario. <a href="https://github.com/govmeeting/govmeeting/issues/20">Issue
# 20</a> </li>
<li> Soporta múltiples idiomas. <a href="https://github.com/govmeeting/govmeeting/issues/16">Edición 16</a> </li>
<li> Componente para identificar subdivisiones políticas desde la ubicación del usuario. <a href="https://github.com/govmeeting/govmeeting/issues/13">Issue
# 13</a> </li>
<li> Capture información adicional del usuario durante el registro del usuario. <a href="https://github.com/govmeeting/govmeeting/issues/47">Edición 47</a> </li>
<li> Implemente un componente "Administrador". <a href="https://github.com/govmeeting/govmeeting/issues/84">Edición 84</a> </li>
<li> Diseñar e implementar un sistema de "reputación". <a href="https://github.com/govmeeting/govmeeting/issues/77">Edición 77</a> </li>
</ul><h2> Mejoras necesarias </h2>
<ul>
<li> Mejora la precisión del reconocimiento de voz. <a href="https://github.com/govmeeting/govmeeting/issues/66">Edición 66</a> </li>
<li> Mejora la interfaz de usuario de corrección de pruebas. <a href="https://github.com/govmeeting/govmeeting/issues/">Problema #</a> </li>
<li> Mejorar la interfaz de usuario Agregar etiquetas. <a href="https://github.com/govmeeting/govmeeting/issues/">Problema #</a> </li>
<li> Mejora la interfaz de usuario de View Meeting. <a href="https://github.com/govmeeting/govmeeting/issues/">Problema #</a> </li>
<li> Descargue y procese imágenes panorámicas para los encabezados de ubicación. <a href="https://github.com/govmeeting/govmeeting/issues/76">Edición 76</a> </li>
</ul><h2> Prioridad </h2>
<ul>
<li> Aplicación móvil para grabar una reunión. <a href="https://github.com/govmeeting/govmeeting/issues/18">Edición 18</a> </li>
<li> Aplicación móvil para usar comandos de voz para corregir una reunión. <a href="https://github.com/govmeeting/govmeeting/issues/55">Edición 55</a> </li>
<li> Addtags: ¿es un proceso de dos pasos? <a href="https://github.com/govmeeting/govmeeting/issues/67">Edición 67</a> </li>
<li> Addtags: filtra la vista por sección. <a href="https://github.com/govmeeting/govmeeting/issues/65">Edición 65</a> </li>
<li> Localice las transcripciones o grabaciones en línea existentes. <a href="https://github.com/govmeeting/govmeeting/issues/13">Issue
# 13</a> </li>
</ul><h2> Extras </h2>
<ul>
<li> Componente para obtener información política sobre una entidad gubernamental. <a href="https://github.com/govmeeting/govmeeting/issues/74">Edición 74</a> </li>
<li> Vuelva a escribir el código de autenticación front-end en Angular. <a href="https://github.com/govmeeting/govmeeting/issues/73">Edición 73</a> </li>
<li> Característica para obtener ayuda con la corrección de pruebas. <a href="https://github.com/govmeeting/govmeeting/issues/69">Edición 69</a> </li>
<li> Cree el servidor WebApi para servir archivos de video. <a href="https://github.com/govmeeting/govmeeting/issues/61">Edición 61</a> </li>
<li> Implemente un medio para conectar en red múltiples instancias de sistemas de Gobmeeting <a href="https://github.com/govmeeting/govmeeting/issues/">Problema #</a> </li>
</ul><h1> Sistemas de produccion </h1><h2> Ejecutando un sitio de Govmeeting </h2><p> Cualquiera puede descargar el software Govmeeting y ejecutarlo en sus propios servidores o hosts compartidos. Esto podría ser: </p>
<ul>
<li> Un organismo gubernamental en sí </li>
<li> Un grupo activista ciudadano </li>
<li> Un ciudadano individual </li>
</ul><p> La escala y los requisitos de la instalación dependerán del tamaño de la comunidad que maneja. Esto determina la carga potente en el sistema. </p><p> Los requisitos también dependen de la cantidad de datos que se guardarán. Una opción es guardar solo las transcripciones procesadas y los datos extraídos. Suponga un tamaño de transcripción de 20,000 palabras y un tamaño promedio de palabra de 6 caracteres. Un año completo de reuniones mensuales del consejo municipal puede caber en 1,5 meg de almacenamiento. Esta es una cantidad trivial de datos </p><p> Sin embargo, guardar y alojar el video / audio de las reuniones es otra cuestión. Esto sería necesario para permitir la reproducción de secciones seleccionadas de la reunión. Los datos de transcripción almacenados contienen la hora de inicio / finalización de los comentarios de cada orador. Esa es una característica factible y quizás sea muy útil. </p><h2> Govmeeting.org </h2><p> Sería útil si un sitio público estuviera disponible para aquellos que no desean instalar y mantener su propio sistema. Esto también significa que los datos recopilados no estarán bajo su control total. Por lo tanto, hay que hacer una compensación. </p><p> "govmeeting.org" es el sitio de demostración actual para el software. Ahora se ejecuta en un host compartido de bajo costo. Podemos considerar la creación de una organización sin fines de lucro que será propietaria y operará este sitio. Si muchos municipios eligen usar este sitio, deberá ejecutarse en un servicio en la nube como AWS o Azure, para aumentar dinámicamente la capacidad. </p>
